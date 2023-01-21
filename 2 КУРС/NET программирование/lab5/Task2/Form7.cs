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
    public partial class Form7 : Form
    {
        Form1 Settings;
        Graphics Graph;
        Pen myPen;
        const double xMin = -3.14;
        const double step = 0.01;
        const int Divisions = 60;
        static double k = 0;
        const int Arrow = 10;
        int x0, y0;
        Font MyFont;
        public Form7()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            myPen = new Pen(Color.Black, 1);
            k = (ClientSize.Width - 10) / 60;
            MyFont = new Font("Arial", 10);
        }

        private void Form7_Paint(object sender, PaintEventArgs e)
        {
            x0 = this.ClientSize.Width / 2;
            y0 = this.ClientSize.Height / 2;
            DrawY(new Point(x0, 0), new Point(x0, y0 * 2));
            DrawX(new Point(0, y0), new Point(x0 * 2, y0));
            double xMax = this.ClientSize.Width;
            int x1, x2, y1, y2;
            double x, y;
            x = -1 * this.ClientSize.Width;
            y = x * Math.Sin(x);
            x1 = (int)(x0 + x * k);
            y1 = (int)(y0 - y * k);
            while (x < xMax)
            {
                x = x + step;
                y = x * Math.Sin(x);
                x2 = (int)(x0 + x * k);
                y2 = (int)(y0 - y * k);
                if (x * Math.Sin(x) * x * Math.Sin(x) >= 0)
                    Graph.DrawLine(myPen, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
            }
        }
        private void DrawX(Point start, Point end)
        {
            int tmp = 5;
            for (float i = (float)k * 5; i < end.X - Arrow; i += 5 * (float)k)
            {
                Graph.DrawLine(myPen, i + ClientSize.Width / 2, -5 + ClientSize.Height / 2, i + ClientSize.Width / 2, 5 + ClientSize.Height / 2);
                Graph.DrawString(tmp.ToString(), MyFont, Brushes.Black, i + ClientSize.Width / 2 - 5, 5 + ClientSize.Height / 2);
                tmp += 5;
            }
            tmp = -5;
            for (float i = ClientSize.Width / 2 - (float)k * 5; i > start.X; i -= 5 * (float)k)
            {
                Graph.DrawLine(myPen, i, -5 + ClientSize.Height / 2, i, 5 + ClientSize.Height / 2);
                Graph.DrawString(tmp.ToString(), MyFont, Brushes.Black, i - 10, 5 + ClientSize.Height / 2);
                tmp -= 5;
            }
            Graph.DrawLine(myPen, 0, y0, x0 * 2, y0);
            Graph.DrawLine(myPen, ClientSize.Width, ClientSize.Height / 2, ClientSize.Width - Arrow, ClientSize.Height / 2 - Arrow / 2);
            Graph.DrawLine(myPen, ClientSize.Width, ClientSize.Height / 2, ClientSize.Width - Arrow, ClientSize.Height / 2 + Arrow / 2);
        }

        private void DrawY(Point start, Point end)
        {
            int tmp = 5;
            for (float i = -(float)k * 5 + ClientSize.Height / 2; i > Arrow; i -= (float)k * 5)
            {
                Graph.DrawLine(myPen, -5 + ClientSize.Width / 2, i, 5 + ClientSize.Width / 2, i);
                Graph.DrawString(tmp.ToString(), MyFont, Brushes.Black, ClientSize.Width / 2 - 30, i - 4);
                tmp += 5;
            }
            tmp = -5;

            for (float i = (float)k * 5 + ClientSize.Height / 2; i < ClientSize.Height - Arrow; i += (float)k * 5)
            {
                Graph.DrawLine(myPen, -5 + ClientSize.Width / 2, i, 5 + ClientSize.Width / 2, i);
                Graph.DrawString(tmp.ToString(), MyFont, Brushes.Black, ClientSize.Width / 2 - 30, i - 4);
                tmp -= 5;
            }
            Graph.DrawLine(myPen, x0, 0, x0, y0 * 2);
            Graph.DrawLine(myPen, ClientSize.Width / 2, 0, ClientSize.Width / 2 - Arrow / 2, Arrow);
            Graph.DrawLine(myPen, ClientSize.Width / 2, 0, ClientSize.Width / 2 + Arrow / 2, Arrow);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
