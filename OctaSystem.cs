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
            int result = 0;
            int i = 0;
            int octaNum = int.Parse(this.octa);
            do
            {
                int rem = octaNum % 10;
                result = result + rem * (int)Math.Pow(8, i);
                i++;
                octaNum = octaNum / 10;
            } while (octaNum > 0);
            return result.ToString();
        }

        public string ToOcta()
        {
            return this.octa;
        }

        public string ToBinary()
        {
            var octaToDecima = ToDecimal();
            var converter = new DecimalSystem(octaToDecima);
            return converter.ToBinary();
        }

        public string ToHex()
        {
            var octaToDecima = ToDecimal();
            var converter = new DecimalSystem(octaToDecima);
            return converter.ToHex();
        }

    }
}
