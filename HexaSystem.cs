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
            return convert.ToBinary();
        }

        public string ToHex()
        {
            return this.hexa;
        }
    }
}
