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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int day = int.Parse(daytb.Text);
                int month = int.Parse(monthtb.Text);
                int year = int.Parse(yeartb.Text);
                int num = 0; int temp=10;
                if (day < 32 && month < 12)
                {
                    while (temp >= 10)
                    {

                        temp = day % 10;
                        temp += (day / 10);
                        day /= 10;

                    }
                    day = temp;
                    temp = 10;
                    while (temp >= 10)
                    {

                        temp = month % 10;
                        temp += (month / 10);
                        month /= 10;
                    }
                    month = temp;
                    temp = 10;
                    while (temp >= 10)
                    {

                        temp = year % 10;
                        temp += (year / 100);
                        year /= 10;
                    }
                    year = temp;

                    num = day + month + year;
                    while (num >= 10)
                    {
                        temp = num % 10;
                        temp += (num / 10);
                        num /= 10;
                    }
                    /* daytb.Text = day.ToString();
                     monthtb.Text = month.ToString();
                     yeartb.Text = year.ToString();*/
                    textBox1.Text = temp.ToString();
                }
                else
                {
                    MessageBox.Show("Ошибка ввода.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Ошибка ввода.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
            }
        }

        private void yeartb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(sender, e);
        }
    }
}
