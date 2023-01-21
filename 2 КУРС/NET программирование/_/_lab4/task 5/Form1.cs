using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Result1TextBox.Text = "";
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            try
            {
                double discr = Math.Pow(double.Parse(BTextBox.Text),2)-4* (double.Parse(ATextBox.Text)* (double.Parse(CTextBox.Text)));
                double a = (double.Parse(ATextBox.Text));
                double b = (double.Parse(BTextBox.Text));
                double c = (double.Parse(CTextBox.Text));
                if (a == 0 && b == 0 && c == 0) MessageBox.Show("X-любое число");
                if (discr>=0)
                {
                    if (discr == 0)
                        Result1TextBox.Text = (-(double.Parse(BTextBox.Text) / (2 * (double.Parse(ATextBox.Text))))).ToString();
                    else if (discr > 0)
                    {
                        Result1TextBox.Text = ((-(double.Parse(BTextBox.Text) + Math.Sqrt(discr)))/(2* (double.Parse(BTextBox.Text)))).ToString();
                        Result2TextBox.Text = (-(double.Parse(BTextBox.Text) - Math.Sqrt(discr))).ToString();
                    }
                }
                else throw new Exception("Корней нет");

            }
            catch
            {
                MessageBox.Show("Корней нет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ATextBox.Text = "";
                BTextBox.Text = "";
                CTextBox.Text = "";
                Result1TextBox.Text = "";
                Result2TextBox.Text = "";
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ATextBox_TextChanged(object sender, EventArgs e)
        {
            Result1TextBox.Text = "";
            Result2TextBox.Text = "";
        }

        private void BTextBox_TextChanged(object sender, EventArgs e)
        {
            Result1TextBox.Text = "";
            Result2TextBox.Text = "";
        }

        private void Result1TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
