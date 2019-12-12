using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Number_system_converter
{
    class BinarySystem : INumericSystem
    {
        protected string binary { get; private set; }
        protected int binaryBase { get; private set; }

        public BinarySystem(string newBinary)
        {
            binary = newBinary;
            binaryBase = 2;
        }

        public string ToDecimal()
        {
            
            int result = 0;
            int i = 0;
            int binaryNum = int.Parse(this.binary);
            do
            {
                int rem = binaryNum % 10;
                result = result + rem * (int)Math.Pow(2,i);
                i++;
                binaryNum = binaryNum / 10;
            } while (binaryNum > 0);
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
            //int result = 0;
            //int i = 0;
            //do
            //{
            //    int rem = this.binary % 10;
            //    result = result + rem * (int)Math.Pow(2, i);
            //    i++;
            //    this.binary = this.binary / 10;
            //} while (this.binary > 0);
            //return result;

            return "sss";
        }
    }
}
