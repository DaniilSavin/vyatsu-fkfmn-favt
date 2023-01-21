using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task6
{
    public partial class Form2 : Form
    {
        Form1 form1;
        int shape, count, time;
        Pen MyPen;
        Color color = Color.FromArgb(0, 0, 128);
        int[] FShape = new int[3];
        int tick = 0;
        Rectangle[] fig = new Rectangle[3];
        Color[] FColor = new Color[3];
        Graphics Graph;
        Random Rand;
        SolidBrush MyBrush=new SolidBrush(Color.Blue);
        
        public Form2(int s, int c, int t)
        {
            InitializeComponent();
            shape = s;
            count = c;
            time = t;
            Graph = CreateGraphics();
            Rand = new Random();
            form1 = new Form1();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (tick == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    FColor[i] = Color.FromArgb(25, Rand.Next(0, 256), Rand.Next(0, 256), Rand.Next(0, 256));
                    fig[i].Width = Rand.Next(40, ClientSize.Width / 2);
                    fig[i].Height = Rand.Next(40, ClientSize.Height / 2);
                    fig[i].X = Rand.Next(20, ClientSize.Width - fig[i].Width - 20);
                    fig[i].Y = Rand.Next(20, ClientSize.Height - fig[i].Height - 20);
                    if (shape == 1) FShape[i] = 1;
                    else if (shape == 2) FShape[i] = 2;
                    else FShape[i] = Rand.Next(1, 3);
                }

                Graph.Clear(color);
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    MyBrush.Color = FColor[i];
                    if (FShape[i] == 1) Graph.FillRectangle(MyBrush, fig[i]);
                    else Graph.FillEllipse(MyBrush, fig[i]);
                }
            }
            tick = (tick + 4) % (time * 10 * 2);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть заставку?", "Закрыть заставку?", MessageBoxButtons.YesNo) == DialogResult.No) e.Cancel = true;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            Form1 form1 = new Form1();
            if (e.KeyCode == Keys.Space)
            {
                Close();
                

            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Graph.Clear(color);
            tick = 0;
            Timer.Start(); 
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Form1 form1 = new Form1();
            if (form1.RectangleRadioButton.Checked)
            {
                if (form1.OneRadioButton.Checked)
                {
                    int a = Rand.Next(256);
                    int b = Rand.Next(256);
                    int c = Rand.Next(256);
                    int n = Rand.Next(10);
                    MyPen = new Pen(Color.FromArgb(a, b, c), n);
                    MyBrush = new SolidBrush(Color.FromArgb(a, b, c));
                    int x0 = Rand.Next(n, this.ClientSize.Width);
                    int y0 = Rand.Next(n, this.ClientSize.Height);
                    int dx = this.ClientSize.Width - x0;
                    int dy = this.ClientSize.Height - y0;
                    int a1 = Rand.Next(1, Math.Min(dx, dy));
                    Graph.FillRectangle(MyBrush, x0, y0, a1, a1);
                    Graph.DrawRectangle(MyPen, x0, y0, a1, a1);
                }
                else if (form1.TwoRadioButton.Checked)
                {
                    for (int i=1;i<=2;i++)
                    {
                        int a = Rand.Next(256);
                        int b = Rand.Next(256);
                        int c = Rand.Next(256);
                        int n = Rand.Next(10);
                        MyPen = new Pen(Color.FromArgb(a, b, c), n);
                        MyBrush = new SolidBrush(Color.FromArgb(a, b, c));
                        int x0 = Rand.Next(n, this.ClientSize.Width);
                        int y0 = Rand.Next(n, this.ClientSize.Height);
                        int dx = this.ClientSize.Width - x0;
                        int dy = this.ClientSize.Height - y0;
                        int a1 = Rand.Next(1, Math.Min(dx, dy));
                        Graph.FillRectangle(MyBrush, x0, y0, a1, a1);
                        Graph.DrawRectangle(MyPen, x0, y0, a1, a1);
                    }
                }
            }
            if (form1.EllipseRadioButton.Checked)
            {
                if (form1.OneRadioButton.Checked)
                {
                    int a = Rand.Next(256);
                    int b = Rand.Next(256);
                    int c = Rand.Next(256);
                    int n = Rand.Next(10);
                    MyPen = new Pen(Color.FromArgb(a, b, c), n);
                    MyBrush = new SolidBrush(Color.FromArgb(a, b, c));
                    int x0 = Rand.Next(n, this.ClientSize.Width);
                    int y0 = Rand.Next(n, this.ClientSize.Height);
                    int dx = this.ClientSize.Width - x0;
                    int dy = this.ClientSize.Height - y0;
                    int a1 = Rand.Next(1, Math.Min(dx, dy));
                    Graph.FillEllipse(MyBrush, x0, y0, a1, a1);
                    Graph.DrawEllipse(MyPen, x0, y0, a1, a1);
                }
                else if (form1.TwoRadioButton.Checked)
                {
                    for (int i = 1; i <= 2; i++)
                    {
                        int a = Rand.Next(256);
                        int b = Rand.Next(256);
                        int c = Rand.Next(256);
                        int n = Rand.Next(10);
                        MyPen = new Pen(Color.FromArgb(a, b, c), n);
                        MyBrush = new SolidBrush(Color.FromArgb(a, b, c));
                        int x0 = Rand.Next(n, this.ClientSize.Width);
                        int y0 = Rand.Next(n, this.ClientSize.Height);
                        int dx = this.ClientSize.Width - x0;
                        int dy = this.ClientSize.Height - y0;
                        int a1 = Rand.Next(1, Math.Min(dx, dy));
                        Graph.FillEllipse(MyBrush, x0, y0, a1, a1);
                        Graph.DrawEllipse(MyPen, x0, y0, a1, a1);
                    }
                }
            }
            if (form1.RandomRadioButton.Checked)
            {
                if (form1.OneRadioButton.Checked)
                {
                    int a = Rand.Next(256);
                    int b = Rand.Next(256);
                    int c = Rand.Next(256);
                    int n = Rand.Next(10);
                    MyPen = new Pen(Color.FromArgb(a, b, c), n);
                    MyBrush = new SolidBrush(Color.FromArgb(a, b, c));
                    int x0 = Rand.Next(n, this.ClientSize.Width);
                    int y0 = Rand.Next(n, this.ClientSize.Height);
                    int dx = this.ClientSize.Width - x0;
                    int dy = this.ClientSize.Height - y0;
                    int a1 = Rand.Next(1, Math.Min(dx, dy));
                    Graph.FillEllipse(MyBrush, x0, y0, a1, a1);
                    Graph.DrawEllipse(MyPen, x0, y0, a1, a1);
                }
                else if (form1.TwoRadioButton.Checked)
                {
                    for (int i = 1; i <= 2; i++)
                    {
                        int a = Rand.Next(256);
                        int b = Rand.Next(256);
                        int c = Rand.Next(256);
                        int n = Rand.Next(10);
                        MyPen = new Pen(Color.FromArgb(a, b, c), n);
                        MyBrush = new SolidBrush(Color.FromArgb(a, b, c));
                        int x0 = Rand.Next(n, this.ClientSize.Width);
                        int y0 = Rand.Next(n, this.ClientSize.Height);
                        int dx = this.ClientSize.Width - x0;
                        int dy = this.ClientSize.Height - y0;
                        int a1 = Rand.Next(1, Math.Min(dx, dy));
                        Graph.FillEllipse(MyBrush, x0, y0, a1, a1);
                        Graph.DrawEllipse(MyPen, x0, y0, a1, a1);
                    }
                }
            }
        }
    }
}
