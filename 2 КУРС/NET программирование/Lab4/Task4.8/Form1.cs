using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4._8
{
    public partial class Form1 : Form
    {

        Random rnd = new Random();



        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            MessageBox.Show("qwe");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Мы так и думали!");
            this.Close();
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.Left = rnd.Next(button2.Width, this.ClientSize.Width - button2.Width);
            button2.Top = rnd.Next(button2.Height, this.ClientSize.Height - button2.Height);
        }
    }
}
