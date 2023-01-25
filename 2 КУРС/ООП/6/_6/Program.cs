using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _6
{
    class Program
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
                    { "1/x", (x)=>1/x },
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
        [TestMethod]
        public static void CalculateTestMethod()
        {
            String[] a = CalcLibrary.Calc.GetOperands("23+4,5");
            Assert.AreEqual("23", a[0]);
            Assert.AreEqual("4,5", a[1]);
        }
        [TestMethod]
        public static void ResultTestMethod()
        {
            Assert.AreEqual("27,5", CalcLibrary.Calc.DoubleOperation["+"](23, 4.5).ToString());
            string result = CalcLibrary.Calc.DoOperation("23+4,5");
            Assert.AreEqual("27,5", result);
        }


        static void Main(string[] args)
        {
            Console.WriteLine(CalcLibrary.Calc.DoOperation("-23*0,5"));
        }
    }
}
