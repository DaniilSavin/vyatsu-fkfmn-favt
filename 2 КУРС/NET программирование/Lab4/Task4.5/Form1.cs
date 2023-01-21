using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] k = textBox1.Text.Split(' ');
                double a = double.Parse(k[0]);
                double b = double.Parse(k[1]);
                double c = double.Parse(k[2]);
                double d = b * b - 4 * a * c;
                if (d < 0)
                {
                    label3.Text = "D<0. Нет корней.";
                }
                else
                if (d == 0)
                {
                    label3.Text = "D=0. Один корень. x = "+(-b/(2.0*a));
                }
                else label3.Text = "D>0. Два корня. x1 = " + ((-b + Math.Sqrt(d)) / (2.0 * a) + " x2 = "+ ((-b - Math.Sqrt(d)) / (2.0 * a)));
            }
            catch (Exception)
            {
                label3.Text = "Ошибка!";
                throw;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "Нажмите \" Вычислить\"";
        }
    }
}
