using System;
using System.Collections.Generic;
using System.Text;

namespace zadanie_3
{
    class Octal_sys
    {
        public static string F10T8(int number)
        {
            string result = null;
            while (number > 0)
            {
                var tmp = number % 8;
                if (tmp == 0)
                {
                    result = "0";
                }
                else
                {
                    result = tmp.ToString() + result;
                }
                number /= 8;
            }
            return result;
        }
        private static bool CorrectlyNumber(string number1)
        {
            int k=0;
            char[] sym = { '0', '1', '2', '3', '4', '5', '6', '7' };
            for (int i=0; i<number1.Length; i++)
            {
                for (int j = 0; j < sym.Length; j++)
                {
                    if (number1[i] == sym[j])
                    {
                        k++;
                    }
                }
            }
            if (k == number1.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static string F10T2(int number)
        {
            string result = null;
            while (number >= 1)
            {
                result = number % 2 + result;
                number /= 2;

            }
            return result;
        }
        private static string F8T2(string number)
        {
            return F10T2(int.Parse(F8T10(number)));
        }

        private static string F8T10(string number)
        {
            number = number.ToUpper();
            int Decimal = 0;
            for (int i = 0; i < number.Length; i++)
            {
                Decimal += int.Parse(number[i].ToString()) * (int)(Math.Pow(8, number.Length - i - 1));
            }
            return Decimal.ToString();
        }
        public static string Sum(string number1, string number2)
        {
            if (CorrectlyNumber(number1) && CorrectlyNumber(number2))
            {
                return Convert.ToString(Convert.ToInt32(number1, 8) + Convert.ToInt32(number2, 8), 8);
            }
            else
            {
                return "Error format";
            }
        }

        public static string Sum(int number1, int number2)
        {
            string n = F10T8(number1);
            string n2 = F10T8(number2);
            return Convert.ToString(Convert.ToInt32(n.ToString(), 8) + Convert.ToInt32(n2, 8), 8);
        }
        public static string Sub(string number1, string number2)
        {
            if (CorrectlyNumber(number1) && CorrectlyNumber(number2))
            {
                return Convert.ToString(Convert.ToInt32(number1, 8) - Convert.ToInt32(number2, 8), 8);
            }
            else
            {
                return "Error format";
            }
        }
        public static string Sub(int number1, int number2)
        {
            string n = F10T8(number1);
            string n2 = F10T8(number2);
            return Convert.ToString(Convert.ToInt32(n.ToString(), 8) - Convert.ToInt32(n2, 8), 8);
        }

        public static string And(string number1, string number2)
        {
            if (CorrectlyNumber(number1) && CorrectlyNumber(number2))
            {
                string result = null;
                number1 = F8T2(number1);
                number2 = F8T2(number2);
                if (number2.Length > number1.Length)
                {
                    string tmp = number2;
                    number2 = number1;
                    number1 = tmp;
                }
                for (int i = number1.Length - 1; i >= 0; i--)
                {
                    if (i > number1.Length - number2.Length - 1)
                    {
                        Console.WriteLine(number1[i] + " " + number2[i - (number1.Length - number2.Length)]);
                        if (number1[i] == '1' && number2[i - (number1.Length - number2.Length)] == number1[i])
                        {
                            result = "1" + result;
                        }
                        else
                        {
                            result = "0" + result;
                        }
                    }
                    else result = number1[i] + result;
                }
                return Convert.ToString(Convert.ToInt32(result, 2), 8);
            }
            else
            {
                return "Error Format";
            }
        }
        public static string And(int num1, int num2)
        {
            string n = F10T8(num1);
            string n2 = F10T8(num2);
            string result = null;
            string number1 = F8T2(n.ToString());
            string number2 = F8T2(n2.ToString());
            number2 = F8T2(number2);
            if (number2.Length > number1.Length)
            {
                string tmp = number2;
                number2 = number1;
                number1 = tmp;
            }
            for (int i = number1.Length - 1; i >= 0; i--)
            {
                if (i > number1.Length - number2.Length - 1)
                {
                    Console.WriteLine(number1[i] + " " + number2[i - (number1.Length - number2.Length)]);
                    if (number1[i] == '1' && number2[i - (number1.Length - number2.Length)] == number1[i])
                    {
                        result = "1" + result;
                    }
                    else
                    {
                        result = "0" + result;
                    }
                }
                else result = number1[i] + result;
            }
            return Convert.ToString(Convert.ToInt32(result, 2), 8);
        }

        public static string Or(string number1, string number2)
        {
            if (CorrectlyNumber(number1) && CorrectlyNumber(number2))
            {
                string result = null;
                number1 = F8T2(number1);
                number2 = F8T2(number2);
                if (number2.Length > number1.Length)
                {
                    string tmp = number2;
                    number2 = number1;
                    number1 = tmp;
                }
                for (int i = number1.Length - 1; i >= 0; i--)
                {
                    if (i > number1.Length - number2.Length - 1)
                    {
                        Console.WriteLine(number1[i] + " " + number2[i - (number1.Length - number2.Length)]);
                        if (number1[i] == '1' || number2[i - (number1.Length - number2.Length)] == '1')
                        {
                            result = "1" + result;
                        }
                        else
                        {
                            result = "0" + result;
                        }
                    }
                    else result = number1[i] + result;
                }
                return Convert.ToString(Convert.ToInt32(result, 2), 8);
            }
            else
            {
                return "Error format";
            }
        }
        public static string Or(int num1, int num2)
        {
            string n = F10T8(num1);
            string n2 = F10T8(num2);
            string result = null;
            string number1 = F8T2(n.ToString());
            string number2 = F8T2(n2.ToString());
            number2 = F8T2(number2);
            if (number2.Length > number1.Length)
            {
                string tmp = number2;
                number2 = number1;
                number1 = tmp;
            }
            for (int i = number1.Length - 1; i >= 0; i--)
            {
                if (i > number1.Length - number2.Length - 1)
                {
                    Console.WriteLine(number1[i] + " " + number2[i - (number1.Length - number2.Length)]);
                    if (number1[i] == '1' || number2[i - (number1.Length - number2.Length)] == '1')
                    {
                        result = "1" + result;
                    }
                    else
                    {
                        result = "0" + result;
                    }
                }
                else result = number1[i] + result;
            }
            return Convert.ToString(Convert.ToInt32(result, 2), 8);
        }
    }
}
