using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3
{
    public partial class Form1 : Form
    {
        Graphics Graph;
        Pen MyPen;
        int x, y;
        Random r = new Random();
        Random Rand = new Random();
        int f;
        Brush MyPen2;
        public Form1()
        {
            
            InitializeComponent();
            
            Graph = CreateGraphics();
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.X;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            f = Rand.Next(1, 50);
            MyPen = new Pen(Color.FromArgb(r.Next(255), r.Next(255), r.Next(255), r.Next(255)), f);
            MyPen2 = new SolidBrush(Color.FromArgb(r.Next(255), r.Next(255), r.Next(255), r.Next(255)));
            int w = Math.Abs(e.X - x);
            int h = Math.Abs(y - e.Y);
            x = Math.Min(e.X, x);
            y = Math.Min(e.Y, y);
            Graph.DrawEllipse(MyPen, x, y, w, h);
            Graph.FillEllipse(MyPen2, x+5, y+5, w-5, h-5);
        }
    }
}
