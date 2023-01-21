using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5._2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int temp, k, m=0;
            try
            {
                int num = int.Parse(textBox1.Text);
                for (int i = 9; i >= 0; i--)
                {
                    temp = num;
                    while (temp > 0)
                    {
                        k = temp % 10;
                        if (k==i)
                        {
                            m = m * 10 + k;
                        }
                        temp /= 10;

                    }
                }
                textBox2.Text = m.ToString();

            }
            catch
            {
                MessageBox.Show("Ошибка ввода данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
