using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3._2
{
    public partial class Form1 : Form
    {
        Graphics Graph;
            Pen MyPen;
        Font MyFont;
        SolidBrush MyBrush;

        


        double kx = 5; double ky = 5;
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Graph = CreateGraphics();
            MyFont = new Font("Arial", 10, FontStyle.Bold);
            MyBrush = new SolidBrush(Color.Black);
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData == Keys.Right || e.KeyData == Keys.Left)
            {
                this.Invalidate();
                this.Update();
                Graph = CreateGraphics();
                MyPen = new Pen(Color.Black);
                int x0 = this.ClientSize.Width / 2;
                int y0 = this.ClientSize.Height / 2;
                int x1, y1, x2, y2;
                double x, y;
                const double xMin = -10;
                const double xMax = 10;
                const double step = 0.01;
                
                if (e.KeyData == Keys.Up)
                {
                    kx *= 5;

                }
                if (e.KeyData == Keys.Down)
                {
                    kx /= 5;
                }
                if (e.KeyData == Keys.Right)
                {
                    ky *= 5;
                }
                if (e.KeyData == Keys.Left)
                {
                    ky /= 5;
                }

                x = xMin;
                y = Math.Tan(x);
                x1 = (int)(x0 + x * kx);
                y1 = (int)(y0 - y * ky);
                Graph.DrawString("kx= " + kx + "\nky= " + ky, MyFont, MyBrush, 50, 150);
                while (x < xMax)
                {                     
                    x = x + step;
                    y = Math.Tan(x);
                    x2 = (int)(x0 + x * kx);
                    y2 = (int)(y0 - y * ky);
                    
                    MyPen = new Pen(Color.Black);
                    if (kx <= 5000 && ky <= 5000)
                    {
                        Graph.DrawLine(MyPen, x1, y1, x2, y2);
                    }
                    x1 = x2;
                    y1 = y2;
                }
            }

        }
    }
}
