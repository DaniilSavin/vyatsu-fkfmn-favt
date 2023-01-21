using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace _5._2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate();
            this.Update();
            int length = int.Parse(lengthtb.Text);
            int kolvo = int.Parse(kvadtb.Text);
            int Width = this.Width;
            int Height = this.Height;
             int i = 1;
            while (i < kolvo)
            {
                Width /= 2;
                Height /= 2; 
                Pen myPen = new Pen(Color.Blue, 2);
                Graphics myGraphics = CreateGraphics();
                myGraphics.DrawRectangle(myPen, Width, Height, length, length);
                length /= 2;
                myGraphics.DrawRectangle(myPen, (int)this.Width / 2 + length / 2, (int)this.Height / 2 + length / 2, length, length);
                i++;
            }

        }
    }
}
