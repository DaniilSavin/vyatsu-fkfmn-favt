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

namespace task11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private const char OpenBracket = '(';
        private const char ClosingBracket = ')';
        private static string ExcludeBraces(string source)
        {
            var sb = new StringBuilder();
            var itor = source.GetEnumerator();
            while (itor.MoveNext())
            {
                if (itor.Current == OpenBracket)
                    ReadBraces(itor);
                else
                    sb.Append(itor.Current);
            }
            return sb.ToString();
        }

        private static void ReadBraces(CharEnumerator itor)
        {
            while (itor.MoveNext())
            {
                if (itor.Current == ClosingBracket)
                    return;
                else 
                if (itor.Current == OpenBracket)
                    ReadBraces(itor);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String source = textBox1.Text;
            var result = ExcludeBraces(source);
            textBox1.Text = result;
        }
    }
}
