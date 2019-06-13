using System;
using System.Windows.Forms;
using System.Threading.Tasks;
namespace chatick
{
    
    public partial class aboutInformationWindow : Form
    {
        
        string Nick;
        public aboutInformationWindow(string nick)
        {
            InitializeComponent();
            Nick = nick;
        }
        async void bdConnectPostgr_async()
        {
            DataBasePostgres dataBase = new DataBasePostgres();
            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        dataBase.create_information_about_user_async(Nick,
                         textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));
                        MessageBox.Show("Информация добавлена!");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Введены некорректные данные!");
                    }
                }
                );
                
            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Ошибка при добавлении информации. Удостоверьтесь, в правильности введенных данных!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // bdConnect();
            bdConnectPostgr_async();
        }
    }
   
}
