using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void StringButton_Click(object sender, EventArgs e)
        {
            string s = InputTextBox.Text;
            if (s == "") MessageBox.Show("Введите непустую строку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int countleft = 0, countright = 0;
                int leftfirst = 0;
                int leftind = 0, rightind = 0;
                int i = 0, check = 0;
                while (check == 0)
                {
                    if (s[i] == '(')
                    {
                        countleft++;
                        leftind = i;
                    }
                    if (s[i] == ')')
                    {
                        countright++;
                        rightind = i;
                    }
                    if (countleft == 1 && countright == 1) // подрят идущие, невложенные скобки
                    {
                        i = leftind - 1;
                        leftfirst = 0;
                        s = s.Remove(leftind, (rightind - leftind + 1));
                        countleft = 0;
                        countright = 0;

                    }
                    // вложенные скобки
                    if (countleft == 1 && countright == 0) leftfirst = leftind;
                    if (countleft == 2 && countright == 0)
                    {
                        while (countleft != countright)
                        {
                            i++;
                            if (s[i] == '(') countleft++;
                            if (s[i] == ')') countright++;

                        }
                        s = s.Remove(leftfirst, (i - leftfirst + 1));
                        i = leftfirst;
                        countleft = 0;
                        countright = 0;
                        leftfirst = 0;

                    }
                    int ends = 0;
                    for (int ch = 0; ch < s.Length; ch++) 
                        if (s[ch] == '(' || s[ch] == ')') ends = 1;
                    if (ends == 0) check = 1;
                    else i++;
                }

                StringTextBox.Text = s;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            StringTextBox.Text = "";
        }
    }
}
