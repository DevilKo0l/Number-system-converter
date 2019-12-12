using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_system_converter
{
    class DecimalSystem
    {
        protected string decima { get; private set; }
        protected int decimalBase { get; private set; }

        public DecimalSystem(string newDecimal)
        {
            decima = newDecimal;
            decimalBase = 10;
        }
        
    }
}
