using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        private IHistoryCalculator historyCalculator;

        public Calculator() { }

        public Calculator(IHistoryCalculator historyCalculator)
        {
            this.historyCalculator = historyCalculator;
        }
        public int Resolve(string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                if (historyCalculator != null) historyCalculator.Save(0);
                return 0;
            }
            var outRes = 0;
            var result = 0;
            if (p.Contains(","))
            {
                var numbers = p.Split(',');
                foreach (var n in numbers)
                {

                    if (int.TryParse(n, out outRes))
                        result += outRes;
                }
                if (historyCalculator != null) historyCalculator.Save(result);
                return result;
            }
            if (!int.TryParse(p, out outRes))
                outRes = 0;

            if (historyCalculator != null) historyCalculator.Save(outRes);
            return outRes;
        }
    }
}
