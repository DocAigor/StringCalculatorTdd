using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public interface IHistoryCalculator
    {
        void Save(int number);
    }
}
