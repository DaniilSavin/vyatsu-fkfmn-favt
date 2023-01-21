using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int X = this.ClientSize.Width - 97 - 5;
            int Y = this.ClientSize.Height - 23 - 5;
            button1.Location = new System.Drawing.Point(X, Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int day, month, year;
            try
            {
                
                day = int.Parse(daytextbox.Text);
                month = int.Parse(monthtextbox.Text);
                year = int.Parse(yeartextbox.Text);
                try
                {
                    if (day > 0 && day < 32)
                    {
                        if (month > 0 && month < 13)
                        {
                            if (day == 1)
                            {
                                int k = (31 * month) - 37;
                                dayleft.Text = k.ToString();
                            }
                            else
                            {
                                int k = (day - 1 + (31 * month)) - 37;
                                dayleft.Text = k.ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Некорректный ввод месяца", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dayleft.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Некорректный ввод дня", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dayleft.Text = "";
                    }

                }
                catch
                {
                    MessageBox.Show("Некорректный ввод исходных данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dayleft.Text = "";

                }
            }
            catch
            {
                MessageBox.Show("Некорректный ввод исходных данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dayleft.Text = "";
            }
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int X = this.ClientSize.Width-97-5;
            int Y = this.ClientSize.Height - 23 - 5;
            button1.Location = new System.Drawing.Point(X, Y);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(sender, e);
        }
    }
}
