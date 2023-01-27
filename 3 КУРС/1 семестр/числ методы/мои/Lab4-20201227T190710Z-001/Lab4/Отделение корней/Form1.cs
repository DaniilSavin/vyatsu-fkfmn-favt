using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Отделение_корней
{
    public partial class Form1 : Form
    {
        Graphics graph;
        Pen myPen;
        double kx = 35, ky = 35;
        Font MyFont = new Font("Arial", 7, FontStyle.Bold);
        int now;
        int x0;
        int y0;
        int sign = 0;//1-"+", -1-"-"
        bool enough = false;

        public Form1()
        {
            InitializeComponent();
            graph = CreateGraphics();
            myPen = new Pen(Color.Black, 3);
            now = 0;
            x0 = this.ClientSize.Width / 2 + 450;
            y0 = this.ClientSize.Height / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            double currentY;
            double h = double.Parse(textBoxh.Text);
            for (double i = double.Parse(textBoxA.Text); i <= double.Parse(textBoxB.Text); i += h)
            {
                currentY = F(i);
                dataGridView1.Rows.Add(i, F(i));
                if (i != double.Parse(textBoxA.Text) && currentY * double.Parse(dataGridView1[1, dataGridView1.Rows.Count - 3].Value.ToString()) <= 0)
                    dataGridView2.Rows.Add((double)dataGridView1[0, dataGridView1.Rows.Count - 3].Value, i);
            }
            if (dataGridView2.RowCount == 1)
            {
                MessageBox.Show("Не найдено корней!");
            }
            else
                button2.Enabled = true;
        }

        static double F(double x)
        {
            //return x * x - 3;
            return Math.Log10(x) - x / 2 + 1;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonIteration.Enabled = true;
            button_plus.Enabled = true;
            now = 0;
            enough = false;
            graph.Clear(BackColor);
            kx = 35; ky = 35;
            x0 = this.ClientSize.Width / 2 + 450;

            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            double x1 = (double)(dataGridView2[0, dataGridView2.CurrentRow.Index].Value);
            double x2 = (double)(dataGridView2[1, dataGridView2.CurrentRow.Index].Value);
            double E = double.Parse(textBoxE.Text);
            bool cont = (x2 - x1) >= E;
            int i = 0;

            while (cont)
            {
                dataGridView3.Rows.Add();
                dataGridView3["num", i].Value = i + 1;
                dataGridView3["a", i].Value = x1;
                dataGridView3["b", i].Value = x2;
                dataGridView3["c", i].Value = ((double)(dataGridView3["a", i].Value) + (double)(dataGridView3["b", i].Value)) / 2;
                dataGridView3["lenAB", i].Value = (double)(dataGridView3["b", i].Value) - (double)(dataGridView3["a", i].Value);
                if ((double)dataGridView3["lenAB", i].Value < E)
                {
                    dataGridView3["end", i].Value = "да";
                    cont = false;
                }
                else
                    dataGridView3["end", i].Value = "нет";

                dataGridView3["f_a", i].Value = F((double)dataGridView3["a", i].Value).ToString("0.#########################");
                dataGridView3["f_c", i].Value = F((double)dataGridView3["c", i].Value).ToString("0.#########################");
                dataGridView3["f_b", i].Value = F((double)dataGridView3["b", i].Value).ToString("0.#########################");

                if (double.Parse(dataGridView3["f_a", i].Value.ToString().Replace(".", ",")) * double.Parse(dataGridView3["f_c", i].Value.ToString().Replace(".", ",")) < 0)
                {
                    dataGridView3["what_choose", i].Value = "ac";
                    x1 = (double)dataGridView3["a", i].Value;
                    x2 = (double)dataGridView3["c", i].Value;
                }
                else
                {
                    dataGridView3["what_choose", i].Value = "cb";
                    x1 = (double)dataGridView3["c", i].Value;
                    x2 = (double)dataGridView3["b", i].Value;
                }
                i++;
            }

            dataGridView3["c", dataGridView3.RowCount - 2].Style.BackColor = System.Drawing.Color.Green;
            dataGridView3["f_c", dataGridView3.RowCount - 2].Style.BackColor = System.Drawing.Color.Green;
            labelCheck.Text = "f(" + dataGridView3["c", dataGridView3.RowCount - 2].Value.ToString() + ") = ";
            textBoxCheck.Text = F((double)dataGridView3["c", dataGridView3.RowCount - 2].Value).ToString("0.#########################");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonIteration_Click(object sender, EventArgs e)
        {
            double E = double.Parse(textBoxE.Text);
            dataGridView3.Rows[now].Selected = true;
            if (now - 1 >= 0)
                dataGridView3.Rows[now - 1].Selected = false;

            myPen.Color = Color.Black;
            Int64 x1 = 0, y1 = 0, x2 = 0, y2 = 0;
            double x, y;
            double xMin = (double)(dataGridView3["a", now].Value);
            double xMax = (double)(dataGridView3["b", now].Value);

            List<double> наборАргументов = new List<double>();
            for (int i = 1; i <= 3; i++)
            {
                наборАргументов.Add((double)(dataGridView3[i, now].Value));
            }

            const double step = 0.0001;

            graph.Clear(BackColor);
            myPen.Color = Color.Black;

            myPen.Width = 0.1F;
            graph.DrawLine(myPen, 900, y0, this.ClientSize.Width, y0);
            //graph.DrawLine(myPen, x0, 0, x0, this.ClientSize.Height);
            // graph.DrawLine(myPen, float.Parse((x0 + 910 * kx).ToString()), y0, this.ClientSize.Width, y0);
            graph.DrawLine(myPen, x0, 0, x0, this.ClientSize.Height);

            graph.DrawLine(myPen, this.ClientSize.Width, y0, this.ClientSize.Width - 5, y0 + 5);
            graph.DrawLine(myPen, this.ClientSize.Width, y0, this.ClientSize.Width - 5, y0 - 5);
            graph.DrawLine(myPen, x0, 0, x0 - 5, 5);
            graph.DrawLine(myPen, x0, 0, x0 + 5, 5);

            myPen.Color = Color.Blue;
            x = xMin;
            y = F(x);

            x1 = (Int64)(x0 + x * kx);
            y1 = (Int64)(y0 - y * ky);
            myPen.Width = 2;
            myPen.Color = Color.Black;

            for (int i = (int)xMin; i <= (int)xMax; i += 1)
            {
                if (i != 0)
                {
                    graph.DrawLine(myPen, (float)(x0 + i * kx), y0 - 3, (float)(x0 + i * kx), y0 + 3);
                    graph.DrawString(i.ToString(), MyFont, Brushes.Black, (float)(x0 + i * kx - 3), y0 + 5);
                    // graph.DrawLine(myPen, (float)(x0 - 3), (float)(y0 - F(i) * ky), (float)(x0 + 3), (float)(y0 - F(i) * ky));
                    //graph.DrawString(F(i).ToString(), MyFont, Brushes.Black, (float)(x0 + 3), (float)(y0 - F(i) * ky - 3));
                }
            }

            myPen.Color = Color.Blue;
            myPen.Width = 2;

            while (x <= xMax)
            {
                x = x + step;
                y = F(x);

                x2 = (Int64)(x0 + x * kx);
                y2 = (Int64)(y0 - y * ky);

                graph.DrawLine(myPen, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
            }

            if ((double)dataGridView3["lenAB", now].Value < E)
            {
                buttonIteration.Enabled = false;
                //button_plus.Enabled = false;
                myPen.Color = Color.Black;
                graph.DrawEllipse(myPen, (float)(x0 + наборАргументов[1] * kx - 2), (float)(y0 - F(наборАргументов[1]) * ky - 2), 2, 2);
                graph.DrawString(наборАргументов[1].ToString("0.####"), MyFont, Brushes.Black, (float)(x0 + наборАргументов[1] * kx - 3), y0 + 5);
                graph.DrawLine(myPen, (float)(x0 - 3), (float)(y0 - F(наборАргументов[1]) * ky), (float)(x0 + 3), (float)(y0 - F(наборАргументов[1]) * ky));
                graph.DrawString(F(наборАргументов[1]).ToString("0.####"), MyFont, Brushes.Black, (float)(x0 + 3), (float)(y0 - F(наборАргументов[1]) * ky - 3));
            }
            else
            {
                выделение_Отрезка();
                myPen.Color = Color.Red;
                myPen.Width = 1;
                foreach (double elem in наборАргументов)
                {
                    graph.DrawEllipse(myPen, (float)(x0 + elem * kx - 2), y0, 2, 2);
                    graph.DrawEllipse(myPen, (float)(x0 + elem * kx - 2), (float)(y0 - F(elem) * ky - 2), 2, 2);
                    graph.DrawLine(myPen, (float)(x0 - 3), (float)(y0 - F(elem) * ky), (float)(x0 + 3), (float)(y0 - F(elem) * ky));
                    graph.DrawString(F(elem).ToString("0.####"), MyFont, Brushes.Black, (float)(x0 + 3), (float)(y0 - F(elem) * ky - 3));
                }
            }
            now++;
            //kx += 500;
            //x0 -= 500;
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            ky += 500;

            if (x0 + 80 >= this.ClientSize.Width)
            {
                if (!enough)
                {
                    x0 = this.ClientSize.Width - 10;
                    kx += 20;
                    enough = true;
                }
            }
            else if (x0 - 80 <= dataGridView3.Location.X + dataGridView3.Size.Width)
            {
                if (!enough)
                {
                    x0 = dataGridView3.Location.X + dataGridView3.Size.Width + 3;
                    kx += 20;
                    enough = true;
                }
            }
            else
            {
                kx += 20;
                if (sign == 1)
                    x0 -= 80;
                else
                    if (sign == -1)
                    x0 += 80;
            }
            now--;
            buttonIteration_Click(sender, e);
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            ky -= 1000;
            now--;
            buttonIteration_Click(sender, e);
        }

        private void выделение_Отрезка()
        {
            Int64 x1 = 0, y1 = 0, x2 = 0, y2 = 0;
            double x, y;
            const double step = 0.0001;
            double xMin = (double)(dataGridView3["a", now].Value);
            double xMax = (double)(dataGridView3["b", now].Value);

            if ((string)dataGridView3["what_choose", now].Value == "ac")
            {
                xMin = (double)dataGridView3["a", now].Value;
                xMax = (double)dataGridView3["c", now].Value;
                if ((double)dataGridView3["a", now].Value > 0 && (double)dataGridView3["c", now].Value > 0)
                    sign = 1;
                else
                     if ((double)dataGridView3["a", now].Value < 0 && (double)dataGridView3["c", now].Value < 0)
                    sign = -1;
                else
                    sign = 0;
            }
            else
            if ((string)dataGridView3["what_choose", now].Value == "cb")
            {
                xMin = (double)dataGridView3["c", now].Value;
                xMax = (double)dataGridView3["b", now].Value;
                if ((double)dataGridView3["c", now].Value > 0 && (double)dataGridView3["b", now].Value > 0)
                    sign = 1;
                else
                     if ((double)dataGridView3["c", now].Value < 0 && (double)dataGridView3["b", now].Value < 0)
                    sign = -1;
                else
                    sign = 0;
            }

            x = xMin;
            y = F(x);

            x1 = (Int64)(x0 + x * kx);
            y1 = (Int64)(y0 - y * ky);
            myPen.Color = Color.Yellow;
            while (x <= xMax)
            {
                x = x + step;
                y = F(x);

                x2 = (Int64)(x0 + x * kx);
                y2 = (Int64)(y0 - y * ky);

                graph.DrawLine(myPen, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
            }

            myPen.Color = Color.Blue;
        }
    }
}