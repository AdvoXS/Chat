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
            if (textBox3.Text != "" && textBox3.Text.Length > 3 &&
                textBox4.Text != "" && textBox4.Text.Length > 5 &&
                   textBox5.Text != "" && textBox5.Text.Length > 2 &&
                textBox6.Text != "" && textBox6.Text.Length > 3 &&
                textBox7.Text != "") return true;

            else return false;
        }
        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void LogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //parentForm.close_Form();
        }
        DataBasePostgres dataBase;
        private void Button3_Click(object sender, EventArgs e)
        {
            if (check_valid_textboxes_tabSingUP())
            {
                dataBase = new DataBasePostgres();
                Security.SecurityClass securityClass = new Security.SecurityClass();
                string[] hash = securityClass.password_MD5Hash(textBox4.Text);
                string salt = hash[0];
                string hashPass = hash[1];
                if (!dataBase.registration_user(textBox3.Text, hashPass,salt, textBox5.Text, textBox6.Text, int.Parse(textBox7.Text)))
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
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            label13.Visible = true;
            button1.Enabled = false;
            label13.Update();
            Thread.Sleep(20);
            dataBase = new DataBasePostgres();
            string returnedString = dataBase.login_user(textBox1.Text, textBox2.Text);
            if (returnedString != "0"){
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
