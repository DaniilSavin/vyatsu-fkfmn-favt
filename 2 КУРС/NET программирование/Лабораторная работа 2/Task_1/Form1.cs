using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1
{
    
    public partial class Form1 : Form
    {
        int x, y;
        Graphics Graph;
        Pen MyPen;
        Random r = new Random();
        Random Rand = new Random();
        int w;
        public Form1()
        {
            InitializeComponent();
            Graph = CreateGraphics();

            //  MyPen = new Pen(Color.FromArgb(r.Next(255), r.Next(255), r.Next(255), r.Next(255)), 4);

            // float[] dashValues = { 5, 4 };
            //  MyPen.DashPattern = dashValues;
            // Graph.DrawLine(MyPen, 25, 25, 250, 250);

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                w = Rand.Next(1, 50);
                MyPen = new Pen(Color.FromArgb(r.Next(255), r.Next(255), r.Next(255), r.Next(255)), w);
                float[] dashValues = { 5, 4 };
                MyPen.DashPattern = dashValues;
            }
            x = e.X;
            y = e.Y;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Graph.DrawLine(MyPen, x, y, e.X, e.Y);

        }
    }
}
