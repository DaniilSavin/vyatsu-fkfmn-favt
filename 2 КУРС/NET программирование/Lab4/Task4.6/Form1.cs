using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task4._8;

namespace Task4._6
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form2.Owner = this;
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            form2.Show();
            Hide();            
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            form2.TimerInterval = 10000;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            form2.TimerInterval = 100;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            form2.TimerInterval = 1;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            form2.countOfShapes = 1;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            form2.countOfShapes = 2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            form2.shapeType = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            form2.shapeType = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            form2.shapeType = 3;
        }
    }
}
