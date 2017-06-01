using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class _about_form : Form
    {

        public _about_form()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.ro");
        }
    }
}
