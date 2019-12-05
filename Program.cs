using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_system_converter
{
    class Program
    {
        static void Main(string[] args)
        {


            
            
        }

        static public string DecimalToAnySystem(int numDecimal, int systembase)
        {
            int remainder;            
            string binary = "";
            

            while(numDecimal>0)
            {
                remainder = numDecimal % systembase;
                numDecimal /= systembase;
                

                binary = remainder.ToString() + binary;
            }

            return binary;
        }
    }
}
