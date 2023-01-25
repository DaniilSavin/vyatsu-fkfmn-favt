using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CalcLibrary
{
    public static class Calc
    {
        static bool OperandsTwiceStatic;//логическая переменная, если истина - 2 операнда, ложь - один операнд
        
        public static string DoOperation(string s, bool OperandTwice, int lefttop1, int lefttop2, int righttop ) //на основание двух методов выполняем операцию
        {
            string[] operands;
            string op;
            OperandsTwiceStatic = OperandTwice;
            if (!OperandTwice)
            {
                operands = GetOperands(s);
                op = GetOperation1(s);
                s = DoubleOperation2[op](double.Parse(operands[0]), double.Parse(operands[1])).ToString();
            }
            else
            {
                operands = GetOperands(s);
                op = GetOperation2(s);
                if (operands.Length >= 2) s = DoubleOperation2[op](double.Parse(operands[0]), double.Parse(operands[1])).ToString();
                else s = DoubleOperation1[op](double.Parse(operands[0])).ToString();
            }
            return s;
        }
        public static string[] GetOperands(string s)// Возвращает операнды в массив строк
        {
            string pattern = @"[^\d,\.]";//шаблон
            Regex rgx = new Regex(pattern);
            MatchCollection mc = rgx.Matches(s);//коллекция подходящая под шаблон выражений
            List<string> lm = new List<string>();
            foreach (Match m in mc)
            {
                lm.Add(m.Value);
            }
            if (lm.Count > 1 && lm[1].Length > 1 && lm[1][1] == '-')
                lm[1] = lm[1].Substring(1);
            if (OperandsTwiceStatic && lm[0].Length > 1 && lm[0][1] == '-')
                lm[0] = lm[0].Substring(1);
            return s.Split(lm.ToArray(), StringSplitOptions.None);//деление строки на подстроки и вернуть полученный массив
        }
        public static string GetOperation2(string s)
        {
            string pattern = @"[^\d,\./]";
            Regex rgx = new Regex(pattern);
            MatchCollection mc = rgx.Matches(s);
            List<string> lm = new List<string>();
            foreach (Match m in mc)
            {
                lm.Add(m.Value);
                s = m.Value;
            }
            return lm[0];

        }
        
        public static string GetOperation1(string s) //получение операции
        {
            string pattern = @"[^\d-\(\),]+";
            Regex rgx = new Regex(pattern);
            MatchCollection mc = rgx.Matches(s);
            List<string> lm = new List<string>();
            foreach (Match m in mc)
            {
                lm.Add(m.Value);
                s = m.Value;
            }
            if (lm[0].Length > 1 && lm[0][0] == 'e') lm[0] = lm[0].Remove(0, 1);
            return lm[0];
        }
        
        public delegate T OperationDelegate1<T>(T x);
        public static Dictionary<string, OperationDelegate1<double>> DoubleOperation1 =
            new Dictionary<string, OperationDelegate1<double>> //словарь со списком операций
        {
            { "n!", (x)=>{int y=1; for(int i=1;i<=x;i++)y=y*i;return y;} },
            { "sqrt", (x)=>{if(x>=0)return Math.Sqrt(x);else throw new ArgumentException(); } },
            { "sin", (x)=>{while(x<0)x+=Math.PI*2; return Math.Sin(x); } },
            { "cos", (x)=>{while(x<0)x+=Math.PI*2; return Math.Cos(x); } },
            { "tan", (x)=>{while(x<0)x+=Math.PI*2; return Math.Tan(x); }},
            { "exp", (x)=>Math.E },
            { "PI", (x)=>Math.PI }
        };
        
        public delegate T OperationDelegate2<T>(T x, T y);
        public static Dictionary<string, OperationDelegate2<double>> DoubleOperation2 =
            new Dictionary<string, OperationDelegate2<double>> //словарь со списком операций
        {
            { "+", (x, y)=>x + y },
            { "-", (x, y)=>x-y },
            { "*", (x, y)=>x * y },
            { "/", (x, y)=>{if (y != 0) return x / y; else throw new ArgumentException(); } },
            { "^", (x, y)=>Math.Pow(x,y) },
            { "div", (x,y)=>(int)x / (int)y },
            { "mod", (x, y)=>(int)x % (int)y }
        };
    }
}
