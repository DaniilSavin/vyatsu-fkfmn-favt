using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex1
{
    public partial class Form1 : Form //КОНВЕРТЕР
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            InchRadioButton.Checked = true;
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (textBox1.Text=="" )
                {

                    ResultTextBox.Text = ""; 

                }
                else
                if (textBox1.Text == "0")
                {

                    textBox1.Text = "";
                }
                else
                if (radioButton1.Checked && InchRadioButton.Checked)
                    ResultTextBox.Text = (double.Parse(textBox1.Text)).ToString();
                if (radioButton1.Checked && FootRadioButton.Checked)
                    ResultTextBox.Text =(double.Parse(textBox1.Text)* 0.083).ToString();
                if (radioButton1.Checked && YardRadioButton.Checked)
                    ResultTextBox.Text =(double.Parse(textBox1.Text)*0.028).ToString();
                ///////////////////////////////////////////////////////
                if (radioButton2.Checked && InchRadioButton.Checked)
                    ResultTextBox.Text = (double.Parse(textBox1.Text)*12).ToString();
                if (radioButton2.Checked && FootRadioButton.Checked)
                    ResultTextBox.Text =(double.Parse(textBox1.Text)).ToString();
                if (radioButton2.Checked && YardRadioButton.Checked)
                    ResultTextBox.Text =(double.Parse(textBox1.Text)* 0.33).ToString();
                ///////////////////////////////////////////////////////
                if (radioButton3.Checked && InchRadioButton.Checked)
                    ResultTextBox.Text = (double.Parse(textBox1.Text) * 36).ToString();
                if (radioButton3.Checked && FootRadioButton.Checked)
                    ResultTextBox.Text =(double.Parse(textBox1.Text)*3).ToString();
                if (radioButton3.Checked && YardRadioButton.Checked)
                    ResultTextBox.Text =(double.Parse(textBox1.Text)).ToString();


            }
            catch
            {
                ResultTextBox.Text = "";
                MessageBox.Show("Некорректный ввод исходных данных", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                
            }



        }

        private void ExecuteButton_KeyDown(object sender, KeyEventArgs e)
        {
           // if (e.KeyCode == Keys.Enter) ExecuteButton_Click(sender, e);
        }

        private void CentiMTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CentiMTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ExecuteButton_Click(sender, e);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ExecuteButton_Click(sender, e);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ExecuteButton_Click(sender, e);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ExecuteButton_Click(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text[0] == '0')
                {
                    string tmpstring = textBox1.Text;
                    textBox1.Text = tmpstring.Remove(0, 1);

                }
            }
            catch
            {

            }
            ExecuteButton_Click(sender, e);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
               /* if (Char.IsDigit(e.KeyChar))
                {
                    string tmpstring = textBox1.Text;
                    textBox1.Text = tmpstring.Remove(0, 1);
                }*/

            }
            catch
            {

            }
            ExecuteButton_Click(sender, e);
        }
    }
}
