using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                int m = 0;
                string s = textBox1.Text;
                StringBuilder s1 = new StringBuilder(s);
                for (int i = 0; i < s.Length - 1 + m; i++)
                {
                    if (s1[i] != s1[i + 1])
                    {
                        s1.Insert(i + 1, "*");
                        i++;
                        m++;
                    }
                }
                textBox2.Text = s1.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
