using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_4
{
    public partial class Form1 : Form
    {
        Graphics Graph;
        Pen MyPen;
        int x, y;
        int x1=0, y1=0;
        bool draw=true;
        public Form1()
        {
            InitializeComponent();
            Graph = CreateGraphics();
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draw = true;
                if (x1 == 0 && y1 == 0)
                {
                    x1 = e.X;
                    y1 = e.Y;
                }
            }
            else
            {
                Graph.DrawLine(MyPen, x1, y1, e.X, e.Y);
                x1 = 0;
                y1 = 0;
                draw = false;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            MyPen = new Pen(Color.Black, 1);
            if (draw) Graph.DrawLine(MyPen, x, y, e.X, e.Y);
            x = e.X;
            y = e.Y;

        }
    }
}
