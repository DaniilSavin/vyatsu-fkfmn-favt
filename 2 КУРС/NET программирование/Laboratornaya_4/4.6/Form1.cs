using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4._6
{
    
    public partial class Form1 : Form
    {
        int count = 1;
        int _shapeType = 1;
        public int countOfShapes
        {
            get { return count; }
            set { count = value; }
        }
        public int shapeType
        {
            get { return _shapeType; }
            set { _shapeType = value; }
        }
        Form1 form2 = new Form1();
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

        private void low_speed_rb_CheckedChanged(object sender, EventArgs e)
        {
            form2.timer1.Interval = 10000;
        }

        private void med_speed_rb_CheckedChanged(object sender, EventArgs e)
        {
            form2.timer1.Interval = 100;
        }

        private void fast_speed_rb_CheckedChanged(object sender, EventArgs e)
        {
            form2.timer1.Interval = 1;
        }

        private void one_rb_CheckedChanged(object sender, EventArgs e)
        {
            form2.countOfShapes = 1;
        }

        private void two_rb_CheckedChanged(object sender, EventArgs e)
        {
            form2.countOfShapes = 2;
        }

        private void pryamoug_radbut_CheckedChanged(object sender, EventArgs e)
        {
            form2.shapeType = 1;
        }

        private void ellips_radbut_CheckedChanged(object sender, EventArgs e)
        {
            form2.shapeType = 2;
        }

        private void pr_el_rb_CheckedChanged(object sender, EventArgs e)
        {
            form2.shapeType = 3;
        }
    }
}
