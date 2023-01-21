using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task3
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            try
            {
                double power = double.Parse(PowerTextBox.Text);
                int age = int.Parse(AgeTextBox.Text);
                if ((power > 130 && power < 195) && (age > 15 && age < 60) && ((power > 130 && power < 195) && (age > 15 && age < 60)))
                {
                    if (MaleRadioButton.Checked)
                    {
                        ResultTextBox.Text = "";
                        ResultTextBox.Text = (50 + 0.75 * (double.Parse(PowerTextBox.Text) - 150) + 0.25 * (int.Parse(AgeTextBox.Text) - 20)).ToString();
                    }
                    else if (FemaleRadioButton.Checked)
                    {
                        ResultTextBox.Text = "";
                        ResultTextBox.Text = (0.9 * (50 + 0.75 * (double.Parse(PowerTextBox.Text) - 150) + 0.25 * (int.Parse(AgeTextBox.Text) - 20))).ToString();
                    }
                }
               else if (power < 130 || power > 195) throw new Exception("Некорректный ввод исходных данных");
               else if (age < 15 || age > 60) throw new Exception("Некорректный ввод исходных данных1");
            }
            catch 
            {
                MessageBox.Show("Некорректный ввод возраста или роста, перепроверьте их, исходя из данных диапазонов на форме", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //PowerTextBox.Text = "0";
                //AgeTextBox.Text = "0";
                //ResultTextBox.Text = "0";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void PowerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ExecuteButton_Click(sender, e);
        }

        private void AgeTextBox_TextChanged(object sender, EventArgs e)
        {
            ResultTextBox.Text = "";

        }

        private void AgeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ExecuteButton_Click(sender, e);
        }

        private void PowerTextBox_TextChanged(object sender, EventArgs e)
        {
            ResultTextBox.Text = "";
        }

        private void ResultTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ExecuteButton_Click(sender, e);
        }
    }
}

