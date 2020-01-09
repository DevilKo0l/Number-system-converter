using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Number_system_converter
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DecimalSystem newDec = new DecimalSystem("8271");
            //BinarySystem newBinary = new BinarySystem("10101010");
            //OctaSystem newOcta = new OctaSystem("0123");

            Show("12346");

            

        }



        static INumericSystem WhatBase(string numInput)
        {
            //bool invalidBase = false;


            if (isNumeric(numInput) == true)
            {
                if (IsOctal(numInput) == true)
                {
                    Console.WriteLine("Octa detected");
                    return new OctaSystem(numInput);               

                }
                else if(IsBinary(numInput) == true)
                {
                    Console.WriteLine("binary detected");
                    return new BinarySystem(numInput);
                }
                else
                {
                    Console.WriteLine("Decimal detected");
                    return new DecimalSystem(numInput);
                }
            }
            else 
            {
                Console.WriteLine("hexa detected");
                return new HexaSystem(numInput);
            }
            
        }

       

        static public bool isNumeric(string inputNumber)
        {
            return int.TryParse(inputNumber, out int num);
        }

        static public bool IsHex(string numInput)
        {
            //start with 0x or 0X, and @"\A\b^(0[xX])?[0-9a-fA-F]+\b\Z"
            return Regex.IsMatch(numInput, @"\A\b^(0[xX])?[0-9a-fA-F]+\b\Z");
        }


        static public bool IsOctal(string numInput)
        {
            //return Regex.IsMatch(numInput, @"\A\b^([0-7])+\b\Z");
            return Regex.IsMatch(numInput, @"^0[1-7][0-7]{0,6}$");

        }
        static public bool IsBinary(string numInput)
        {
            bool checkBinary = true;            
            foreach (var num in numInput)
            {
                if (!(int.Parse(num.ToString())==1 || int.Parse(num.ToString())==0))
                {
                    checkBinary = false;
                    break;
                }
            }
            return checkBinary;
        }

        static void Show(string input)
        {
            var numBase = WhatBase(input);
            Console.WriteLine("In decimal: " + numBase.ToDecimal());
            Console.WriteLine("In binary: " + numBase.ToBinary());
            Console.WriteLine("In octal: " + numBase.ToOcta());
            Console.WriteLine("In hex: " + numBase.ToHex());

        }

    }   
        
    
}
