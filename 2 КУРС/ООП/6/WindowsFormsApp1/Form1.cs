using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public class CalcLibrary
        {
            public class Calc
            {
                delegate T OperationDelegate<T>(T x, T y);
                static Dictionary<string, OperationDelegate<double>> DoubleOperation =
                    new Dictionary<string, OperationDelegate<double>>
                {
                    { "+", delegate(double x, double y){ return x + y; } },
                    { "-", delegate(double x, double y){ return x - y; } },
                    { "*", delegate(double x, double y){ return x * y; } },
                    { "/", delegate(double x, double y){ return x / y; } },
                };

                public static string DoOperation(string s)
                {
                    string op = GetOperation(s);
                    string[] operands = GetOperands(s); 
                    return DoubleOperation[op](double.Parse(operands[0]), double.Parse(operands[1])).ToString(); ;//вычислить и получить строку;
                }
                static string GetOperation(string s)
                {
                    List<char> op = new List<char>();
                    op.Add('+');
                    op.Add('-');
                    op.Add('*');
                    op.Add('/');
                    for (int i = 1; i < s.Length; i++)
                    {
                        if (!char.IsDigit(s[i])&&s[i]!=','&&char.IsDigit(s[i+1]))
                        {
                            return s[i].ToString();
                        }
                    }
                    return "";
                }
                public static string[] GetOperands(string s)
                {
                    Regex rgx = new Regex(@"[^\d,\.]");
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
        public Form1()
        {
            InitializeComponent();
        }
        public void CalculateTestMethod()
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {          
            Console.WriteLine(CalcLibrary.Calc.DoOperation("23+4,5"));
        }
    }
}
