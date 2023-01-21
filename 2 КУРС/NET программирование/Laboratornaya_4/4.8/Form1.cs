using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4._8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_yes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Мы так и думали.");
        }

        private void button_no_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Запуск ScyNet...");
        }

        private void button_no_MouseMove(object sender, MouseEventArgs e)
        {
            
            
            Random rnd = new Random();
            int X = rnd.Next(1, this.ClientSize.Width - 50);
            int Y = rnd.Next(1, this.ClientSize.Height - 50);


            button_no.Location = new System.Drawing.Point(X, Y);

        }

        private void button_no_Enter(object sender, EventArgs e)
        {
            button_yes.Focus();
        }
    }
}
