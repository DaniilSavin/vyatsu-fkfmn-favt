using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3._5
{
    public partial class Form1 : Form
    {

        Form f, f2, f3, f4;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar=='1')
            {
                f = new Form();
                f.Show();
            }
            else
            if (e.KeyChar == '2')
            {
                f = new Form();
                f.Show();
                f2 = new Form();
                f2.Show();
            }
            else
                if (e.KeyChar == '3')
            {
                f = new Form();
                f.Show();
                f2 = new Form();
                f2.Show();
                f3 = new Form();
                f3.Show();
            }
            else
            {
                f = new Form();
                f.Show();
                f2 = new Form();
                f2.Show();
                f3 = new Form();
                f3.Show();
                f4 = new Form();
                f4.Show();
            }
        }
    }
}
