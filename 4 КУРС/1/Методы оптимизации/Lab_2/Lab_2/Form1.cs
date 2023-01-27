<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        double[,] C;
        public Form1()
        {
            InitializeComponent();
            C = new double[2, 6];
        }

        private double Function0(double x, double[] y)
        {
            return y[1];
        }
        private double Function1(double x, double[] y)
        {
            //    h                   p              a1                a2                      b           b1
            return C[1, 5] * Math.Sin(C[1, 4] * x) - C[1, 0] * y[0] - C[1, 1] * y[0] * y[0] + (C[1, 2] - C[1, 3] * y[0] * y[0]) * y[1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Stream myStream;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        StreamReader streamReader = new StreamReader(myStream);
                        string line;
                        int i = 0;
                        while (!streamReader.EndOfStream)
                        {
                            line = streamReader.ReadLine();
                            string[] s = line.Split(' ');
                            for (int j = 0; j < s.Length; j++)
                            {
                                C[i, j] = double.Parse(s[j]);
                            }
                            i++;
                        }
                        streamReader.Close();
                    }
                    myStream.Close();
                }
                richTextBox1.Clear();
                richTextBox1.AppendText("1) dx1/dt = " + C[0, 0] + "x1 + " + C[0, 1] + "x1x2 + " + C[0, 2] + "x1x1\n");
                richTextBox1.AppendText("2) dx1/dt = " + C[1, 0] + "x2 + " + C[1, 1] + "x2x1 + " + C[1, 2] + "x2x2\n");
               
                double[] pop = new double[2];
                pop[0] = 2.0;
                pop[1] = 0.0;
                double t = 0;
                double h = 0.0001;
                List<double[]> xValue = new List<double[]>();
                List<double> tValue = new List<double>();
                double maxt = 0, maxx1 = 0, maxx2 = 0;
                for (int i = 0; t < 30; t += 2 * h, i++)
                {
                    xValue.Add(new double[2]);
                    xValue[i][0] = pop[0];
                    xValue[i][1] = pop[1];
                    maxx1 = Math.Max(maxx1, Math.Abs(pop[0]));
                    maxx2 = Math.Max(maxx2, Math.Abs(pop[1]));
                    tValue.Add(t);
                    pop = Runge_kutt4(pop, h, t);
                    maxt = t;
                }
                int X0, Y0;
                X0 = 35;
                Y0 = pictureBox2.Height - 25;
                Graphics graph = pictureBox2.CreateGraphics();
                graph.Clear(BackColor);
                Pen myPen = new Pen(Brushes.Black, 3);
                graph.DrawLine(myPen, X0, (Y0 + 25) / 2, pictureBox2.Width - 25, (Y0 + 25) / 2);
                graph.DrawLine(myPen, X0, Y0, X0, 23);
                int x = (pictureBox2.Width - 50) / 20;
                int y = (pictureBox2.Height - 50) / 20;
                int Y = Y0, X = X0;
                for (int i = 0; i <= 20; i++)
                {
                    graph.DrawLine(myPen, X0 - 5, Y, X0 + 5, Y);
                    graph.DrawLine(myPen, X, (Y0 + 25) / 2 - 5, X, (Y0 + 25) / 2 + 5);
                    if (i != 0)
                        graph.DrawString((Math.Round(maxt / 20, 2) * (i)).ToString(), Font, Brushes.Black, (float)(X - 5), (Y0 + 25) / 2 + 10);
                    graph.DrawString((Math.Round(maxx1 / 10, 2) * (i - 10)).ToString(), Font, Brushes.Black, X0 - 35, (float)(Y - 5));
                    X += x;
                    Y -= y;
                }
                graph.DrawString("t", Font, Brushes.Black, (float)(X - 10), Y0 / 2 + 5);
                graph.DrawString("x", Font, Brushes.Black, X0 - 15, (float)(Y + 5));
                graph.DrawLine(myPen, pictureBox2.Width - 35, (Y0 + 25) / 2 + 5, pictureBox2.Width - 23, (Y0 + 25) / 2);
                graph.DrawLine(myPen, pictureBox2.Width - 35, (Y0 + 25) / 2 - 5, pictureBox2.Width - 23, (Y0 + 25) / 2);
                graph.DrawLine(myPen, X0 - 5, 30, X0, 20);
                graph.DrawLine(myPen, X0 + 5, 30, X0, 20);

                Pen myPen1 = new Pen(Color.Green, 1);
                for (int i = 0; i < tValue.Count - 1; i++)
                {

                    float x1 = X0 + (float)(tValue[i] / maxt * (pictureBox2.Width - 65));
                    float y1 = (Y0 + 25) / 2 - (float)(xValue[i][0] / maxx1 * (pictureBox2.Height / 2 - 25));
                    float x2 = X0 + (float)(tValue[i + 1] / maxt * (pictureBox2.Width - 65));
                    float y2 = (Y0 + 25) / 2 - (float)(xValue[i + 1][0] / maxx1 * (pictureBox2.Height / 2 - 25));
                    graph.DrawLine(myPen1, x1, y1, x2, y2);
                }
                //graph = pictureBox2.CreateGraphics();
                //graph.Clear(BackColor);
                //X0 = 25;
                //Y0 = pictureBox2.Height - 25;
                //graph.DrawLine(myPen, X0, (Y0 + 25) / 2, pictureBox2.Width - 25, (Y0 + 25) / 2);
                //graph.DrawLine(myPen, (pictureBox2.Width) / 2, Y0, (pictureBox2.Width) / 2, 23);
                //x = (pictureBox2.Width - 50) / 20;
                //y = (pictureBox2.Height - 50) / 20;
                //Y = Y0;
                //X = X0;
                //for (int i = 0; i <= 20; i++)
                //{
                //    graph.DrawLine(myPen, (pictureBox2.Width) / 2 - 5, Y, (pictureBox2.Width) / 2 + 5, Y);
                //    graph.DrawLine(myPen, X, (Y0 + 25) / 2 - 5, X, (Y0 + 25) / 2 + 5);
                //    if (i != 10)
                //        graph.DrawString((Math.Round(maxx1 / 10, 2) * (i - 10)).ToString(), Font, Brushes.Black, (float)(X - 8), (Y0 + 25) / 2 + 10);
                //    if (i != 10)
                //        graph.DrawString((Math.Round(maxx2 / 10, 2) * (i - 10)).ToString(), Font, Brushes.Black, (pictureBox2.Width) / 2 - 35, (float)(Y - 5));
                //    if (i == 10)
                //        graph.DrawString((Math.Round(maxx1 / 10, 2) * (i - 10)).ToString(), Font, Brushes.Black, (float)(X - 13), (Y0 + 25) / 2 + 10);
                //    X += x;
                //    Y -= y;
                //}
                //graph.DrawString("x1", Font, Brushes.Black, (float)(X - 20), (Y0 + 25) / 2 - 5);
                //graph.DrawString("x2", Font, Brushes.Black, (pictureBox2.Width) / 2 - 15, (float)(Y + 5));
                //graph.DrawLine(myPen, pictureBox2.Width - 35, (Y0 + 25) / 2 + 5, pictureBox2.Width - 23, (Y0 + 25) / 2);
                //graph.DrawLine(myPen, pictureBox2.Width - 35, (Y0 + 25) / 2 - 5, pictureBox2.Width - 23, (Y0 + 25) / 2);
                //graph.DrawLine(myPen, (pictureBox2.Width) / 2 - 5, 30, (pictureBox2.Width) / 2, 20);
                //graph.DrawLine(myPen, (pictureBox2.Width) / 2 + 5, 30, (pictureBox2.Width) / 2, 20);

                //myPen1 = new Pen(Color.Blue, 1);
                //graph.FillEllipse(Brushes.Blue, (pictureBox2.Width) / 2 + (float)(xValue[0][0] / maxx1 * (pictureBox2.Width / 2 - 25)) - 3, (Y0 + 25) / 2 - (float)(xValue[0][1] / maxx2 * (pictureBox2.Height / 20)) - 3, 6, 6);
                //for (int i = 0; i < xValue.Count - 1; i++)
                //{
                //    graph.DrawLine(myPen1, (pictureBox2.Width) / 2 + (float)(xValue[i][0] / maxx1 * (pictureBox2.Width / 2 - 25)), (Y0 + 25) / 2 - (float)(xValue[i][1] / maxx2 * (pictureBox2.Height / 2 - 25)),
                //        (pictureBox2.Width) / 2 + (float)(xValue[i + 1][0] / maxx1 * (pictureBox2.Width / 2 - 25)), (Y0 + 25) / 2 - (float)(xValue[i + 1][1] / maxx2 * (pictureBox2.Height / 2 - 25)));

                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private double[] Runge_kutt4(double[] x, double h, double t)
        {
            double[] results = new double[2];
            double k1, k2, k3, k4, m1, m2, m3, m4;
            k1 = h * Function0(t, x);
            m1 = h * Function1(t, x);
            k2 = h * Function0(t + h / 2, new double[2] { x[0] + k1 / 2, x[1] + m1 / 2 });
            m2 = h * Function1(t + h / 2, new double[2] { x[0] + k1 / 2, x[1] + m1 / 2 });
            k3 = h * Function0(t + h / 2, new double[2] { x[0] + k2 / 2, x[1] + m2 / 2 });
            m3 = h * Function0(t + h / 2, new double[2] { x[0] + k2 / 2, x[1] + m2 / 2 });
            k4 = h * Function1(t + h, new double[2] { x[0] + k3, x[1] + m1 });
            m4 = h * Function1(t + h, new double[2] { x[0] + k3, x[1] + m1 });
            results[0] = Math.Max(x[0] + (k1 + 2 * k2 + 2 * k3 + k4) / 6, 0);
            results[1] = Math.Max(x[1] + (m1 + 2 * m2 + 2 * m3 + m4) / 6, 0);
            return results;
        }

    }

}

=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        double[,] C;
        public Form1()
        {
            InitializeComponent();
            C = new double[2, 6];
        }

        private double Function0(double x, double[] y)
        {
            return y[1];
        }
        private double Function1(double x, double[] y)
        {
            //    h                   p              a1                a2                      b           b1
            return C[1, 5] * Math.Sin(C[1, 4] * x) - C[1, 0] * y[0] - C[1, 1] * y[0] * y[0] + (C[1, 2] - C[1, 3] * y[0] * y[0]) * y[1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Stream myStream;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        StreamReader streamReader = new StreamReader(myStream);
                        string line;
                        int i = 0;
                        while (!streamReader.EndOfStream)
                        {
                            line = streamReader.ReadLine();
                            string[] s = line.Split(' ');
                            for (int j = 0; j < s.Length; j++)
                            {
                                C[i, j] = double.Parse(s[j]);
                            }
                            i++;
                        }
                        streamReader.Close();
                    }
                    myStream.Close();
                }
                richTextBox1.Clear();
                richTextBox1.AppendText("1) dx1/dt = " + C[0, 0] + "x1 + " + C[0, 1] + "x1x2 + " + C[0, 2] + "x1x1\n");
                richTextBox1.AppendText("2) dx1/dt = " + C[1, 0] + "x2 + " + C[1, 1] + "x2x1 + " + C[1, 2] + "x2x2\n");
               
                double[] pop = new double[2];
                pop[0] = 2.0;
                pop[1] = 0.0;
                double t = 0;
                double h = 0.0001;
                List<double[]> xValue = new List<double[]>();
                List<double> tValue = new List<double>();
                double maxt = 0, maxx1 = 0, maxx2 = 0;
                for (int i = 0; t < 30; t += 2 * h, i++)
                {
                    xValue.Add(new double[2]);
                    xValue[i][0] = pop[0];
                    xValue[i][1] = pop[1];
                    maxx1 = Math.Max(maxx1, Math.Abs(pop[0]));
                    maxx2 = Math.Max(maxx2, Math.Abs(pop[1]));
                    tValue.Add(t);
                    pop = Runge_kutt4(pop, h, t);
                    maxt = t;
                }
                int X0, Y0;
                X0 = 35;
                Y0 = pictureBox2.Height - 25;
                Graphics graph = pictureBox2.CreateGraphics();
                graph.Clear(BackColor);
                Pen myPen = new Pen(Brushes.Black, 3);
                graph.DrawLine(myPen, X0, (Y0 + 25) / 2, pictureBox2.Width - 25, (Y0 + 25) / 2);
                graph.DrawLine(myPen, X0, Y0, X0, 23);
                int x = (pictureBox2.Width - 50) / 20;
                int y = (pictureBox2.Height - 50) / 20;
                int Y = Y0, X = X0;
                for (int i = 0; i <= 20; i++)
                {
                    graph.DrawLine(myPen, X0 - 5, Y, X0 + 5, Y);
                    graph.DrawLine(myPen, X, (Y0 + 25) / 2 - 5, X, (Y0 + 25) / 2 + 5);
                    if (i != 0)
                        graph.DrawString((Math.Round(maxt / 20, 2) * (i)).ToString(), Font, Brushes.Black, (float)(X - 5), (Y0 + 25) / 2 + 10);
                    graph.DrawString((Math.Round(maxx1 / 10, 2) * (i - 10)).ToString(), Font, Brushes.Black, X0 - 35, (float)(Y - 5));
                    X += x;
                    Y -= y;
                }
                graph.DrawString("t", Font, Brushes.Black, (float)(X - 10), Y0 / 2 + 5);
                graph.DrawString("x", Font, Brushes.Black, X0 - 15, (float)(Y + 5));
                graph.DrawLine(myPen, pictureBox2.Width - 35, (Y0 + 25) / 2 + 5, pictureBox2.Width - 23, (Y0 + 25) / 2);
                graph.DrawLine(myPen, pictureBox2.Width - 35, (Y0 + 25) / 2 - 5, pictureBox2.Width - 23, (Y0 + 25) / 2);
                graph.DrawLine(myPen, X0 - 5, 30, X0, 20);
                graph.DrawLine(myPen, X0 + 5, 30, X0, 20);

                Pen myPen1 = new Pen(Color.Green, 1);
                for (int i = 0; i < tValue.Count - 1; i++)
                {

                    float x1 = X0 + (float)(tValue[i] / maxt * (pictureBox2.Width - 65));
                    float y1 = (Y0 + 25) / 2 - (float)(xValue[i][0] / maxx1 * (pictureBox2.Height / 2 - 25));
                    float x2 = X0 + (float)(tValue[i + 1] / maxt * (pictureBox2.Width - 65));
                    float y2 = (Y0 + 25) / 2 - (float)(xValue[i + 1][0] / maxx1 * (pictureBox2.Height / 2 - 25));
                    graph.DrawLine(myPen1, x1, y1, x2, y2);
                }
                //graph = pictureBox2.CreateGraphics();
                //graph.Clear(BackColor);
                //X0 = 25;
                //Y0 = pictureBox2.Height - 25;
                //graph.DrawLine(myPen, X0, (Y0 + 25) / 2, pictureBox2.Width - 25, (Y0 + 25) / 2);
                //graph.DrawLine(myPen, (pictureBox2.Width) / 2, Y0, (pictureBox2.Width) / 2, 23);
                //x = (pictureBox2.Width - 50) / 20;
                //y = (pictureBox2.Height - 50) / 20;
                //Y = Y0;
                //X = X0;
                //for (int i = 0; i <= 20; i++)
                //{
                //    graph.DrawLine(myPen, (pictureBox2.Width) / 2 - 5, Y, (pictureBox2.Width) / 2 + 5, Y);
                //    graph.DrawLine(myPen, X, (Y0 + 25) / 2 - 5, X, (Y0 + 25) / 2 + 5);
                //    if (i != 10)
                //        graph.DrawString((Math.Round(maxx1 / 10, 2) * (i - 10)).ToString(), Font, Brushes.Black, (float)(X - 8), (Y0 + 25) / 2 + 10);
                //    if (i != 10)
                //        graph.DrawString((Math.Round(maxx2 / 10, 2) * (i - 10)).ToString(), Font, Brushes.Black, (pictureBox2.Width) / 2 - 35, (float)(Y - 5));
                //    if (i == 10)
                //        graph.DrawString((Math.Round(maxx1 / 10, 2) * (i - 10)).ToString(), Font, Brushes.Black, (float)(X - 13), (Y0 + 25) / 2 + 10);
                //    X += x;
                //    Y -= y;
                //}
                //graph.DrawString("x1", Font, Brushes.Black, (float)(X - 20), (Y0 + 25) / 2 - 5);
                //graph.DrawString("x2", Font, Brushes.Black, (pictureBox2.Width) / 2 - 15, (float)(Y + 5));
                //graph.DrawLine(myPen, pictureBox2.Width - 35, (Y0 + 25) / 2 + 5, pictureBox2.Width - 23, (Y0 + 25) / 2);
                //graph.DrawLine(myPen, pictureBox2.Width - 35, (Y0 + 25) / 2 - 5, pictureBox2.Width - 23, (Y0 + 25) / 2);
                //graph.DrawLine(myPen, (pictureBox2.Width) / 2 - 5, 30, (pictureBox2.Width) / 2, 20);
                //graph.DrawLine(myPen, (pictureBox2.Width) / 2 + 5, 30, (pictureBox2.Width) / 2, 20);

                //myPen1 = new Pen(Color.Blue, 1);
                //graph.FillEllipse(Brushes.Blue, (pictureBox2.Width) / 2 + (float)(xValue[0][0] / maxx1 * (pictureBox2.Width / 2 - 25)) - 3, (Y0 + 25) / 2 - (float)(xValue[0][1] / maxx2 * (pictureBox2.Height / 20)) - 3, 6, 6);
                //for (int i = 0; i < xValue.Count - 1; i++)
                //{
                //    graph.DrawLine(myPen1, (pictureBox2.Width) / 2 + (float)(xValue[i][0] / maxx1 * (pictureBox2.Width / 2 - 25)), (Y0 + 25) / 2 - (float)(xValue[i][1] / maxx2 * (pictureBox2.Height / 2 - 25)),
                //        (pictureBox2.Width) / 2 + (float)(xValue[i + 1][0] / maxx1 * (pictureBox2.Width / 2 - 25)), (Y0 + 25) / 2 - (float)(xValue[i + 1][1] / maxx2 * (pictureBox2.Height / 2 - 25)));

                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private double[] Runge_kutt4(double[] x, double h, double t)
        {
            double[] results = new double[2];
            double k1, k2, k3, k4, m1, m2, m3, m4;
            k1 = h * Function0(t, x);
            m1 = h * Function1(t, x);
            k2 = h * Function0(t + h / 2, new double[2] { x[0] + k1 / 2, x[1] + m1 / 2 });
            m2 = h * Function1(t + h / 2, new double[2] { x[0] + k1 / 2, x[1] + m1 / 2 });
            k3 = h * Function0(t + h / 2, new double[2] { x[0] + k2 / 2, x[1] + m2 / 2 });
            m3 = h * Function0(t + h / 2, new double[2] { x[0] + k2 / 2, x[1] + m2 / 2 });
            k4 = h * Function1(t + h, new double[2] { x[0] + k3, x[1] + m1 });
            m4 = h * Function1(t + h, new double[2] { x[0] + k3, x[1] + m1 });
            results[0] = Math.Max(x[0] + (k1 + 2 * k2 + 2 * k3 + k4) / 6, 0);
            results[1] = Math.Max(x[1] + (m1 + 2 * m2 + 2 * m3 + m4) / 6, 0);
            return results;
        }

    }

}

>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
