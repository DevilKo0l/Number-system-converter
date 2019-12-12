using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_system_converter
{
    interface INumericSystem
    {
        string ToDecimal();
        string ToOcta();
        string ToBinary();
        string ToHex();
    }
}
