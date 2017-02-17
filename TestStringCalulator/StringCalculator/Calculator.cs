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
            var result = 0;
            if (p.Contains(",")) {
                var numbers = p.Split(',');
                foreach (var n in numbers)
                {
                    result += int.Parse(n);
                }
                return result;
            }
            return Int32.Parse(p);
        }
    }
}
