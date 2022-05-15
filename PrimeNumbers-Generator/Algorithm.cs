using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumbers_Generator
{

    
    class Algorithm
    {
        List<int> primeNumbers = new List<int>();
        public List<int> GetPrimeNumbers(int end)
        {
            primeNumbers.Clear();

            bool is_prime;
            for(int i=2; i<= end; i++)
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
                }
            }

            return primeNumbers;
        }

    }
}
