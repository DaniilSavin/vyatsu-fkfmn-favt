using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3._4
{


    public partial class Form1 : Form
    {

        Graphics Graph;
        Pen MyPen;
        int x1;
        int y1;
        public Form1()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black,1);
            MinimumSize = new Size(150, 150);   
                int x = Size.Width;
                int y = Size.Height;
                Text = x + " x " + y;
             x1 = Size.Width / 2;
             y1= Size.Height / 2;
            Graph.DrawEllipse(MyPen, x1,y1,500,500);
            
            
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Graph.DrawEllipse(MyPen, x1, y1, 30, 30);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int x = Size.Width;
            int y = Size.Height;
            Text = x + " x " + y;
            Graph.DrawEllipse(MyPen, x1, y1, 30, 30);
        }
    }
}
