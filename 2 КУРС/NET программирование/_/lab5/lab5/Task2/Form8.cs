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
    public partial class Form8 : Form
    {
        Random Rand;
        Graphics Graph;
        public Form8()
        {
            InitializeComponent();
            Rand = new Random();
        }
        int r, k, y, x;
        bool s2 = false, str = false;

        private void SizeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            int checkwarn = 0, checkaightr = 0, checkaightk = 0;
            bool pp = true;
            Graphics graph = CreateGraphics();
            graph.Clear(BackColor);
            try
            {
                r = int.Parse(SizeTextBox.Text);
                if (r < 1 || r>200)
                {
                    if (checkwarn == 0)
                        MessageBox.Show("Некорректный ввод размера снежинки или вложенности");
                    SizeTextBox.Text = "";
                    checkwarn = 1;
                }
                else checkaightr = 1;
            }
            catch
            {
                if (checkwarn == 0)
                    MessageBox.Show("Некорректный ввод ");
                SizeTextBox.Text = "";
                checkwarn = 1;

            }
            try
            {
                k = int.Parse(RecTextBox.Text);
                if (k < 0 || k>20)
                {
                    if (checkwarn == 0)
                        MessageBox.Show("Некорректный ввод размера снежинки или вложенности");
                    RecTextBox.Text = "";
                    checkwarn = 1;
                }
                else checkaightk = 1;
            }
            catch
            {
                if (checkwarn == 0)
                    MessageBox.Show("Некорректный ввод ");
                RecTextBox.Text = "";
                checkwarn = 1;

            }
            if (checkaightk == 1 && checkaightr == 1)
            {
                if (this.ClientSize.Width / 2 + r >= this.ClientSize.Width)
                {
                    pp = false;
                    MessageBox.Show("Некорректный ввод входных данных");
                    SizeTextBox.Text = "";
                }
                if (pp) create(this.ClientSize.Width / 2, this.ClientSize.Height / 2, 1, r);
                FallButton.Show();
            }
            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            s2 = false;
            BackButton.Visible = false;
            FallButton.Visible = true;
            DrawButton.Visible = true;
            SizeLabel.Visible = true;
            RecLabel.Visible = true;
            SizeTextBox.Visible = true;
            RecTextBox.Visible = true;
        }

        private void FallButton_Click(object sender, EventArgs e)
        {
            BackButton.Visible = true;
            Graphics graph = CreateGraphics();
            graph.Clear(BackColor);
            FallButton.Visible = false;
            DrawButton.Visible = false;
            SizeLabel.Visible = false;
            RecLabel.Visible = false;
            SizeTextBox.Visible = false;
            RecTextBox.Visible = false;
            k = 3;
            s2 = true;
            this.Text = "Кликни по форме, чтобы создать снежинку";

            try
            {
                r = int.Parse(SizeTextBox.Text);
            }
            catch
            {
                SizeTextBox.Text = "";
            }
        }

        private void Form8_MouseClick(object sender, MouseEventArgs e)
        {
            if (!str && s2 && !timer1.Enabled)
            {
                timer1.Start();
                str = true;
                x = e.X;
                y = e.Y;
                r = Rand.Next(20);
                k = 3;
                create(x, y, 1, r);
            }
        }

        private void SizeLabel_Click(object sender, EventArgs e)
        {

        }

        void create(int x, int y, int count, int r)
        {
            Graph = CreateGraphics();
            Pen Mypen = new Pen(Color.Red, 2);
            Graph.DrawLine(Mypen, x, y, x - r * 4 / 5, y - r * 4 / 5);
            Graph.DrawLine(Mypen, x, y, x - r * 4 / 5, y + r * 4 / 5);
            Graph.DrawLine(Mypen, x, y, x + r * 4 / 5, y - r * 4 / 5);
            Graph.DrawLine(Mypen, x, y, x + r * 4 / 5, y + r * 4 / 5);
            Graph.DrawLine(Mypen, x, y, x + r, y);
            Graph.DrawLine(Mypen, x, y, x, y - r);
            Graph.DrawLine(Mypen, x, y, x - r, y);
            Graph.DrawLine(Mypen, x, y, x, y + r);
            if (count <= k && r / 4 > 0)
            {
                create(x - r * 4 / 5, y - r * 4 / 5, count + 1, r / 4);
                create(x + r * 4 / 5, y - r * 4 / 5, count + 1, r / 4);
                create(x - r * 4 / 5, y + r * 4 / 5, count + 1, r / 4);
                create(x + r * 4 / 5, y + r * 4 / 5, count + 1, r / 4);
                create(x - r, y, count + 1, r / 4);
                create(x + r, y, count + 1, r / 4);
                create(x, y - r, count + 1, r / 4);
                create(x, y + r, count + 1, r / 4);
            }
        }
        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics Graph = CreateGraphics();
            if (y + r + r / 4 <= this.ClientSize.Height)
            {
                Graph.Clear(BackColor);
                create(x, y, 1, r);
                y += 30;
            }
            else
            {
                str = false;
                Graph.Clear(BackColor);
                timer1.Stop();
            }
        }
    }
}
