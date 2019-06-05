using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
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
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "\tЗагружаем данные с сервера...";

            Thread thread = new Thread(() => {
                DataBasePostgres dataBase = new DataBasePostgres();

                List<string> historyMes = dataBase.get_history_message_to_view(dateTimePicker1.Text, dateTimePicker2.Text);
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
            
            thread.Start();
        }

        private void Label1_DoubleClick(object sender, EventArgs e)
        {
            debugWindow debugger = new debugWindow();
            debugger.Show();
        }
    }
}
