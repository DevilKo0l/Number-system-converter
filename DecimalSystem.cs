using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_system_converter
{
    class DecimalSystem : INumericSystem
    {
        protected string decima { get; private set; }
        protected int decimalBase { get; private set; }

        public DecimalSystem(string newDecimal)
        {
            decima = newDecimal;
            decimalBase = 10;
        }
        public string ToDecimal()
        {
            return this.decima;
        }


        public string ToOcta()
        {
            int remainder;
            string octa = "";
            int decimalNum = int.Parse(this.decima);

            while (decimalNum > 0)
            {
                remainder = decimalNum % 8;
                decimalNum /= 8;


                octa = remainder.ToString() + octa;
            }

            return octa;
        }

        public string ToBinary()
        {
            int remainder;
            string binary = "";
            int decimalNum = int.Parse(this.decima);

            while (decimalNum > 0)
            {
                remainder = decimalNum % 2;
                decimalNum /= 2;


                binary = remainder.ToString() + binary;
            }

            return binary;
        }

        public string ToHex()
        {
            int remainder;
            string hexa = "";
            int decimalNum = int.Parse(this.decima);

            while (decimalNum > 0)
            {
                
                remainder = decimalNum % 16;
                if (remainder<10)
                {
                    hexa = remainder + hexa;
                }
                else
                {
                    hexa = (char)(remainder+65) + hexa;
                }
                decimalNum /= 16;
                
            }

            return hexa;
        }

        public void show()
        {
            Console.WriteLine(ToBinary());
            Console.WriteLine(ToHex());
            Console.WriteLine(ToOcta());
            Console.WriteLine(ToDecimal());
        }
    }
}
