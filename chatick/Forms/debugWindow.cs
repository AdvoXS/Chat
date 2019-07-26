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
    public partial class debugWindow : Form
    {
        public debugWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            List<string> getNicksList = null;
            try
            {
                getNicksList = DataBasePostgres.read_all_nicks_participants();
                foreach (var a in getNicksList)
                {
                    textBox1.Text += a + "\r\n";
                }
            }
            catch (Npgsql.PostgresException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            catch (Npgsql.NpgsqlException ex)
            {
                MessageBox.Show("Error: "+ ex.Message);
            }
            
        }
    }
}
