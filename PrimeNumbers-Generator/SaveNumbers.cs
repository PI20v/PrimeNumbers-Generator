using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PrimeNumbers_Generator
{
    class SaveNumbers
    {
        public int saveNumbers(String path, RichTextBox rtb)
        {
            try
            {
                File.WriteAllText(path, rtb.Text);
                return 0;
            }
            catch (Exception exc)
            {
                return 1;
            }
        }

    }
}
