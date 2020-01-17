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
            var convert = new DecimalSystem();
            return convert.AnySystemToDecimal(this.binary, 2);            
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
