using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PrimeNumbers_Generator
{

    
    class Algorithm
    {
        List<int> primeNumbers = new List<int>();

        public string NeedPrimeNumbers(int num, BackgroundWorker bw, List<int> previous, RichTextBox rtb, string path_num, string path_log, int difficult)
        {
            string message = "";
            if (path_num != null && !File.Exists(path_num))
            {
                message += "Ошибка! Файла для записи чисел не найдено!";
                return message;
            }
            if (path_log != null && !File.Exists(path_log))
            {
                message += "Ошибка! Файла для записи лога не найдено!";
                return message;
            }

            if(path_num != null && previous.Count == 0)
            {
                File.WriteAllText(path_num, "");
            }
            if(path_log != null && previous.Count == 0)
            {
                File.WriteAllText(path_log, "");
            }

            bool is_prime;
            int i = 2;
            int cur_num = 0;
            if(previous.Count != 0)
            {
                cur_num = previous.Count;
                i = previous[previous.Count - 1] + 1;
            }
            
            for (; cur_num < num; i++)
            {
                
                if (bw.CancellationPending == true)
                {
                    is_prime = false;
                    break;
                }

                is_prime = true;
                if (path_log != null && difficult > 1) File.AppendAllText(path_log, "Testing number " + i.ToString() + "...\n");
                for (int j = 0; j < previous.Count; j++)
                {
                    if (bw.CancellationPending == true)
                    {
                        break;
                    }

                    if (i % previous[j] == 0)
                    {
                            
                        if (path_log != null && difficult > 1) File.AppendAllText(path_log, "Number " + i.ToString() + " is divided by " + previous[j].ToString() + "...\n");
                        if(path_log != null) File.AppendAllText(path_log, "Number " + i.ToString() + " is not prime number.\n");
                        is_prime = false;
                        break;
                    }
                    if (path_log != null && difficult > 1) File.AppendAllText(path_log, "Number " + i.ToString() + " is not divided by " + previous[j].ToString() + "...\n");
                }

                if (bw.CancellationPending == true)
                {
                    break;
                }

                if (is_prime)
                {
                    if(path_log != null) File.AppendAllText(path_log, "Number " + i.ToString() + " is prime number.\n");
                    previous.Add(i);
                    if(rtb != null)
                    {
                        rtb.Text += i.ToString() + " ";
                    }
                    if(path_num != null)
                    {
                        File.AppendAllText(path_num, i.ToString() + " ");
                    }
                    cur_num++;
                }
            }

            if(bw.CancellationPending == true)
            {
                message += "Операция прервана!";
            }

            return message;
        }
        
    }
}
