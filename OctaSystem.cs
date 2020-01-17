using System;

namespace Number_system_converter
{
    class OctaSystem : INumericSystem
    {
        protected string octa { get; private set; }       

        public OctaSystem(string newOcta)
        {
            octa = newOcta;            
        }

        public string ToDecimal()
        {
            var convert = new DecimalSystem();
            return convert.AnySystemToDecimal(this.octa, 8);

        }

        public string ToOcta()
        {
            return this.octa;
        }

        public string ToBinary()
        {
            var octaToDecimal = ToDecimal();
            var convert = new DecimalSystem(octaToDecimal);
            return convert.ToBinary();
        }

        public string ToHex()
        {
            var octaToDecimal = ToDecimal();
            var convert = new DecimalSystem(octaToDecimal);
            return convert.ToHex();
        }

    }
}
