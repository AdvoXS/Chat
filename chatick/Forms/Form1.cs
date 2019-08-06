using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
namespace chatick
{
    public partial class Form1 : Form
    {
        //setup
        IPEndPoint remote;
        UdpClient client;
        IPAddress multiaddress;

        string name; //user name
        int port;
        //listen
        IPEndPoint localIp;
        UdpClient udpClient;
        Thread thread;

        //listener
        string formatted_data;

        //form
        bool formclosed = false;
        logForm parentForm;
        public Form1(logForm logform,string nick)
        {
            InitializeComponent();
            
            name = nick;
            parentForm = logform;
            setup();
        }
        string tmpstr;
        private void setup()
        {
            fdsToolStripMenuItem.MouseUp += fds_context_info_click;
            port = 8105;
            string ipAddress = "35.231.112.165";
            multiaddress = IPAddress.Parse(ipAddress);
            client = new UdpClient();
            client.Connect(multiaddress, port);
            if (name.Length > 5) //проверка на гостя
            {
                tmpstr = "";
                for (int i = 0; i < 5; i++)
                {
                    tmpstr += name[i];
                }
                if (tmpstr == "guest")
                {
                    информацияToolStripMenuItem.Enabled = false;
                    историяСообщенийToolStripMenuItem.Enabled = false;
                }
            }
            remote = new IPEndPoint(multiaddress, port);
            label4.Text = "Вы: " + name;
            Listen();
        }


        private void Listen()
        {

            udpClient = new UdpClient(port+1);
            udpClient.Client.SendTimeout = 5000;
            udpClient.Client.ReceiveTimeout = 500;
            localIp = null;

            textBox1.Text = "";

            button3.Visible = true;
            textBox3.Visible = true;

            //connectInfo
            connectMessage();
            listUsers.Items.Add(name);
            sendName();
            requestNames();

            thread = new Thread(new ThreadStart(Listener));
            thread.Start();
            textBox3.Focus();
        }



        string tmpName = "";

        async private void Listener()
        {
            try
            {
                while (true)
                {
                    Byte[] data;
                    data = udpClient.Receive(ref localIp);
                    
                    formatted_data = FromAes256(data);//Encoding.UTF8.GetString(data);

                    //принятие имени в список участников
                    if (formatted_data != "" && formatted_data[0] == '%' && formatted_data[1] == '&' && formatted_data[2] == 'n' && formatted_data[3] == 'm')
                    {
                        for (int i = 4; i < formatted_data.Length; i++)
                        {
                            tmpName += formatted_data[i];
                        }
                        int indName = -1;
                        indName = listUsers.FindString(tmpName);
                        if (indName == -1)
                        {
                            Action act = () => listUsers.Items.Add(tmpName);
                            listUsers.Invoke(act);
                        }

                        tmpName = "";

                    }
                    //запрос на передачу своего имени
                    else if (formatted_data != "" && formatted_data[0] == 'r' && formatted_data[1] == '@' && formatted_data[2] == 'q' && formatted_data[3] == '#' && formatted_data[4] == 's' && formatted_data[5] == '+' && formatted_data[6] == '+')
                    {
                        sendName();
                    }
                    //удаление из списка участников
                    else if (formatted_data != "" && formatted_data[0] == 'd' && formatted_data[1] == '%' && formatted_data[2] == 'e' && formatted_data[3] == '?' && formatted_data[4] == 'l')
                    {
                        for (int i = 5; i < formatted_data.Length; i++)
                        {
                            tmpName += formatted_data[i];
                        }
                        int indName = -1;
                        indName = listUsers.FindString(tmpName);
                        if (indName != -1)
                        {
                            Action act = () => listUsers.Items.RemoveAt(indName);
                            listUsers.Invoke(act);
                        }
                        tmpName = "";
                    }
                    //вывод обычных данных
                    else if (formatted_data != "" )
                    {
                        //парсим сообщение
                        bool isParseNick = true;
                        string parseNick = "";
                        string parseMessage = "";
                        if (formatted_data[0] != '\t')
                        {
                            for (int i = 0; i < formatted_data.Length; i++)
                            {
                                if (isParseNick && formatted_data[i] != ':')
                                {
                                    parseNick += formatted_data[i];
                                }
                                else if (formatted_data[i] == ':') isParseNick = false;
                                else if (!isParseNick && formatted_data[i] != ':')
                                {
                                    parseMessage += formatted_data[i];
                                }
                            }
                            if (tmpstr != "guest")
                            {
                                try //сохраняем сообщение в историю(в таблицу history_messages)
                                {
                                    await Task.Run(() => DataBasePostgres.add_message_user_async(parseNick, Convert.ToString(DateTime.Now), parseMessage));
                                }
                                catch (Npgsql.PostgresException ex)
                                {
                                    MessageBox.Show("Ошибка соединения с базой данных");
                                    Logs.LogClass logClass = new Logs.LogClass("DB", "Сохранение сообщения в базе данных. Ошибка postgres: " + ex.Message);
                                }
                                catch (Npgsql.NpgsqlException ex)
                                {
                                    MessageBox.Show("Ошибка соединения с базой данных");
                                    Logs.LogClass logClass = new Logs.LogClass("DB", "Сохранение сообщения в базе данных. Ошибка связи: " + ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Неизвестная ошибка");
                                    Logs.LogClass logClass = new Logs.LogClass("System", "Имя объекта вызвавшего ошибку: " + ex.Source + " Ошибка " + ex.Message);
                                }
                            }
                        }
                        if (textBox1.Text != "")
                        {
                            Action act = () =>
                            {
                               textBox1.AppendText("\r\n");
                                textBox1.AppendText(formatted_data);
                            };
                            textBox1.Invoke(act);
                            Action act1 = () => textBox3.Focus();
                            textBox3.Invoke(act1);
                        }
                        else
                        {
                            Action act = () => textBox1.AppendText(formatted_data);
                            textBox1.Invoke(act);
                            Action act1 = () => textBox3.Focus();
                            textBox3.Invoke(act1);
                        }
                    }



                }
            }
            catch (System.Net.Sockets.SocketException e)
            {
                if (e.ErrorCode != 10060)
                {

                    delName();
                    udpClient.Close();
                    thread.Abort();
                    thread.Join(5000);
                    thread = null;
                }
                else if (e.ErrorCode == 10060) //если таймаут
                {
                    if (formclosed == false) Listener(); //форма не закрыта -> продолжаем приём
                    else
                    {
                        delName();
                        udpClient.Close();
                        thread.Abort();
                        thread.Join(5000);
                        thread = null;
                    }
                }

            }
        }

        //any funcs

        private void sendMessage(string mes)
        {
            string kek = name + ":" + mes;
            byte[] data = ToAes256(kek);
            udpClient.Send(data, data.Length, remote);
            textBox3.Text = "";

        }
        
        private void connectMessage()
        {
            string kek = "\t\t" + name + " connected to chat";
            byte[] data = ToAes256(kek);//new byte[256];
            //data = Encoding.Unicode.GetBytes(kek);
            udpClient.Send(data, data.Length, remote);
        }
        private void sendName()
        {
            string message = "%&nm" + name;
            byte[] data = ToAes256(message);
            udpClient.Send(data, data.Length, remote);
        }
        private void requestNames()
        {
            string kek = "r@q#s++";
            byte[] data = ToAes256(kek);
            udpClient.Send(data, data.Length, remote);
        }
        private void delName()
        {
            string kek = "d%e?l" + name;
            byte[] data = ToAes256(kek);
            udpClient.Send(data, data.Length, remote);
            discMessage();
        }
        private void discMessage()
        {
            string kek = "\t\t" + name + " disconnected from chat";
            byte[] data = ToAes256(kek);
            udpClient.Send(data, data.Length, remote);
        }
        


        //events funcs

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "") sendMessage(textBox3.Text);
            textBox3.Focus();
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textBox3.Text != "") sendMessage(textBox3.Text);
                textBox3.Focus();
                e.Handled = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            formclosed = true;
        }
        
        

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        int countChatSaves = 0;
        private void saveChatFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(alert)
            MessageBox.Show("Вы сохраняете файл в незащищенном режиме!", "Внимание", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            sf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DateTime thisFay = DateTime.Today;
            sf.FileName = "Chat #" + countChatSaves + " " + thisFay.ToString("d");
            if (sf.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sf.FileName);
                string text = textBox1.Text;
                sw.Write(text);
                sw.Close();
                
                MessageBox.Show("Чат сохранён в файл: " + sf.FileName);
                countChatSaves++;
            }

        }

        

        
        private void clearChatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Focus();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            textBox3.Focus();
        }


        static string key = "W1s)g+,ER012Bba@g89!!dwn56F8X0xr";
        static string IV = "4FghvE$##vBBnmZ!";
        public static byte[] ToAes256(string src)
        {

            Aes aes = Aes.Create();
            
            

            byte[] encrypted;
            ICryptoTransform crypt = aes.CreateEncryptor(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(IV));
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, crypt, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(src);

                    }
                }

                encrypted = ms.ToArray();
            }

            return encrypted.Concat(Encoding.ASCII.GetBytes(IV)).ToArray();
        }

        public static string FromAes256(byte[] shifr)
        {
            byte[] bytesIv = new byte[16];
            //Списываем соль
            byte[] mess = new byte[shifr.Length - 16];
            for (int i = shifr.Length - 16, j = 0; i < shifr.Length; i++, j++)
                bytesIv[j] = shifr[i];

            if (shifr == null || shifr.Length <= 0)
                throw new ArgumentNullException("shifr");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (Encoding.UTF8.GetString(bytesIv) == null || Encoding.ASCII.GetString(bytesIv).Length <= 0)
                throw new ArgumentNullException("IV");

             for (int i = 0; i < shifr.Length - 16; i++)
                mess[i] = shifr[i];
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.IV = bytesIv;
                aes.Key = Encoding.ASCII.GetBytes(key);
                string salt = Encoding.ASCII.GetString(bytesIv);
                string text = "";
                byte[] data = mess;
                ICryptoTransform crypt = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream(data))
                {
                    using (CryptoStream cs = new CryptoStream(ms, crypt, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            try
                            {
                                //Результат записываем в переменную text в виде исходной строки
                                text = sr.ReadToEnd();
                            }
                            catch
                            {
                                MessageBox.Show("Неправильное чтение данных!", "Ошибка", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            }
                        }
                    }
                }

                return text;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сохранитьВФайлзащищенныйРежимToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            sf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DateTime thisFay = DateTime.Today;
            sf.FileName = "Chat(s) #" + countChatSaves + " " + thisFay.ToString("d");
            if (sf.ShowDialog() == DialogResult.OK)
            {
                FileStream fsFileIn = File.OpenWrite(sf.FileName);
               
                string text = textBox1.Text;
                byte[] data = ToAes256(text);
                for (int i = 0; i < data.Length; i++) {fsFileIn.WriteByte(data[i]); }
                
                fsFileIn.Close();
                MessageBox.Show("Чат сохранён в файл: " + sf.FileName);
                countChatSaves++;
            }
        }

        private void открытьФайлзащищенныйРежимToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = System.Windows.Forms.DialogResult.OK;
            if (alert)
           result = MessageBox.Show("Перед открытием файла удостоверьтесь, что файл был сохранен в защищенном режиме. В противном случае файл может быть открыт некорректно.", "Предупреждение", MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                OpenFileDialog of = new OpenFileDialog();
                of.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                of.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
                if (of.ShowDialog() == DialogResult.OK)
                {
                          byte[] data = File.ReadAllBytes(of.FileName);
                    string text = FromAes256(data);
                    openFile open = new openFile(text);
                    open.Show();
                }
            }

        }

        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            of.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (of.ShowDialog() == DialogResult.OK)
            {
                StreamReader sw = new StreamReader(of.FileName);
                string text = sw.ReadToEnd();
                sw.Close();
                openFile open = new openFile(text);
                open.Show();
                
            }
        }

        private void чтоТакоеЗащищенныйРежимToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Защищенный режим – это защита данных путём их шифрования.\n\nЧат всегда работает в защищенном режиме!\n\nОткрытием файла в защищенном режиме является расшифровка ранее зашифрованных данных и их открытие.\nСохранением файла в защищенном режиме является шифровка данных и их сохранение в файле."
, "Помощь", MessageBoxButtons.OK,
                                 MessageBoxIcon.Asterisk);
        }

        private void показыватьУчастниковЧатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (показыватьУчастниковЧатаToolStripMenuItem.Checked)
            {
                label1.Visible = true;
                listUsers.Visible = true;
            }
            else
            {
                label1.Visible = false;
                listUsers.Visible = false;
            }
        }

        

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Narrow chat - это защищенный чат.\n Hello, Dubna 2019", "О программе", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
        }

        private void цветШрифтаЧатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = font.Font;
            }
        }
        bool alert = true;
        private void показыватьПредупрежденияБезопасностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!показыватьПредупрежденияБезопасностиToolStripMenuItem.Checked) alert = false;
            else alert = true;
        }
        
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) textBox3.Focus();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        

        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutInformationWindow aInfWin = new aboutInformationWindow(name);
            aInfWin.Show();
        }

        private void listUsers_DoubleClick(object sender, EventArgs e)
        {
            if (listUsers.SelectedIndex >= 0)
            {
                getInfoAboutUser getInfoWin = new getInfoAboutUser(listUsers.SelectedItem.ToString());
                getInfoWin.Show();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Вы хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    e.Cancel = true;
                else
                {
                    parentForm.Close();
                    e.Cancel = false;
                }
            }
            
        }

        private void ПолучитьНикиВсехУастниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string result="";
            string[] res=null;
            try
            {
               res = DataBasePostgres.read_all_nicks_participants().ToArray();
            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Ошибка соединения с базой данных");
            }
            for(int i = 0; i < res.Length; i++)
            {
                result += res[i] + " ";
            }
            MessageBox.Show(result);
        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ИсторияСообщенийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history_messages_Form his_mes_Form = new history_messages_Form();
            his_mes_Form.Show();
        }

        private void НововведенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("-Добавлены вход/регистрация\n-Добавлен вход через гостя\n-Теперь в истории сообщений по умолчанию сегодняшняя дата\n" +
                "-Исправлены некоторые шрифты\n-Доработка стабильности\n", "Нововведения");
        }

        private void ListUsers_Click(object sender, EventArgs e)
        {
            
        }

        private void ListUsers_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
        static string getInfoNick = null;
        private void ListUsers_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                listUsers.SelectedIndex = listUsers.IndexFromPoint(e.X, e.Y);
                getInfoNick = listUsers.SelectedItem.ToString();
            }
            if (listUsers.SelectedIndex >= 0)
            {
                fdsToolStripMenuItem.Enabled = true;
            }
            else
            {
                fdsToolStripMenuItem.Enabled = false;
            }
        }
        private void fds_context_info_click(object sender, MouseEventArgs e)
        {
            if (getInfoNick == null) getInfoNick = name;
            getInfoAboutUser getInfoUser = new getInfoAboutUser(getInfoNick);
            getInfoUser.Show();
        }

        private void FdsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
    




