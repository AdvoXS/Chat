using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatick
{
    public partial class statusForm : Form
    {
        public statusForm()
        {
            InitializeComponent();
        }
        public void setlbl6(Color clr,string txt)
        {
            label6.Text = txt;
            label6.ForeColor = clr;
        }
        
        private void statusForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
