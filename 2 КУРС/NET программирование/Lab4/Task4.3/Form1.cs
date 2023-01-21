using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double h = double.Parse(textBox1.Text);
                double a = double.Parse(textBox2.Text);
                if (h > 0 && a > 0)
                {
                    double k;
                    if (radioButton1.Checked) k = 1; else k = 0.9;
                    double ves = k * (50 + 0.75 * (h - 150) +0.25 * (a - 20));
                    label3.Text = "Идеальный вес = " + ves;
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка! Не корректно введены данные.");
                label3.Text = "Введите данные и нажмите \"Вычислить\"";
            }            
        }
    }
}
