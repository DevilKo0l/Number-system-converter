using System;


namespace Number_system_converter
{
    class BinarySystem : INumericSystem
    {
        protected string binary { get; private set; }        

        public BinarySystem(string newBinary)
        {
            binary = newBinary;
            
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
            var binaryToDecimal = ToDecimal();
            var convert = new DecimalSystem(binaryToDecimal);
            return convert.ToOcta();
            
        }

        public string ToBinary()
        {
            return this.binary;
        }

        public string ToHex()
        {

            var binaryToDecimal = ToDecimal();
            var convert = new DecimalSystem(binaryToDecimal);
            return convert.ToHex();            
        }
    }
}
