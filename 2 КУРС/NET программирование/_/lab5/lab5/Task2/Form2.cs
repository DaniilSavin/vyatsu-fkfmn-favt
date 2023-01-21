using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

       

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            ResultTextBox.Text = "";
        }

        private void ResultButton_Click(object sender, EventArgs e)
        {
            try
            {
                string s = InputTextBox.Text;
                double number = double.Parse(s);
                if ((number < 1) || (s[0] == '0') || (number % 1 != 0))
                {
                    InputTextBox.Text = "";
                    ResultTextBox.Text = "";
                    MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else 
                {
                    int n = s.Length;
                    int[] a = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        int ch = (int)(s[i]);
                        a[i] = ch;
                    }
                    for (int i = 0; i < n; i++)     
                        for (int j = n - 1; j > i; j--)
                            if (a[j - 1] < a[j])
                            {
                                int x = a[j - 1];
                                a[j - 1] = a[j];
                                a[j] = x;
                            }
                    string rez = "";
                    for (int i = 0; i < n; i++)
                    {
                        char z = (char)a[i];
                        rez = rez + z;
                    }
                    while (rez[0] == '0')
                        rez = rez.Remove(0, 1);
                    ResultTextBox.Text = rez;
                }
            }
            catch
            {
                InputTextBox.Text = "";
                ResultTextBox.Text = "";
                MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
