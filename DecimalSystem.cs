using System;

namespace Number_system_converter
{
    class DecimalSystem : INumericSystem
    {
        protected string decima { get; private set; }        

        public DecimalSystem(string newDecimal)
        {
            decima = newDecimal;
            
        }
        public string ToDecimal()
        {
            return this.decima;
        }


        public string ToOcta()
        {
            string toOcta = DecimalToAnySystem(8);
            return '0' + toOcta;
        }

        public string ToBinary()
        {            
            string toBinary = DecimalToAnySystem(2);
            return toBinary;
        }

        public string ToHex()
        {            
            string toHex = DecimalToAnySystem(16);
            return "0x"+toHex;
        }

        public string DecimalToAnySystem(int systembase)
        {
            int remainder;
            string result = "";
            int decimalNum = int.Parse(this.decima);

            while (decimalNum > 0)
            {

                remainder = decimalNum % systembase;                
                decimalNum /= systembase;
                if (systembase == 16)
                {
                    if (remainder<10)
                    {
                        result = remainder + result;
                    }
                    else
                    {
                        result = (char)(55 + remainder) + result;
                    }
                }
                else
                {
                    result = remainder + result;
                }
                
            }

            return result;
        }

        public void show()
        {
            Console.WriteLine("In decimal: "+ToDecimal());
            Console.WriteLine("In binary: "+ToBinary());
            Console.WriteLine("In octal: "+ToOcta());
            Console.WriteLine("In hex: "+ToHex());   
        }
    }
}
