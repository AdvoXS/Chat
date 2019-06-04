using System;
using System.Windows.Forms;

namespace chatick
{
    public partial class setupForm : Form
    {
        Form1 form;
        public setupForm(Form1 p_form)
        {
            InitializeComponent();
             form = p_form;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.setName(textBox1.Text);
            this.Close();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string tmp = textBox1.Text;
            if (tmp.Length >= 3)
            {
                button1.Enabled = true;
                label2.Visible = false;
            }
            else {
                button1.Enabled = false;
                label2.Visible = true;
            }
        }

        private void setupForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool niceNick = true;
            if(e.KeyChar == 13)
            {
                for(int i = 0; i < textBox1.Text.Length; i++)
                {
                    if (textBox1.Text[i] == ':') niceNick = false;
                }
                if (niceNick)
                {
                    form.setName(textBox1.Text);
                    this.Close();
                }
            }
        }
    }
}
