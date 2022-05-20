using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PrimeNumbers_Generator
{
    class SaveNumbers
    {
        public int saveNumbers(String path, List<int> list)
        {

            try
            {
                File.WriteAllText(path, "");
                for (int i = 0; i < list.Count; i++)
                {
                    
                    File.AppendAllText(path, list[i].ToString() + " ");
                }
                
                return 0;
            }
            catch (Exception exc)
            {
                return 1;
            }
        }

    }
}
