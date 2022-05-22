using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrimeNumbers_Generator
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string mes)
        {
            InitializeComponent();
            label1.Text = mes;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.is_continue = 1;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.is_continue = 0;
            this.Close();
        }
    }
}
