using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//14.	y=2+sin(x) на отрезке [-π, π]. 

namespace MainForm
{
    public partial class Form1 : Form
    {

        Graphics Graph;
        Pen MyPen;
        int x1, y1, x2, y2;
        double x, y;
        const double xMin = -Math.PI+0.147;
        const double xMax = Math.PI;
        const double step = 0.01;
        int k = 50;
        int otstup = 20;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyPen.Dispose();
            Graph.Dispose();
           
        }

        private void DrawArrow(int x, int y, int rotation)
        {
            if (rotation == 0)
            {
                Graph.DrawLine(MyPen, x, y, x + 10, y + 5);
                Graph.DrawLine(MyPen, x, y, x + 10, y - 5);
                Graph.DrawString("-x", new Font("Arial", 15), new SolidBrush(Color.Black), x,  x +520);
            }
            else
            if (rotation == 180)
            {
                Graph.DrawLine(MyPen, x, y, x - 10, y + 5);
                Graph.DrawLine(MyPen, x, y, x - 10, y - 5);
                Graph.DrawString("x", new Font("Arial", 15), new SolidBrush(Color.Black), ClientSize.Width / 2+940, ClientSize.Height / 2+10);
            }
            else
            if (rotation == 90)
            {
                Graph.DrawLine(MyPen, x + 5, y + 10 - 2, x, y - 2);
                Graph.DrawLine(MyPen, x - 5, y + 10 - 2, x, y - 2);
                Graph.DrawString("y", new Font("Arial", 15), new SolidBrush(Color.Black), ClientSize.Width / 2+10, ClientSize.Height / 2-515);
            }
            else
            if (rotation == 270)
            {
                Graph.DrawLine(MyPen, x + 5, y - 10 - 2, x, y);
                Graph.DrawLine(MyPen, x - 5, y - 10 - 2, x, y);
                Graph.DrawString("-y", new Font("Arial", 15), new SolidBrush(Color.Black), ClientSize.Width / 2 + 10, ClientSize.Height / 2 + 480);
            }

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawArrow(otstup-22, ClientSize.Height / 2, 0);
            DrawArrow(ClientSize.Width / 2, otstup-18, 90);
            DrawArrow(ClientSize.Width - otstup+20, ClientSize.Height / 2, 180);
            DrawArrow(ClientSize.Width / 2, ClientSize.Height - otstup+20, 270);
            double counter = 0.5;
            Graph.DrawLine(MyPen, 0, ClientSize.Height/2, ClientSize.Width, ClientSize.Height/2);
            Graph.DrawLine(MyPen, ClientSize.Width/2, 0, ClientSize.Width / 2, ClientSize.Height);
            for (int i = ClientSize.Width / 2 + (int)Math.PI * k / 2; i < ClientSize.Width - otstup; i += (int)Math.PI * k / 2)
            {
                Graph.DrawLine(MyPen, i, ClientSize.Height / 2 - 5, i, ClientSize.Height / 2 + 5);
                Graph.DrawString(counter.ToString() + "π", new Font("Arial", 10), new SolidBrush(Color.Black), i - 5, (ClientSize.Height / 2) + 5);
                counter += 0.5;
            }
            counter = -0.5;
            for (int i = ClientSize.Width / 2 - (int)Math.PI * k / 2; i > otstup; i -= (int)Math.PI * k / 2)
            {
                Graph.DrawLine(MyPen, i, ClientSize.Height / 2 - 5, i, ClientSize.Height / 2 + 5);
                Graph.DrawString(counter.ToString() + "π", new Font("Arial", 10), new SolidBrush(Color.Black), i - 5, (ClientSize.Height / 2) + 5);
                counter -= 0.5;
            }
            counter = 1;
            for (int i = ClientSize.Height / 2 - k; i > otstup; i -= k)
            {
                Graph.DrawLine(MyPen, ClientSize.Width / 2 + 5, i, ClientSize.Width / 2 - 5, i);
                Graph.DrawString(counter.ToString(), new Font("Arial",10), new SolidBrush(Color.Black), (ClientSize.Width / 2) + 5, i);
                counter += 1;
            }
            counter = -1;
            for (int i = ClientSize.Height / 2 + k; i < ClientSize.Height - otstup; i += k)
            {
                Graph.DrawLine(MyPen, ClientSize.Width / 2 + 5, i, ClientSize.Width / 2 - 5, i);
                Graph.DrawString(counter.ToString(), new Font("Arial",10), new SolidBrush(Color.Black), (ClientSize.Width / 2) + 5, i);
                counter -= 1;
            } 
            int x0 = this.ClientSize.Width / 2;
            int y0 = this.ClientSize.Height / 2;
            //фактические координаты в начальной точке заданного диапазона
            x = xMin;
            y = 2 + Math.Sin(x* (-Math.PI));
            //соответствующие им экранные координаты
            x1 = (int)(x0 + x * k);
            y1 = (int)(y0 - y * k); 
            while (x < xMax)
            {
                //определение фактических координат графика в следующей точке
                x = x + step;
                y = 2 + Math.Sin(x* Math.PI);
                //соответствующие им экранные координаты
                x2 = (int)(x0 + x * k);
                y2 = (int)(y0 - y * k);
                //вывод отрезка графика на экран
                Graph.DrawLine(MyPen, x1, y1, x2, y2);
                //запоминаем текущие координаты
                x1 = x2;
                y1 = y2;
            }

        }

        public Form1()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black);

        }





    }
}
