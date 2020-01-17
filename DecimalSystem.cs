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
        public DecimalSystem()
        {

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
                    while (frationalPart > 0)
                    {
                        frationalPart = frationalPart * systembase;
                        result += (int)frationalPart;
                        frationalPart = frationalPart - Math.Floor(frationalPart);
                    }

                }

            }
            return result;
        }

        public string AnySystemToDecimal(string number, int systemBase)
        {
            char[] digitArray = number.ToCharArray();
            int digit;
            int exponent = 0;
            int result = 0;
            
            for (int i = digitArray.Length-1; i >-1; i--)
            {
                bool isDigit = int.TryParse(digitArray[i].ToString(), out digit);
                if (isDigit==true)
                {
                    result += digit * (int)Math.Pow(systemBase, exponent);
                }
                else
                {                    
                    if (i==1)
                    {
                        break;
                    }
                    else
                    {
                        result += ((int)char.ToUpper(digitArray[i]) - 55) * ((int)Math.Pow(16, exponent));
                    }
                    
                }
                exponent++;
            }
            return result.ToString();
        }
    }
} 
