﻿using System;
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
        DataBasePostgres dataBase;
        public debugWindow()
        {
            InitializeComponent();
             dataBase = new DataBasePostgres();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            List<string> getNicksList = dataBase.read_all_nicks_participants();
            foreach(var a in getNicksList)
            {
                textBox1.Text += a+"\r\n";
            }
        }
    }
}