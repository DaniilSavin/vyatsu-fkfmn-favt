using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form3 : Form
    {
        static int digitsqr(int a)
        {
            int sum = 0;
            while (a > 0)
            {
                sum = sum + a % 10;
                a = a / 10;
            }
            return sum;
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void DayTextBox_TextChanged(object sender, EventArgs e)
        {
            DigitTextBox.Text = "";
        }

        private void MonthTextBox_TextChanged(object sender, EventArgs e)
        {
            DigitTextBox.Text = "";
        }

        private void YearTextBox_TextChanged(object sender, EventArgs e)
        {
            DigitTextBox.Text = "";
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            int k1 = 0, k2 = 0, k3 = 0;
            double year = -1, month = -1, day = -1;
            int error = 0;

            try
            {
                year = double.Parse(YearTextBox.Text);
            }
            catch
            {
                k1 = 1;
            }

            try
            {
                month = double.Parse(MonthTextBox.Text);
            }
            catch
            {
                k2 = 1;
            }
            try
            {
                day = double.Parse(DayTextBox.Text);
            }
            catch
            {
                k3 = 1;
            }

            if (year % 1 != 0 || year < 1000 || YearTextBox.Text[0] == '0' || YearTextBox.Text == "" || k1 == 1)
            {
                YearTextBox.Text = "";
                if (error == 0)
                {
                    MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    error = 1;
                }
            }
            else
                if (month % 1 != 0 || month < 1 || month > 12 || MonthTextBox.Text[0] == '0' || MonthTextBox.Text == "" || k2 == 1)
            {
                MonthTextBox.Text = "";
                if (error == 0)
                {
                    MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = 1;
                }
            }
            else
                if (day % 1 != 0 || day < 1 || DayTextBox.Text[0] == '0' || DayTextBox.Text == "" || k3 == 1)
            {
                DayTextBox.Text = "";
                if (error == 0)
                {
                    MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = 1;
                }
            }
            else  // проверки на дни в месяцах 
            {
                if ((month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) && day > 31)
                {
                    DayTextBox.Text = "";
                    if (error == 0)
                    {
                        MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = 1;
                    }
                }
                else
                  if ((month == 4 || month == 6 || month == 9 || month == 11) && day > 30)
                {
                    DayTextBox.Text = "";
                    if (error == 0)
                    {
                        MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        error = 1;
                    }
                }
                else
                    if (month == 2) // високосный год
                {
                    if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                    {
                        if (day > 29)
                        {
                            DayTextBox.Text = "";
                            if (error == 0)
                            {
                                MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                error = 1;
                            }
                        }
                    }
                    else
                    {
                        if (day > 28)
                        {
                            DayTextBox.Text = "";
                            if (error == 0)
                            {
                                MessageBox.Show("Ошибка ввода", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                error = 1;
                            }
                        }
                    }

                }
                else 
                {
                    int inid = digitsqr(int.Parse(DayTextBox.Text)); 
                    int inim = digitsqr(int.Parse(MonthTextBox.Text));
                    int iniy = digitsqr(int.Parse(YearTextBox.Text));

                    int sqrr = inid + inim + iniy;
                    while (sqrr >= 10)
                    {
                        int digits = sqrr;
                        int next = 0;
                        while (digits > 0)
                        {
                            next = next + digits % 10;
                            digits = digits / 10;
                        }
                        sqrr = next;
                    }
                    DigitTextBox.Text = sqrr.ToString();


                }
            }
        }
    }
}
