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
            DecimalSystem newDec = new DecimalSystem("8271");
            BinarySystem newBinary = new BinarySystem("10101010");
            OctaSystem newOcta = new OctaSystem("0123");
            string ans;
            bool flag = true;
            while (flag)
            {
                Console.Write("Please enter a number in any base: ");
                ans = Console.ReadLine();
                Show(ans);
                do
                {
                    Console.Write("Do you want to continue(y/n): ");
                    ans = Console.ReadLine();
                } while (ans != "y" && ans != "n");

                if (askUserForContinue(ans))
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    flag = false;
                }
            }
            Console.WriteLine((int)'A');

        }


        static bool askUserForContinue(string input)
        {
            var cont = (input.ToLower() == "y") ? true : false;
            return cont;
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
                return new HexaSystem(correctHexa(numInput));
            }
            
        }

       

        static public bool isNumeric(string inputNumber)
        {
            return double.TryParse(inputNumber, out double num);
        }

        static public string correctHexa(string numInput)
        {
            //return Regex.IsMatch(numInput, @"\A\b^(0[xX])?[0-9a-fA-F]+\b\Z");
            string prefixHexa = numInput.Substring(0, 2);            
            if (prefixHexa!="0x" && prefixHexa!="0X")
            {
                numInput = "0x" + numInput;
            }
            return numInput;
        }


        static public bool IsOctal(string numInput)
        {

            //return Regex.IsMatch(numInput, @"^0[1-7][0-7]{0,6}$");
            bool checkOctal = true;
            if (numInput[0]!='0')
            {
                checkOctal = false;
            }
            else
            {
                foreach (var item in numInput)
                {
                    if (int.Parse(item.ToString())>7)
                    {
                        checkOctal = false;
                        break;
                    }
                }
            }
            return checkOctal;

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

        static public bool isFractional(string numInput)
        {
            return true;

        }
        static void Show(string input)
        {
            INumericSystem numBase = WhatBase(input);
            Console.WriteLine("\nIn decimal: " + numBase.ToDecimal());
            Console.WriteLine("In binary: " + numBase.ToBinary());
            Console.WriteLine("In octal: " + numBase.ToOcta());
            Console.WriteLine("In hex: " + numBase.ToHex());
        }

    }   
        
    
}
