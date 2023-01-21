using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (a.Text != "0")
                {
                    double diskriminant = 0;
                    diskriminant = Math.Pow(int.Parse(b.Text), 2) - 4 * int.Parse(a.Text) * int.Parse(c.Text);
                    if (diskriminant < 0)
                    {
                        label4.Text = "D<0, Корней нет.";
                        x1.Text = ""; x2.Text = "";

                    }
                    else
                    {
                        if (diskriminant == 0)
                        {
                            label4.Text = "D=0, Один Корень.";
                            double x = (-int.Parse(b.Text) + Math.Sqrt(diskriminant)) / 2 * int.Parse(a.Text);
                            x1.Text = x.ToString();
                            x2.Text = "";
                        }
                        else
                        {
                            label4.Text = "D>0, Корней 2.";
                            double x = (-int.Parse(b.Text) + Math.Sqrt(diskriminant)) / (2 * int.Parse(a.Text));
                            double y = (-int.Parse(b.Text) - Math.Sqrt(diskriminant)) / (2 * int.Parse(a.Text));
                            x1.Text = x.ToString();
                            x2.Text = y.ToString();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Некорректный ввод исходных данных. а должно быть не равно 0.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    x1.Text = ""; x2.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Некорректный ввод исходных данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                x1.Text = ""; x2.Text = "";
                label4.Text = "";

            }
        }

        private void a_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(sender, e);
        }

        private void b_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(sender, e);
        }

        private void c_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(sender, e);
        }
    }
}
