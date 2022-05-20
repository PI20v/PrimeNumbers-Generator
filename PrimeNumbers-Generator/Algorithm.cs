using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PrimeNumbers_Generator
{

    
    class Algorithm
    {
        List<int> primeNumbers = new List<int>();
        public List<int> GetPrimeNumbers(int num)
        {
            primeNumbers.Clear();

            bool is_prime;
            int cur_num = 0;
            for(int i=2; cur_num < num; i++)
            {
                is_prime = true;
                for(int j = 0; j < primeNumbers.Count; j++)
                {
                    if(i % primeNumbers[j] == 0)
                    {
                        is_prime = false;
                        break;
                    }
                }

                if(is_prime)
                {
                    primeNumbers.Add(i);
                    cur_num++;
                }
            }

            return primeNumbers;
        }

        public List<int> GetPrimeNumbersAndLog(int num, int difficult, string path)
        {
            // difficult: [1;2]
            File.WriteAllText(path, "");

            primeNumbers.Clear();
            try
            {
                bool is_prime;
                int cur_num = 0;
                for (int i = 2; cur_num < num; i++)
                {
                    is_prime = true;
                    for (int j = 0; j < primeNumbers.Count; j++)
                    {
                        if (difficult > 1) File.AppendAllText(path, "Testing number " + i.ToString() + "...\n");
                        if (i % primeNumbers[j] == 0)
                        {
                            if (difficult > 1) File.AppendAllText(path, "Number " + i.ToString() + " is divided by " + primeNumbers[j].ToString() + "...\n");
                            File.AppendAllText(path, "Number " + i.ToString() + " is not prime number.\n");
                            is_prime = false;
                            break;
                        }
                        if (difficult > 1) File.AppendAllText(path, "Number " + i.ToString() + " is not divided by " + primeNumbers[j].ToString() + "...\n");
                    }

                    if (is_prime)
                    {
                        File.AppendAllText(path, "Number " + i.ToString() + " is prime number.\n");
                        primeNumbers.Add(i);
                        cur_num++;
                    }
                    if (difficult > 1) File.AppendAllText(path, "Testing number " + i.ToString() + " completed.\n");
                }
            }
            catch (Exception ecx)
            {

            }

            return primeNumbers;
        }
    }
}
