using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_system_converter
{
    class OctaSystem : INumericSystem
    {
        protected string octa { get; private set; }
        protected int octaBase {get; private set;}

        public OctaSystem(string newOcta)
        {
            octa = newOcta;
            octaBase = 8;
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
            return "dddd";
        }

        public string ToBinary()
        {
            return "dddd";
        }

        public string ToHex()
        {
            return "dddd";
        }
    }
}
