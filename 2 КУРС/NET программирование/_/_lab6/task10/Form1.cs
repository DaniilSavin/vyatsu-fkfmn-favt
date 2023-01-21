using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            StringTextBox.Text = "";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void StringButton_Click(object sender, EventArgs e)
        {

            string s = InputTextBox.Text;
            int i = 0;
            while (i < s.Length - 1)
            {
                if (s[i] != s[i + 1])
                {
                    s = s.Insert(i + 1, "*");
                    i += 2;
                }
                else i++;
            }
            StringTextBox.Text = s;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void StringTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
