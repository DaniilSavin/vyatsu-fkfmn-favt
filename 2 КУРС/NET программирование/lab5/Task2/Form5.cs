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
    public partial class Form5 : Form
    {
        static Graphics Graph;
        static int m = 25;
        static Pen MyPen = new Pen(Color.Black, 1);
        static int cur = 0;
        static int midx;
        static int midy;
        static double a = 0, inside = 0;
        static int checkwrite = 0;

        static void area(int x0, int y0, int a, int inside)
        {
            if (cur > inside) return;
            if (cur % 2 == 0)
            {
                Graph.DrawRectangle(MyPen, x0, y0, a, a);
                cur++;
                a = a / 2;
                area(x0, y0, a, inside);
            }
            else
            {
                Graph.DrawLine(MyPen, x0 + a, y0, x0, y0 + a);
                Graph.DrawLine(MyPen, x0 + a, y0, x0 + 2 * a, y0 + a);
                Graph.DrawLine(MyPen, x0 + 2 * a, y0 + a, x0 + a, y0 + 2 * a);
                Graph.DrawLine(MyPen, x0 + a, y0 + 2 * a, x0, y0 + a);
                y0 = y0 + a / 2;
                x0 = x0 + a / 2;
                cur++;
                area(x0, y0, a, inside);

            }
        }
            public Form5()
        {
            InitializeComponent();
            Graph = CreateGraphics();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            Graph.Clear(BackColor);
            int error = 0;
            int x = 80;
            int check1 = 0, check2 = 0;
            double a = 0, inside = 0;
            try 
            {
                a = double.Parse(DimTextBox.Text);
                check1 = 1;
            }
            catch
            {
                DimTextBox.Text = "";
                if (error == 0)
                {
                    MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = 1;
                }
            }

            try
            {
                inside = double.Parse(RecTextBox.Text);
                check2 = 1;
            }
            catch
            {
                RecTextBox.Text = "";
                if (error == 0)
                {
                    MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = 1;
                }
            }

            if (check1 == 1 && check2 == 1)
            {
                if (a > x || a < 1 || DimTextBox.Text[0] == '0') 
                {
                    if (error == 0)
                    {
                        DimTextBox.Text = "";
                        MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = 1;
                    }
                    else
                        DimTextBox.Text = "";
                }
                else
                if (inside % 1 != 0 || a < 0 || DimTextBox.Text[0] == '0')
                {
                    if (error == 0)
                    {
                        RecTextBox.Text = "";
                        MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = 1;
                    }
                    else
                        RecTextBox.Text = "";
                }

                else 
                {
                    checkwrite = 1;
                    int asq = (int)a;
                    int insidesq = (int)inside;
                    cur = 0;
                    midx = this.ClientSize.Width / 2;
                    midy = this.ClientSize.Height / 2;
                    int mida = (int)a / 2;
                    getarea(midx - mida, midy - mida, asq, insidesq);
                }

            }

        }
        static void getarea(int x0, int y0, int a, int inside)
        {
            if (cur > inside) return;
            if (cur % 2 == 0)
            {
                Graph.DrawRectangle(MyPen, x0, y0, a, a);
                cur++;
                a = a / 2;
                getarea(x0, y0, a, inside);
            }
            else
            {
                Graph.DrawLine(MyPen, x0 + a, y0, x0, y0 + a);
                Graph.DrawLine(MyPen, x0 + a, y0, x0 + 2 * a, y0 + a);
                Graph.DrawLine(MyPen, x0 + 2 * a, y0 + a, x0 + a, y0 + 2 * a);
                Graph.DrawLine(MyPen, x0 + a, y0 + 2 * a, x0, y0 + a);
                y0 = y0 + a / 2;
                x0 = x0 + a / 2;
                cur++;
                getarea(x0, y0, a, inside);

            }
        }

        private void Form5_Resize(object sender, EventArgs e)
        {
            Graph = CreateGraphics();
            if (checkwrite == 1)
            {
                cur = 0;
                midx = this.ClientSize.Width / 2;
                midy = this.ClientSize.Height / 2;
                //int asq = (int)a;
                //int insidesq = (int)inside;
                //int mida = (int)a / 2;
                Graph.Clear(BackColor);
                getarea(midx - (int)a / 2, midy - (int)a / 2, (int)a, (int)inside);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    } 
}
    
