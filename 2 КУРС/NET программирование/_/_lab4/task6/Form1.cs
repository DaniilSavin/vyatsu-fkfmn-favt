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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int shape, count, time;
                if (RectangleRadioButton.Checked) shape = 1;
                else if (EllipseRadioButton.Checked) shape = 2;
                else shape = 3;
                if (OneRadioButton.Checked) count = 1;
                else count = 2;
                if (SlowRadioButton.Checked) time = 3;
                else if (FastRadioButton.Checked) time = 1;
                else time = 2;
                Form2 form2 = new Form2(shape, count, time);
                form2.ShowDialog();
                Close();
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CountGroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SlowRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

                Close();

            }
        }
    }
}
