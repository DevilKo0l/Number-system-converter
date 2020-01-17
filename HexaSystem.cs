using System;

namespace Number_system_converter
{
    class HexaSystem : INumericSystem
    {
        protected string hexa { get; set; }
        

        public HexaSystem(string newHexa)
        {
            hexa = newHexa;           
        }

        public string ToDecimal()
        {
            //int result = 0;
            //char[] hexArray = this.hexa.ToCharArray();            

            //for (int i = 2; i <hexArray.Length; i++)
            //{
            //    int power = (hexArray.Length-1) - i;
            //    if (char.IsLetter(hexArray[i]))
            //    {
            //        result += ((int)hexArray[i] - 55)*((int)Math.Pow(16,power));
            //    }
            //    else
            //    {
            //        result += ((int)Char.GetNumericValue(hexArray[i]) * ((int)Math.Pow(16, power)));
            //    }

            //}
            var convert = new DecimalSystem();
            return convert.AnySystemToDecimal(this.hexa, 16);
        }

        public string ToOcta()
        {
            var octaToDecimal = ToDecimal();
            var convert = new DecimalSystem(octaToDecimal);
            return convert.ToOcta();
        }

        public string ToBinary()
        {
            var octaToDecimal = ToDecimal();
            var convert = new DecimalSystem(octaToDecimal);
            return convert.ToOcta();
        }

        public string ToHex()
        {
            return this.hexa;
        }

        

    }
}
