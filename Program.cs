using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Number_system_converter
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(WhatBase("0101010"));
            
            
        }

        static public string WhatBase(string numInput)
        {
            if (IsHex(numInput) == true)
            {
                return "this is hexa num";
            }
            else if (IsBinary(numInput) == true)
            {
                return "this is binary number";
            }
            else if (IsOctal(numInput) == true)
            {
                return "this is octa number";
            }
            else
            {
                if (int.TryParse(numInput, out int result) == true)
                {
                    return "this is decimal";
                }
                else
                {
                    return "invalid input";
                }
            }


        }

        static public bool IsHex(string numInput)
        {
            //start with 0x or 0X, and @"\A\b^(0[xX])?[0-9a-fA-F]+\b\Z"
            return Regex.IsMatch(numInput, @"^(0[xX])&([0-9a-fA-F])");

        }

        static public bool IsBinary(string numInput)
        {
            return Regex.IsMatch(numInput, @"^[01]+$");
        }

        static public bool IsOctal(string numInput)
        {
            return Regex.IsMatch(numInput, @"^(0)&([0-7])");
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
