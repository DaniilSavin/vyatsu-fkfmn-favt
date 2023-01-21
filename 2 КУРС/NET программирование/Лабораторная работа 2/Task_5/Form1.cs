using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_5
{
    public partial class Form1 : Form
    {

        Graphics Graph;
        Pen MyPen;
        int x, y;
        int x1, y1;
        int switcher = 1;

        public Form1()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (switcher)
            {
                case 1:
                    x = e.X;
                    y = e.Y;
                    switcher++;
                    break;
                case 2:
                    x1 = e.X;
                    y1 = e.Y;
                    Graph.DrawLine(MyPen, x, y, e.X, e.Y);
                    switcher++;
                    break;
                case 3:
                    Graph.DrawLine(MyPen, x1, y1, e.X, e.Y);
                    Graph.DrawLine(MyPen, e.X, e.Y, x, y);
                    switcher = 1;
                    break;

            }

        }
    }
}

