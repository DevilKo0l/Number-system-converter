using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Number_system_converter
{
    class BinarySystem
    {
        protected int binary { get; private set; }
        protected int binaryBase { get; private set; }

        public BinarySystem(int newBinary)
        {
            binary = newBinary;
            binaryBase = 2;
        }

        public int binaryToDecimal()
        {
            
            int result = 0;
            int i = 0;
            do
            {
                int rem = this.binary % 10;
                result = result + rem * (int)Math.Pow(2,i);
                i++;
                this.binary = this.binary / 10;
            } while (this.binary > 0);
            return result;  
        }
    }
}
