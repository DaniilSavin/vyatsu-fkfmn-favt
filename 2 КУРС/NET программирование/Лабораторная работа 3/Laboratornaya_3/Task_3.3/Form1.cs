using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3._3
{
    public partial class Form1 : Form
    {
        Graphics Graph;
        Pen MyPen;
        Font MyFont;
        SolidBrush MyBrush;
        bool ch = false;
        int x0;
        int y0;
        int x1, y1, x2, y2;
        int w = 10;
        int h = 10;
    double kx = 5; double ky = 5;
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (!ch)
            {
                x1 = this.ClientSize.Width / 2;
                y1 = this.ClientSize.Height / 2;
                ch = true;
               
            }
            Graph = CreateGraphics();
            MyFont = new Font("Arial", 10, FontStyle.Bold);
            MyBrush = new SolidBrush(Color.Black);


            this.Invalidate();
            this.Update();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black);

            
            if (e.KeyCode == Keys.Up && e.Shift)
            {
                
                    h -= 10;
                    w -= 10;
                
            }
            else
                if (e.KeyCode == Keys.Down && e.Shift)
            {
                if (y1 + w+10 < this.ClientSize.Height)
                {
                    h += 10;
                    w += 10;
                }
                else
                {
                    MessageBox.Show("Вы выйдете за границу окна!","WARNING!");
                }
            }



            if (e.KeyCode == Keys.Up && (!e.Shift))
            {
                if (y1-1 >0)
                    y1 -= 1;
            }
            else
            if (e.KeyCode == Keys.Down && (!e.Shift))
            {
                if (y1 + w + 1 < this.ClientSize.Height)
                    y1 += 1;
            }
            else
            if (e.KeyCode == Keys.Right && (!e.Shift))
            {
                if (y1 + w+1 < this.ClientSize.Height)
                    x1 += 1;
            }
            else
            if (e.KeyCode == Keys.Left && (!e.Shift))
            {
                if (x1 -1>0)
                    x1 -= 1;
            }




            Graph.DrawString("x1= " + x1 + "\ny1= " + y1 + "\nw= " + w + "\nh= " + h, MyFont, MyBrush, 50, 150);


            MyPen = new Pen(Color.Black);
            this.Text = this.ClientSize.Width + " " + this.ClientSize.Height +" | "+  (int)(x1 + w) + " "+ (int)(y1 + h);
            
                
                Graph.DrawRectangle(MyPen, x1, y1, w, h);
            
          



        }
    }
}
