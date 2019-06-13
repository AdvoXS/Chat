using System;
using System.Windows.Forms;

namespace chatick
{
    public partial class openFile : Form
    {
        string _text;
        public openFile(string text)
        {
            _text = text;
            
            InitializeComponent();
        }

        private void openFile_Activated(object sender, EventArgs e)
        {
            textBox1.Text = _text;
        }
    }
}
