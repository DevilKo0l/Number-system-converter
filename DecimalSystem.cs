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
            int intPart = (int)double.Parse(this.decima);
            double frationalPart = double.Parse(this.decima)-intPart;
            
            
            
            while (intPart > 0)
            {
                remainder = intPart % systembase;
                intPart /= systembase;


                if (systembase == 16)
                {
                    _ = (remainder < 10) ? result = remainder + result : result = (char)(55 + remainder) + result;
                }
                else
                {
                    result = remainder + result;
                }

                if (frationalPart != 0)
                {
                    result += '.';
                    while (frationalPart>0)
                    {
                        frationalPart = frationalPart * systembase;
                        result += (int)frationalPart;
                        frationalPart = frationalPart - Math.Floor(frationalPart);
                    }

                }

            }

            return result;
        }
        
    }
} 
