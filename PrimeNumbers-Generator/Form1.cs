﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeNumbers_Generator
{
    public partial class Form1 : Form
    {
        Algorithm alg = new Algorithm();
        SaveNumbers sn = new SaveNumbers();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            List<int> list = new List<int>(alg.GetPrimeNumbers(Int32.Parse(textBox1.Text)));
            for(int i=0; i<list.Count; i++)
            {
                richTextBox1.Text += list[i] + " ";
            }

            if (checkBox1.Checked)
            {
                int is_problem = sn.saveNumbers(textBox2.Text, richTextBox1);
                if(is_problem == 0)
                {
                    MessageBox.Show("Числа успешно сохранены в файл по пути " + textBox2.Text + "!");
                }
                else
                {
                    MessageBox.Show("Ошибка!!! Числа не удалось сохранить в файл по пути " + textBox2.Text + "!");
                }
            }
        }
    }
}
