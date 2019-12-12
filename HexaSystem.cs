using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_system_converter
{
    class HexaSystem : INumericSystem
    {
        protected string hexa { get; set; }
        protected int hexaBase { get; set; }

        public HexaSystem(string newHexa)
        {
            hexa = newHexa;
            hexaBase = 16;
        }

        public string ToDecimal()
        {
            int result = 0;
            char[] hexArray = this.hexa.ToCharArray();
            Array.Reverse(hexArray);
            for (int i = 0; i < hexArray.Length; i++)
            {
                if (char.IsLetter(hexArray[i]))
                {
                    result += ((int)hexArray[i] - 55)*(16^i);
                }
                else
                {
                    result += hexArray[i] * (16^i);
                }
                
            }

            return result.ToString();
        }

        public string ToOcta()
        {
            return "ss";
        }

        public string ToBinary()
        {
            return "ddd";
        }

        public string ToHex()
        {
            return "ddd";
        }

    }
}
