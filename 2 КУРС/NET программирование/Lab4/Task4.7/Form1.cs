using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4._7
{
    public partial class Form1 : Form
    {
        bool left, right, up, down;
        int time = 60;
        int record = 0;
        int current = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public void SpawnCheese()
        {
            Random rnd = new Random();
            cheese.Left = rnd.Next(1, 8) * 50;
            cheese.Top = rnd.Next(1, 8) * 50;
            cheese.Visible = true;
        }

        public bool Question()
        {
            DialogResult dialogResult = MessageBox.Show("Вы собрали "+ current+ " кусочков сыра. Желаете сыграть ещё одну игру?", "Мышь за сыром", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
                this.Close();
                return false;//never     
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (time > 0) time--;
            else
            {
                cheese.Visible = false;
                timer1.Enabled = false;
                timer2.Enabled = false;
                right = false;
                left = false;
                up = false;
                down = false;
                time = 60;
                if (current > record)
                {
                    record = current;
                    label2.Text = "Рекорд: " + record;
                }
                label3.Text = "Текущая игра: 0";

                if (Question())
                {
                    SpawnCheese();
                    timer1.Enabled = true;
                    timer2.Enabled = true;
                }
                current = 0;
            }
            label1.Text = time.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mouse.Left = 50 * 8;
            mouse.Top = 50 * 8;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            if (cheese.Left == mouse.Left && mouse.Top == cheese.Top)
            {
                current++;
                SpawnCheese();
                label3.Text = "Текущая игра: " + current;
            }

            bool moved = false;
            while (!moved)
            {
                switch (rnd.Next(0,6))
                {
                    case 1:
                        if (cheese.Left+50 < this.Width - 50)
                        {
                            cheese.Left = cheese.Left + 50;
                            moved = true;
                        }
                        break;
                    case 2:
                        if (cheese.Left - 50 > 0)
                        {
                            cheese.Left = cheese.Left - 50;
                            moved = true;
                        }
                        break;
                    case 3:
                        if (cheese.Top + 50 < this.Height-50)
                        {
                            cheese.Top = cheese.Top + 50;
                            moved = true;
                        }
                        break;
                    case 4:
                        if (cheese.Top - 50 > 0)
                        {
                            cheese.Top = cheese.Top - 50;
                            moved = true;
                        }
                        break;
                }
            }
            if (right) mouse.Left += 50;
            else
                if (left) mouse.Left -= 50;
            else
                if (up) mouse.Top -= 50;
            else
                if (down) mouse.Top += 50;

            right = false;
            left = false;
            up = false;
            down = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (right == false && left == false && up == false && down == false)
            {
                if (e.KeyValue == 37) left = true;
                else
                    if (e.KeyValue == 38) up = true;
                else
                    if (e.KeyValue == 39) right = true;
                else
                    if (e.KeyValue == 40) down = true; 
            }
            
        }
    }
}
