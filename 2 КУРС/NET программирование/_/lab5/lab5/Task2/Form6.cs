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
    public partial class Form6 : Form
    {
        static Graphics Graph;
        Pen MyPen = new Pen(Color.Black, 1);
        static int size = 20; 
        static int color = 1; 
        static int number = 1; 
        static void printarea(int x0, int y0)
        {
            if (number == 64)
            {
                Graph.FillRectangle(Brushes.Black, x0, y0, size, size);
                return;
            }
            else
            {
                if (number % 8 == 0)
                    if (color == 1)
                    {
                        Graph.FillRectangle(Brushes.Black, x0, y0, size, size);
                        x0 = x0 - 7 * size; 
                        y0 = y0 + size; 
                    }
                    else
                    {
                        Graph.FillRectangle(Brushes.White, x0, y0, size, size);
                        x0 = x0 - 7 * size;
                        y0 = y0 + size;
                    }
                else
                {
                    if (color == 1)
                    {
                        Graph.FillRectangle(Brushes.Black, x0, y0, size, size);
                        x0 = x0 + size; 
                        color = 0;
                    }
                    else
                    {
                        Graph.FillRectangle(Brushes.White, x0, y0, size, size);
                        x0 = x0 + size; 
                        color = 1;
                    }
                }
            }
            number++;
            printarea(x0, y0);
        }
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void Form6_Paint(object sender, PaintEventArgs e)
        {
            Graph = CreateGraphics();
            int x = ClientSize.Width / 2 - 4 * size;
            int y = ClientSize.Height / 2 - 4 * size;
            number = 1;
            printarea(x, y);
            Graph.DrawRectangle(MyPen, x, y, 8 * size, 8 * size); 

            int d1 = x - size, d2 = y + size / 5;
            Point p;
            p = new Point(d1, d2);
            label1.Location = p;
            d2 = d2 + size;
            p = new Point(d1, d2);
            label2.Location = p;
            d2 = d2 + size;
            p = new Point(d1, d2);
            label3.Location = p;
            d2 = d2 + size;
            p = new Point(d1, d2);
            label4.Location = p;
            d2 = d2 + size;
            p = new Point(d1, d2);
            label5.Location = p;
            d2 = d2 + size;
            p = new Point(d1, d2);
            label6.Location = p;
            d2 = d2 + size;
            p = new Point(d1, d2);
            label7.Location = p;
            d2 = d2 + size;
            p = new Point(d1, d2);
            label8.Location = p;

            d2 = y - size;
            d1 = x + size / 5;

            p = new Point(d1, d2);
            label9.Location = p;
            d1 = d1 + size;
            p = new Point(d1, d2);
            label10.Location = p;
            d1 = d1 + size;
            p = new Point(d1, d2);
            label11.Location = p;
            d1 = d1 + size;
            p = new Point(d1, d2);
            label12.Location = p;
            d1 = d1 + size;
            p = new Point(d1, d2);
            label13.Location = p;
            d1 = d1 + size;
            p = new Point(d1, d2);
            label14.Location = p;
            d1 = d1 + size;
            p = new Point(d1, d2);
            label15.Location = p;
            d1 = d1 + size;
            p = new Point(d1, d2);
            label16.Location = p;

        }

        private void Form6_Resize(object sender, EventArgs e)
        {
            Graph = CreateGraphics();
            int x = ClientSize.Width / 2 - 4 * size;
            int y = ClientSize.Height / 2 - 4 * size;
            number = 1;
            printarea(x, y);
            Graph.DrawRectangle(MyPen, x, y, 8 * size, 8 * size); 
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
