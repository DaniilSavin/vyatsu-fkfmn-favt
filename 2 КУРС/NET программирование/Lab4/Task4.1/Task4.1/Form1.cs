using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4._1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void Calculate()
        {
            try
            {
                double sm = double.Parse(CentiMTextBox.Text);
                bool flag = true;
                if (dm.Checked)
                    sm *= 2.54;
                else
                if (ya.Checked)
                    sm *= 91.44;
                else
                if (ft.Checked)
                    sm *= 30.48;
                else
                {
                    MessageBox.Show("Выберите величину входных данных", "Уведомление");
                    flag = false;
                }
                if (flag)
                if (InchRadioButton.Checked)
                    ResultTextBox.Text =
                    (sm / 2.54).ToString();
                else
                if (YardRadioButton.Checked)
                    ResultTextBox.Text =
                    (sm / 91.44).ToString();
                else
                if (FootRadioButton.Checked)
                    ResultTextBox.Text =
                    (sm / 30.48).ToString();
                else
                    MessageBox.Show("Выберите величину выходных данных", "Уведомление");
            }
            catch
            {
                MessageBox.Show("Некорректный ввод исходных данных", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                CentiMTextBox.Text = "0";
                ResultTextBox.Text = "0";
            }
        }

        private void InchRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ResultTextBox.Text = "0";
        }

        private void FootRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ResultTextBox.Text = "0";
        }

        private void YardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ResultTextBox.Text = "0";
        }

        private void dm_CheckedChanged(object sender, EventArgs e)
        {
            ResultTextBox.Text = "0";
        }

        private void ft_CheckedChanged(object sender, EventArgs e)
        {
            ResultTextBox.Text = "0";
        }

        private void ya_CheckedChanged(object sender, EventArgs e)
        {
            ResultTextBox.Text = "0";
        }

        private void CentiMTextBox_TextChanged(object sender, EventArgs e)
        {
            ResultTextBox.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}
