using System;
using System.Windows.Forms;
using System.Drawing;
namespace chatick
{
    public partial class logForm : Form
    {
        Form1 parentForm;
        public logForm(Form1 p)
        {
            InitializeComponent();
            parentForm = p;
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
            //parentForm.close_Form();
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
                if (!dataBase.registration_user(textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, int.Parse(textBox7.Text)))
                {
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
            dataBase = new DataBasePostgres();
            string returnedString = dataBase.login_user(textBox1.Text, textBox2.Text);
            if (returnedString != "0"){
                parentForm.setName(returnedString);
                parentForm.Show();
                this.Hide();
            }
            else
            {
                label11.Visible = true;
            }
        }

       
    }
}
