using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task1
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

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (InchInRadioButton.Checked)
                    if (InchRadioButton.Checked)
                        ResultTextBox.Text = (double.Parse(InputTextBox.Text)).ToString();
                else if (FootRadioButton.Checked)
                        ResultTextBox.Text = (double.Parse(InputTextBox.Text) * 0.0833333).ToString();
                else if (YardRadioButton.Checked)
                        ResultTextBox.Text = (double.Parse(InputTextBox.Text) * 0.0277778).ToString();
                if (FootInRadioButton.Checked)
                    if (InchRadioButton.Checked)
                        ResultTextBox.Text = (double.Parse(InputTextBox.Text) * 12).ToString();
                    else if (FootRadioButton.Checked)
                        ResultTextBox.Text = (double.Parse(InputTextBox.Text)).ToString();
                    else if (YardRadioButton.Checked)
                        ResultTextBox.Text = (double.Parse(InputTextBox.Text) * 0.333333).ToString();
                if (YardInRadioButton.Checked)
                    if (InchRadioButton.Checked)
                        ResultTextBox.Text = (double.Parse(InputTextBox.Text) * 36).ToString();
                    else if (FootRadioButton.Checked)
                        ResultTextBox.Text = (double.Parse(InputTextBox.Text) * 3).ToString();
                    else if (YardRadioButton.Checked)
                        ResultTextBox.Text = (double.Parse(InputTextBox.Text)).ToString();
            }
            catch
            {
                MessageBox.Show("Некорректный ввод исходных данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InputTextBox.Text = "0";
                ResultTextBox.Text = "0";
            }
        }

        private void ResultGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void InchInRadioButton_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void FootInRadioButton_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void YardInRadioButton_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void InchRadioButton_KeyDown(object sender, KeyEventArgs e)
        {
            ExecuteButton_Click(sender, e);
        }

        private void FootRadioButton_KeyDown(object sender, KeyEventArgs e)
        {
            ExecuteButton_Click(sender, e);
        }

        private void YardRadioButton_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            ResultTextBox.Text = "";
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ExecuteButton_Click(sender, e);
        }
    }
}

