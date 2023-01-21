using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex2._0
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (InchRadioButton.Checked)
                    ResultTextBox.Text =
                        (double.Parse(CentiMTextBox.Text) / 2.54).ToString();
                if (YardRadioButton.Checked)
                    ResultTextBox.Text =
                        (double.Parse(CentiMTextBox.Text) / 91.44).ToString();
                if (FootRadioButton.Checked)
                    ResultTextBox.Text =
                        (double.Parse(CentiMTextBox.Text) / 30.48).ToString();
            }
            catch
            {
                MessageBox.Show("Некорректный ввод исходных данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CentiMTextBox.Text = "0";
                ResultTextBox.Text = "0";
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
