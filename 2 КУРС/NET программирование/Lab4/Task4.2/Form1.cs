using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] date = textBox1.Text.Split('/');
                DateTime date1 = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), 0, 0, 0);
                DateTime date2 = DateTime.Now;
                date2 = new DateTime(date2.Year, 1, 1, 0, 0, 0);
                if ((date1 - date2).TotalDays >= 0)
                    MessageBox.Show("Дней с начала года: " + (date1 - date2).TotalDays.ToString() + " дней.");
                else throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка! Не корректно введена дата.");
                textBox1.Text = "DD/MM/YYYY";
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
            int titleHeight = screenRectangle.Top - this.Top;
            button1.Left = ActiveForm.Width - button1.Width - 5;
            button1.Top = ActiveForm.Height - button1.Height - 5 - titleHeight;
        }
    }
}
