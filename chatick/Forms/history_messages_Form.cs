using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
namespace chatick
{
    public partial class history_messages_Form : Form
    {
        public history_messages_Form()
        {
            InitializeComponent();
            set_Properties_Elements();
        }
        void set_Properties_Elements()
        {
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Value = DateTime.Now;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "\tЗагружаем данные с сервера...";
            List<string> historyMes = null;
            Task task = new Task(() => {
                DataBasePostgres dataBase = new DataBasePostgres();
                try
                {
                    historyMes = dataBase.get_history_message_to_view(dateTimePicker1.Text, dateTimePicker2.Text);
                }
                catch (Npgsql.PostgresException ex)
                {
                    MessageBox.Show("Ошибка соединения с базой данных");
                    Logs.LogClass logClass = new Logs.LogClass("DB", "Получение истории сообщений. Ошибка postgres: " + ex.MessageText);
                }
                catch (Npgsql.NpgsqlException ex)
                {
                    MessageBox.Show("Ошибка соединения с базой данных");
                    Logs.LogClass logClass = new Logs.LogClass("DB", "Получение истории сообщений. Ошибка связи: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неизвестная ошибка");
                    Logs.LogClass logClass = new Logs.LogClass("System", "Имя объекта вызвавшего ошибку: " + ex.Source + " Ошибка " + ex.Message);
                }
                if (historyMes.Count > 0)
                {
                    Action messNullAction = () => textBox1.Text = "";
                    textBox1.Invoke(messNullAction);

                    for (int i = 0; i < historyMes.Count; i++)
                    {
                        Action messAddRowAction = () => textBox1.Text += historyMes[i] + "\r\n";
                        textBox1.Invoke(messAddRowAction);
                    }
                }
                else
                {
                    Action messNullAction = () => textBox1.Text = "\tДанных о переписках на данный период нет.";
                    textBox1.Invoke(messNullAction);
                }
            });
            
            task.Start();
        }

        private void Label1_DoubleClick(object sender, EventArgs e)
        {
            debugWindow debugger = new debugWindow();
            debugger.Show();
        }
    }
}
