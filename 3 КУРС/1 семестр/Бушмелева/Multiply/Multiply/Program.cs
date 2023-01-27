using System;
using System.Collections.Generic;
using System.Linq;

namespace Multiply
{
    class Program
    {
        struct Part { public int real; public int image; };
        static void Main(string[] args)
        {
            string input1 = "2+3i";
            string input2 = "4-5i";

            char[] admissibleSymbols = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'i', '+', '-', ' ', '*' };
            bool check(string str)
            {
                bool flag = true;
                foreach (var item in str)
                {
                    if (admissibleSymbols.ToList().IndexOf(item) == -1)
                    {
                        flag = false;
                        break;
                    }
                }
                return flag;
            }

            Part parseNum(string str)
            {
                string tmpStr = "";
                Part output = new Part();
                int i = 0;
                if (str[0] == '-')
                {
                    ++i;
                    tmpStr += str[0];
                }
                bool realParsed = false;
                for (; i < str.Length; i++)
                {
                    if (str[i] == '-' || str[i] == '+' || i + 1 == str.Length)
                    {
                        if (!realParsed)
                        {
                            realParsed = !realParsed;
                            output.real = int.Parse(tmpStr);
                            tmpStr = str[i].ToString();
                        }
                        else
                        {
                            output.image = int.Parse(tmpStr);
                        }
                    }
                    else
                    {
                        tmpStr += str[i];
                    }
                }
                return output;
            }


            Part Multiply(Part arg1, Part arg2)
            {
                Part part;
                part.real = arg1.real * arg2.real - arg1.image * arg2.image;
                part.image = arg1.image * arg2.real + arg1.real * arg2.image; 
                return part;
            }


            if (check(input1) && check(input2))
            {
                Part splitedInput1 = parseNum(input1);
                Part splitedInput2 = parseNum(input2);
                Part multiply = Multiply(splitedInput1, splitedInput2);
                Console.WriteLine(input1 +"*"+input2);
                Console.WriteLine(multiply.real + ((multiply.image < 0) ? "" : "+") + multiply.image + "i");
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }

            Console.ReadKey();
        }
    }
}
