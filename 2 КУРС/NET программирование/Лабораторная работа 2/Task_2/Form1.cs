using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2
{
    public partial class Form1 : Form
    {
        Graphics Graph;
        Pen MyPen;
        int x, y;
        

        public Form1()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.White, 2);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.X;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Graph.DrawLine(MyPen, e.X, e.Y + 7, e.X, e.Y - 7); //vert
            Graph.DrawLine(MyPen, e.X + 5, e.Y - 5, e.X - 5, e.Y + 5);
            Graph.DrawLine(MyPen, e.X - 5, e.Y - 5, e.X + 5, e.Y + 5);
            Graph.DrawLine(MyPen, e.X - 6, e.Y, e.X + 6, e.Y); //gor
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}
