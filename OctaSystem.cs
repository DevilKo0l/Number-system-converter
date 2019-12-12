using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_system_converter
{
    class OctaSystem
    {
        protected int octa { get; private set; }
        protected int octaBase {get; private set;}

        public OctaSystem(int newOcta)
        {
            octa = newOcta;
            octaBase = 8;
        }

        public int OctaToDecimal()
        {
            int result = 0;
            int i = 0;
            do
            {
                int rem = this.octa % 10;
                result = result + rem * (int)Math.Pow(8, i);
                i++;
                this.octa = this.octa / 10;
            } while (this.octa > 0);
            return result;
        }
    }
}
