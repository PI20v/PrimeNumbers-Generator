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
        SaveNumbers sn = new SaveNumbers();
        bool is_need_numbers = false;
        
        string message = "";
        
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = false;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ref int xRef = ref x; нужно передавать по ссылке


            if (backgroundWorker1.IsBusy != true)
            {
                is_need_numbers = true;
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
                button1.Text = "Остановить";
            }
            else
            {
                is_need_numbers = false;
                backgroundWorker1.CancelAsync();
                //button1.Text = "Сгенерировать";
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
                MessageBox.Show("Пожалуйста, поставьте галочку хоть где-то!");
                return;
            }

            message = "";
            richTextBox1.Text = "";
            List<int> list = new List<int>();

            int num_prime_numbers = 0;
            try
            {
                num_prime_numbers = Int32.Parse(textBox1.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Введите корректное значения для количества простых чисел!");
                return;
            }

            if (checkBox2.Checked)
            {
                list = new List<int>(alg.GetPrimeNumbersAndLog(num_prime_numbers, hScrollBar1.Value, textBox3.Text));
                if (list.Count != 0)
                {
                    message += "Лог успешно сохранен по адресу " + textBox3.Text + "!\n";
                }
                else
                {
                    message += "Лог не удалось сохранить по адресу " + textBox3.Text + "!\n";
                }
            }
            if (checkBox3.Checked)
            {
                if (list.Count == 0)
                    list = new List<int>(alg.GetPrimeNumbers(Int32.Parse(textBox1.Text)));
                for (int i = 0; i < list.Count; i++)
                {
                    richTextBox1.Text += list[i] + " ";
                }
            }

            if (checkBox1.Checked)
            {
                if (list.Count == 0)
                    list = new List<int>(alg.GetPrimeNumbers(Int32.Parse(textBox1.Text)));
                int is_problem = sn.saveNumbers(textBox2.Text, list);
                if (is_problem == 0)
                {
                    message += "Числа успешно сохранены в файл по пути " + textBox2.Text + "!";
                }
                else
                {
                    message += "Ошибка!!! Числа не удалось сохранить в файл по пути " + textBox2.Text + "!";
                }
            }

            if (checkBox1.Checked || checkBox2.Checked)
                MessageBox.Show(message);
            worker.ReportProgress(100);
        }


        // This event handler deals with the results of the background operation.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error: " + e.Error.Message);
            }
            else
            {
                //resultLabel.Text = "Done!";
            }
            button1.Text = "Сгенерировать";
        }
    }
}
