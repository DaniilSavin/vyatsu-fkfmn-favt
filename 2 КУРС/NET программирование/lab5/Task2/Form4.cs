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
    public partial class Form4 : Form
    {
        int Seconds = 0;
        Pen MyPen;
        Graphics G;
        int radius = 30;
        int TL;
        bool UpDown;
        int X;
        int Y;
        public Form4()
        {
            InitializeComponent();
            timer1.Start();
            UpDown = true;
            MyPen = new Pen(Color.Yellow, 5);
            G = CreateGraphics();
            TL = Math.Min(ClientSize.Width, ClientSize.Height) - (3 * radius) / 2;
            X = ClientSize.Width / 2;
            Y = TL + radius / 2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Seconds += 10;
            G.Clear(BackColor);
            G.DrawEllipse(MyPen, X - radius / 2, TL, radius, radius);
            G.FillEllipse(Brushes.Yellow, X - radius / 2, TL, radius, radius);
            G.DrawLine(MyPen, X, Y + radius, X, Y - radius);
            G.DrawLine(MyPen, X + radius, Y, X - radius, Y);
            G.DrawLine(MyPen, X - radius * (float)Math.Sqrt(3) / 2, Y - radius * (float)Math.Sqrt(1) / 2, X + radius * (float)Math.Sqrt(3) / 2, Y + radius * (float)Math.Sqrt(1) / 2);
            G.DrawLine(MyPen, X - radius * (float)Math.Sqrt(1) / 2, Y + radius * (float)Math.Sqrt(3) / 2, X + radius * (float)Math.Sqrt(1) / 2, Y - radius * (float)Math.Sqrt(3) / 2);
            G.DrawLine(MyPen, X - radius * (float)Math.Sqrt(3) / 2, Y + radius * (float)Math.Sqrt(1) / 2, X + radius * (float)Math.Sqrt(3) / 2, Y - radius * (float)Math.Sqrt(1) / 2);
            G.DrawLine(MyPen, X - radius * (float)Math.Sqrt(1) / 2, Y - radius * (float)Math.Sqrt(3) / 2, X + radius * (float)Math.Sqrt(1) / 2, Y + radius * (float)Math.Sqrt(3) / 2);

            if (Y - radius >= 0 && UpDown == true)
            {
                radius += 1;
                TL -= 2;
                Y = TL + radius / 2;
                if (Y - radius <= 0) UpDown = false;
            }
            else if (Y + radius <= ClientSize.Height && UpDown == false)
            {
                radius -= 1;
                TL += 2;
                Y = TL + radius / 2;
                if (Y + radius >= ClientSize.Height) UpDown = true;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
