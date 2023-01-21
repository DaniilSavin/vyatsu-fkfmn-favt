using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ResultTextBox.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            try
            {
                int year = int.Parse(YearTextBox.Text);
                int month = int.Parse(MonthTextBox.Text);
                int day = int.Parse(DayTextBox.Text);
                DateTime input = new DateTime(year, month, day);
                DateTime input1 = new DateTime(year, 1, 1);
                int daysleft = (input - input1).Days;
                if ((year >= 1900 && year <= 2019) && (month > 0 && month <= 12) && (day > 0) && ((day <= 28 && month == 2 && year % 4 != 0) || (day <= 29 && month == 2 && year % 4 == 0) || (day <= 31 && (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)) || (day <= 30 && (month == 4 || month == 6 || month == 9 || month == 11))))
                {
                    ResultTextBox.Text = daysleft.ToString();
                }
                else throw new Exception("Неверный ввод данных");
            }
            catch
            {
                MessageBox.Show("Некорректный ввод исходных данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResultTextBox.Text = "0";
                //YearTextBox.Text = "0";
                //MonthTextBox.Text = "0";
                //DayTextBox.Text = "0";
            }
        }

        private void ResultTextBox_TextChanged(object sender, EventArgs e)
        {
            //ResultTextBox.Text = "";
        }

        private void DayTextBox_TextChanged(object sender, EventArgs e)
        {
            ResultTextBox.Text = "";
        }

        private void YearTextBox_TextChanged(object sender, EventArgs e)
        {
            ResultTextBox.Text = "";
        }
    }
}
