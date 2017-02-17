using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public int Resolve(string p)
        {
            if (string.IsNullOrEmpty(p)) return 0;
            return Int32.Parse(p);
        }
    }
}
