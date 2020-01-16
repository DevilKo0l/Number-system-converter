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

            bool flag = true;
            while (flag)
            {
                Console.Write("Please enter a number in any base: ");
                string input = Console.ReadLine();
                Show(input);

                Console.Write("Do you want to continue(y/n): ");
                string cont = Console.ReadLine();
                if (askUserForContinue(cont))
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    flag = false;
                }
            }

            var floatNumber = 12.5532;
            var x = floatNumber - Math.Floor(floatNumber);
            Console.WriteLine(x);

            Console.WriteLine(DecimalFactionToAnySystem(2, 0.231));






        }

        static public string DecimalFactionToAnySystem(int systembase, double decima)
        {

            //double numAfterDot = decima - Math.Floor(decima);
            //decima = decima * systembase;
            string result = "";
            double nDecima = decima;
            double fractionalPart = decima - (long)decima;

            while (nDecima > 0)
            {
                nDecima = nDecima * systembase;

                //if (Math.Floor(nDecima) == 0)
                //{
                //    result += "0";
                //}
                //else
                //{
                //    result += "1";
                //}
                result += (long)nDecima;
                nDecima = nDecima - Math.Floor(nDecima);

            }

            return result;
        }

        

        static bool askUserForContinue(string input)
        {
            if (input.ToLower() == "y")
            {
                return true;
            }
            else if (input.ToLower()=="n")
            {
                return false;
            }
            else
            {
                return false;
            }
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
            return double.TryParse(inputNumber, out double num);
        }

        static public bool IsHex(string numInput)
        {            
            return Regex.IsMatch(numInput, @"\A\b^(0[xX])?[0-9a-fA-F]+\b\Z");
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
            Console.WriteLine("In decimal: " + numBase.ToDecimal());
            Console.WriteLine("In binary: " + numBase.ToBinary());
            Console.WriteLine("In octal: " + numBase.ToOcta());
            Console.WriteLine("In hex: " + numBase.ToHex());

        }

    }   
        
    
}
