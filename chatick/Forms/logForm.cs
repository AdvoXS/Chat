using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
namespace chatick
{
    public partial class logForm : Form
    {
        Form1 parentForm;
        public logForm()
        {
            InitializeComponent();
        }
        private bool check_valid_textboxes_tabSingUP()
        {
            if (textBox3.Text != "" && textBox3.Text.Length >= 3 &&
                textBox4.Text != "" && textBox4.Text.Length > 5 &&
                   textBox5.Text != "" && textBox5.Text.Length > 2 &&
                textBox6.Text != "" && textBox6.Text.Length > 3 &&
                textBox7.Text != "") return true;

            else
            {
                Logs.LogClass log = new Logs.LogClass("System", "Ввод данных регистрации. Неверный ввод полей");
                MessageBox.Show("Неверный ввод полей.\nЛогин - от 3-х символов\nПароль от 6-ти симолов\nИмя от 2-х символов\nФамилия от 3-х символов\nВозраст только числом!");
                return false;
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            //   MessageBox.Show(System.Diagnostics.Process.GetCurrentProcess().Threads.Count.ToString());
            try
            {

                if (check_valid_textboxes_tabSingUP())
                {
                    Security.SecurityClass securityClass = new Security.SecurityClass();
                    string[] hash = securityClass.password_MD5Hash(textBox4.Text);
                    string salt = hash[0];
                    string hashPass = hash[1];
                    try
                    {
                        if (!DataBasePostgres.registration_user(textBox3.Text, hashPass, salt, textBox5.Text, textBox6.Text, int.Parse(textBox7.Text)))
                        {
                            label10.Text = "Такой пользователь уже существует!";
                            label10.Visible = true;
                        }
                        else
                        {
                            label10.Visible = true;
                            label10.Text = "Вы успешно зарегистрированы!";
                            label10.ForeColor = Color.Green;
                            button3.Enabled = false;
                        }
                    }
                    catch (Npgsql.PostgresException ex)
                    {
                        MessageBox.Show("Ошибка соединения с базой данных");
                        Logs.LogClass logClass = new Logs.LogClass("DB", "Отправка данных регистрации пользвателя. Ошибка postgres: " + ex.Message);
                    }
                    catch (Npgsql.NpgsqlException ex)
                    {
                        MessageBox.Show("Ошибка соединения с базой данных");
                        Logs.LogClass logClass = new Logs.LogClass("DB", "Отправка данных регистрации пользвателя. Ошибка связи: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неизвестная ошибка");
                        Logs.LogClass logClass = new Logs.LogClass("System", "Имя объекта вызвавшего ошибку: " + ex.Source + " Ошибка " + ex.Message);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Возраст должен быть числом!");
            }
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            label13.Visible = true;
            button1.Enabled = false;
            string returnedString="";
            label13.Update();
            Thread.Sleep(20);
            try
            {
                returnedString = DataBasePostgres.login_user(textBox1.Text, textBox2.Text);
            }
            catch (Npgsql.PostgresException ex)
            {
                MessageBox.Show("Ошибка соединения с базой данных");
                Logs.LogClass logClass = new Logs.LogClass("DB", "Отправка данных авторизации пользвателя. Ошибка postgres: " + ex.Message);
            }
            catch (Npgsql.NpgsqlException ex)
            {
                MessageBox.Show("Ошибка соединения с базой данных");
                Logs.LogClass logClass = new Logs.LogClass("DB", "Отправка данных авторизации пользвателя. Ошибка связи: " + ex.Message);
            }
            if (returnedString != "0" && returnedString!="")
            {
                parentForm = new Form1(this, returnedString);
                parentForm.Show();
                this.Hide();
            }
            else
            {
                label13.Visible = false;
                button1.Enabled = true;
                label11.Visible = true;
            }
        }

        private void Label12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ваши сообщения  не сохранятся и часть функций будет недоступна!\nВы точно хотите войти, как гость?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Random rand = new Random();
                int random = rand.Next(1, 1000);
                parentForm = new Form1(this, "guest" + random);
                parentForm.Show();
                this.Hide();
            }
            
        }
    }
}
