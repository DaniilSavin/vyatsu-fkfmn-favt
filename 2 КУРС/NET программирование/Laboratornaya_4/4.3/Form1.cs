using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                if ((double.Parse(rost.Text)>135 && double.Parse(rost.Text) < 195) && (int.Parse(vozrast.Text)>15 && int.Parse(vozrast.Text) < 60))
                {

                    if (male.Checked)
                    {
                        double rez=(50 + 0.75 * (double.Parse(rost.Text) - 150) + (0.25 * (int.Parse(vozrast.Text) - 20)));
                        result.Text = rez.ToString();
                    }
                    else
                    {
                        if (female.Checked)
                        {
                            double rez = 0.9 * (50 + 0.75 * (double.Parse(rost.Text) - 150) + (0.25 * (int.Parse(vozrast.Text) - 20)));
                            result.Text = rez.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Выберите пол.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Рост должен быть от 135 до 195, а возраст от 15 до 60.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    result.Text = "";
                }

            }
            catch
            {
                MessageBox.Show("Некорректный ввод исходных данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result.Text = "";

            }
        }

        private void rost_TextChanged(object sender, EventArgs e)
        {
            if (rost.Text=="0")
            {
                rost.Text = "";
            }
        }

        private void vozrast_TextChanged(object sender, EventArgs e)
        {
            if (vozrast.Text=="0")
            {
                vozrast.Text = "";
            }
        }
    }
}
