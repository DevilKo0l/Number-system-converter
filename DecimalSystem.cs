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
            double remainder;
            string result = "";            
            int intPart = (int)double.Parse(this.decima);
            double frationalPart = double.Parse(this.decima)-intPart;

            if (intPart == 0)
            {
                result += "0";
            }
            else
            {
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
                }
            }
            
            if (frationalPart != 0)
            {
                result += '.';
                while (frationalPart > 0)
                {
                    frationalPart = frationalPart * systembase;
                    
                    if (systembase==16)
                    {
                        _ = ((int)frationalPart < 10) ? result += (int)frationalPart  : result += (char)(55 + (int)frationalPart) ;
                    }
                    else
                    {
                        result += (int)frationalPart;
                    }                    
                    frationalPart = frationalPart - Math.Floor(frationalPart);


                }
            }
            return result;
        }

        public string AnySystemToDecimal(string number, int systemBase)
        {
            string[] splitNumber = number.Split('.');
            char[] intPart = splitNumber[0].ToCharArray();            
            
            int digit=0;
            int exponent = 0;
            double sum = 0;
            string result = "";
            
            for (int i = intPart.Length-1; i >-1; i--)
            {
                bool isDigit = int.TryParse(intPart[i].ToString(), out digit);
                if (isDigit==true)
                {
                    sum += digit * (int)Math.Pow(systemBase, exponent);
                }
                else
                {                    
                    if (i==1)
                    {
                        break;
                    }
                    else
                    {
                        sum += ((int)char.ToUpper(intPart[i]) - 55) * ((int)Math.Pow(16, exponent));
                    }
                    
                }
                exponent++;
            }
            
            if (splitNumber.Length==1)
            {
                return sum.ToString();
            }
            else
            {
                exponent = -1;
                double sumFraction = 0;
                char[] fractionalPart = splitNumber[1].ToCharArray();
                for (int i = 0; i < fractionalPart.Length; i++)
                {
                    bool isDigit = int.TryParse(fractionalPart[i].ToString(), out digit);
                    if (isDigit == true)
                    {
                        sumFraction += digit * (int)Math.Pow(systemBase, exponent);
                    }
                    else
                    {

                        sumFraction += ((int)char.ToUpper(fractionalPart[i]) - 55) * Math.Pow(16, exponent);

                    }
                    exponent--;
                }

                sum += sumFraction;
                result += sum;
            }

            return sum.ToString();
        }
    }
} 
