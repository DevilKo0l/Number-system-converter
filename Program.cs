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

            //Console.WriteLine(WhatBase("0x7G"));

            //string n = "134654";
            //Console.WriteLine(n[0]);
            //BinarySystem firstnum = new BinarySystem(101101);
            //Console.WriteLine(firstnum.binaryToDecimal());

            //OctaSystem firstocta = new OctaSystem(0430);
            //Console.WriteLine(firstocta.OctaToDecimal());

            HexaSystem textHexa = new HexaSystem("1A2C");
            Console.WriteLine(textHexa.HexaToDecimal());


            //Console.WriteLine(1/10);
        }

        static public string WhatBase(string numInput)
        {
            
            if(isNumeric(numInput)==true)
            {
                if (PrefixStartWith0(numInput)==true)
                {
                    if (IsOctal(numInput)==true)
                    {
                        return "This is octa";
                    }
                    return "invalid input";
                }
                return "This is decimal";

            }
            else
            {
                if (IsHex(numInput)==true)
                {
                    return "this is hexa num";
                }
                return "invalid input";
            }


        }

        static public bool PrefixStartWith0(string numInput)
        {
            if (numInput[0]=='0')
            {
                return true;
            }
            return false;
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
            return Regex.IsMatch(numInput, @"\A\b^([0-7])+\b\Z");
        }

        static public string DecimalToAnySystem(int numDecimal, int systembase)
        {
            int remainder;            
            string binary = "";
            

            while(numDecimal>0)
            {
                remainder = numDecimal % systembase;
                numDecimal /= systembase;
                

                binary = remainder.ToString() + binary;
            }

            return binary;
        }

        

    }
}
