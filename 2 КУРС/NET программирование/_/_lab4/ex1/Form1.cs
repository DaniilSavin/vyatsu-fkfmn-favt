using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex1
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

        private void InchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Click(object sender, EventArgs e)
        {

        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            try
            {
                InchTextBox.Text = (double.Parse(CentiMTextBox.Text) / 2.54).ToString();
                FootTextBox.Text = (double.Parse(InchTextBox.Text) / 12).ToString();
                YardTextBox.Text = (double.Parse(FootTextBox.Text) / 3).ToString();
               
            }
            catch
            {
                MessageBox.Show("Некорректный ввод данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CentiMTextBox.Text = "0";
                InchTextBox.Text = "0";
                FootTextBox.Text = "0";
                YardTextBox.Text = "0";
            }
        }

        private void CentiMTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CentiMTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ExecuteButton_Click(sender, e);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
