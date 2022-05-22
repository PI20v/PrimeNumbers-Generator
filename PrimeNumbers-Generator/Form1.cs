using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeNumbers_Generator
{
    public partial class Form1 : Form
    {
        Algorithm alg = new Algorithm();
        List<int> list = new List<int>();

        string message = "";

        static public int is_continue;

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = false;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy != true)
            {

                backgroundWorker1.RunWorkerAsync();
                button1.Text = "Остановить";
            }
            else
            {

                backgroundWorker1.CancelAsync();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    textBox2.Text = openFileDialog.FileName;

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    textBox3.Text = openFileDialog.FileName;

                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;


            if (!checkBox3.Checked && !checkBox1.Checked && !checkBox2.Checked)
            {
                button1.Text = "Сгенерировать";
                MessageBox.Show("Пожалуйста, поставьте галочку хоть где-то!");
                return;
            }

            
                
            int num_prime_numbers = 0;
            try
            {
                num_prime_numbers = Int32.Parse(textBox1.Text);
            }
            catch (Exception exc)
            {
                button1.Text = "Сгенерировать";
                MessageBox.Show("Введите корректное значения для количества простых чисел!");
                return;
            }

            
            if (!checkBox4.Checked && list.Count >= 4000)
            {
                
                is_continue = 3;
                Form2 new_form = new Form2("Вы уверены, что хотите начать генерацию заново? У вас сгенерировано " + list.Count + " чисел.");
                new_form.StartPosition = FormStartPosition.CenterScreen;

                new_form.ShowDialog();
                if (is_continue == 3 || is_continue == 0)
                {
                    
                    button1.Text = "Сгенерировать";
                    return;
                }
                    
            }
            
            if(checkBox2.Checked && num_prime_numbers > 750)
            {
                is_continue = 3;
                Form2 new_form = new Form2("Вы уверены, что хотите сгенерировать сложный лог? Для генерации 750 чисел потребуется 10 мегабайт .txt файла и эта величина будет расти с большой прогрессией.");
                new_form.StartPosition = FormStartPosition.CenterScreen;

                new_form.ShowDialog();
                if (is_continue == 3 || is_continue == 0)
                {

                    button1.Text = "Сгенерировать";
                    return;
                }
            }

            message = "";
            if (!checkBox4.Checked)
            {
                richTextBox1.Text = "";
                list.Clear();
            }

            string path_log = null;
            string path_num = null;
            int difficult = 0;
            RichTextBox rtb = null;
            if (checkBox1.Checked)
            {
                path_num = textBox2.Text;
            }
            if (checkBox2.Checked)
            {
                path_log = textBox3.Text;
                difficult = hScrollBar1.Value;
            }
            if (checkBox3.Checked)
            {
                rtb = richTextBox1;
            }
            message = alg.NeedPrimeNumbers(num_prime_numbers, backgroundWorker1, list, rtb, path_num, path_log, difficult);
            
            button1.Text = "Сгенерировать";

            if(message == "")
            {
                MessageBox.Show("Операция успешно завершена!");
            }
            else
            {
                MessageBox.Show(message);
            }

            label5.Text = "Чисел: " + list.Count.ToString();
        }



    }
}
