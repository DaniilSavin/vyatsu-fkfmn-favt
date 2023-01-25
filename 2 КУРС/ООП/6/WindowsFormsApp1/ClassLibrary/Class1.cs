using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class CalcLibrary
    {
        public class Calc
        {
            public delegate T OperationDelegate<T>(T x, T y);
            public static Dictionary<string, OperationDelegate<double>> DoubleOperation = new Dictionary<string, OperationDelegate<double>>
                {
                    { "+", (x,y)=>x+y },
                    { "-", (x,y)=>x-y },
                    { "*", (x,y)=>x*y },
                    { "/", (x,y)=>x/y },
                    { "div", (x,y)=>(int)x/(int)y },
                    { "mod", (x,y)=>x%y },
                    { "x^", (x,y)=>Math.Pow(x,y) },
                };
            public delegate T OperationDelegate2<T>(T x);
            public static Dictionary<string, OperationDelegate2<double>> DoubleOperation2 = new Dictionary<string, OperationDelegate2<double>>
                {
                    { "n!", (x)=>{int y=1; for(int i=1;i<=x;i++)y=y*i;return y;} },
                    { "sqrt", (x)=>{if(x>=0)return Math.Sqrt(x);else throw new ArgumentException(); } },
                    { "sin", (x)=>{while(x<0)x+=Math.PI*2; return Math.Sin(x); } },
                    { "cos", (x)=>{while(x<0)x+=Math.PI*2; return Math.Cos(x); } },
                    { "tan", (x)=>{while(x<0)x+=Math.PI*2; return Math.Tan(x); }},
                    { "exp", (x)=>Math.E },
                    { "PI", (x)=>Math.PI }
                };


            public static string DoOperation(string s)
            {
                string op = GetOperation(s);
                string[] operands = GetOperands(s);
                return DoubleOperation[op](double.Parse(operands[0]), double.Parse(operands[1])).ToString();
            }

            public static string GetOperation(string s)
            {
                String[] a = GetOperands(s);
                s = s.Replace(a[0], "");
                s = s.Replace(a[1], "");
                return s;
            }
            public static string[] GetOperands(string s)
            {
                Regex rgx = new Regex(@"[^\d,\.\-]");
                MatchCollection mc = rgx.Matches(s);
                List<string> lm = new List<string>();
                foreach (Match m in mc)
                {
                    lm.Add(m.Value);
                }
                return s.Split(lm.ToArray(), StringSplitOptions.None);
            }

        }
    }
}
