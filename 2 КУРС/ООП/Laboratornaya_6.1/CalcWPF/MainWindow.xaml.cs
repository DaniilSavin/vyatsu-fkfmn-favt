using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalcLibrary;
namespace CalcWPF
{
    
    public partial class MainWindow : Window
    {
        string leftop = "";
        string operation = "";
        string rightop = "";
        bool wasEqually = false;
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;
            if (textBlock.Text.StartsWith("0") && leftop != "0" || wasEqually)
            {
                textBlock.Text = "";
                leftop = "";
                wasEqually = false;
            }
            textBlock.Text += s;
            int num;
            bool result = Int32.TryParse(s, out num);
            if (result)
            {
                if (operation == "")
                {
                    leftop += s;
                }
                else rightop += s;
            }
            else
            {
                if (s == "=")
                {
                    Update_rightop();
                    textBlock.Text += rightop;
                    operation = "";
                    wasEqually = true;
                }
                else if (s == "CLEAR") //очистка полей
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "0";
                }
                else if (s == "del") //удаление посимвольно
                {
                    if (operation != "" && rightop.Equals(""))
                    {
                        operation = "";
                        textBlock.Text = leftop;
                    }
                    else
                    if (operation == "" && !leftop.Equals(""))
                    {
                        leftop = leftop.Remove(leftop.Length - 1);
                        textBlock.Text = leftop;
                    }
                    else if (!rightop.Equals(""))
                    {
                        rightop = rightop.Replace(rightop.Last(), ' ');
                        textBlock.Text = leftop + operation + rightop;
                    }
                    if (leftop.Equals("") || leftop.Equals(""))
                    {
                        textBlock.Text = "";
                    }
                }
                else if (s == "+/-") //смена знака в строке с минуса на плюс и наоборот
                {
                    if (operation == "")
                    {
                        if (leftop[0] != '-') leftop = leftop.Insert(0, "-");
                        else leftop = leftop.Replace("-", " ");
                        textBlock.Text = leftop;
                    }
                    else
                    {
                        if (rightop[0] != '-') rightop = rightop.Insert(0, "-");
                        else rightop = rightop.Replace("-", " ");
                        textBlock.Text = leftop + operation + '(' + rightop + ')';
                    }
                }
                else if (s == "1/x") //возведение числа в -1 степень
                {
                    try
                    {
                        double number = double.Parse(leftop);
                        if (number != 0)
                        {
                            leftop = Math.Pow(number, -1).ToString();
                            textBlock.Text = leftop;
                        }
                        else throw new ArgumentException();
                    }
                    catch
                    {
                        MessageBox.Show("Деление на ноль запрещено");
                        leftop = rightop = "";
                        textBlock.Text = "0";
                    }
                }
                else if (s == "n!") //нахождение факториала
                {
                    try
                    {
                        double number = double.Parse(leftop);
                        int digit = 1;
                        for (int i = 2; i <= number; i++) digit *= i;
                        if (digit < int.MaxValue) leftop = digit.ToString();
                        else throw new ArgumentException();
                        textBlock.Text = leftop;
                    }
                    catch
                    {
                        MessageBox.Show("Достигнуто максимальное число разрядов");
                        leftop = rightop = "";
                        textBlock.Text = "0";
                    }
                }
                else if (s == "a^2") //нахождение квадрата числа
                {
                    try
                    {
                        int number = int.Parse(leftop);
                        int digit = number * number;
                        if (digit < int.MaxValue) leftop = digit.ToString();
                        else throw new ArgumentException();
                        textBlock.Text = leftop;
                    }
                    catch
                    {
                        MessageBox.Show("Достигнуто максимальное число разрядов");
                        leftop = rightop = "";
                        textBlock.Text = "0";
                    }
                }
                else if (s == "sqrt") //нахождение квадратного корня из числа
                {
                    try
                    {
                        double number = double.Parse(leftop);
                        if (number >= 0)
                        {
                            leftop = Math.Sqrt(number).ToString();
                            textBlock.Text = leftop;
                        }
                        else throw new ArgumentException();
                    }
                    catch
                    {
                        MessageBox.Show("Введено отрицательное число");
                        leftop = rightop = "";
                        textBlock.Text = "0";
                    }
                }
                //тригонометрические функции
                else if (s == "sin")
                {
                    try
                    {
                        double number = double.Parse(leftop);
                        leftop = Math.Sin(number).ToString();
                        textBlock.Text = leftop;
                    }
                    catch
                    {
                        MessageBox.Show("Неверно введён операнд. Попробуйте снова");
                        leftop = rightop = "";
                        textBlock.Text = "0";
                    }
                }
                else if (s == "cos")
                {
                    try
                    {
                        double number = double.Parse(leftop);
                        leftop = Math.Cos(number).ToString();
                        textBlock.Text = leftop;
                    }
                    catch
                    {
                        MessageBox.Show("Неверно введён операнд. Попробуйте снова");
                        leftop = rightop = "";
                        textBlock.Text = "0";
                    }
                }
                else if (s == "tan")
                {
                    try
                    {
                        double number = double.Parse(leftop);
                        leftop = Math.Tan(number).ToString();
                        textBlock.Text = leftop;
                    }
                    catch
                    {
                        MessageBox.Show("Неверно введён операнд. Попробуйте снова");
                        leftop = rightop = "";
                        textBlock.Text = "0";
                    }
                }
                //вывод числового значения экспоненты
                else if (s == "exp")
                {
                    leftop = Math.Exp(1).ToString();
                    textBlock.Text = leftop;
                }
                //возведение экспоненты в степень
                else if (s == "e^x")
                {
                    try
                    {
                        double number = double.Parse(leftop);
                        if (Math.Exp(number) < double.MaxValue) leftop = Math.Exp(number).ToString();
                        else throw new ArgumentException();
                        textBlock.Text = leftop;
                    }
                    catch
                    {
                        MessageBox.Show("Достигнуто максимальное число разрядов");
                        leftop = rightop = "";
                        textBlock.Text = "0";
                    }
                }
                //вывод значения числа "пи"
                else if (s == "pi")
                {
                    leftop = Math.PI.ToString();
                    textBlock.Text = leftop;
                }
                else
                {
                    if (rightop != "")
                    {
                        Update_rightop();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }
        private void Update_rightop() //обновление "правой" подстроки для реализации бинарных операций
        {
            try
            {
                int num1 = int.Parse(leftop);
                int num2 = int.Parse(rightop);
                switch (operation)
                {
                    case "+":
                        try
                        {
                            if (num1 + num2 < int.MaxValue) rightop = (num1 + num2).ToString();
                            else throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Достигнуто максимальное число разрядов");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "-":
                        try
                        {
                            if (num1 - num2 > int.MinValue) rightop = (num1 - num2).ToString();
                            else throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Достигнуто максимальное число разрядов");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "*":
                        try
                        {
                            if (num1 * num2 < int.MaxValue) rightop = (num1 * num2).ToString();
                            else throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Достигнуто максимальное число разрядов");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "/":
                        try
                        {
                            if (num2 != 0) rightop = ((double)num1 / num2).ToString();
                            else throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Деление на ноль запрещено");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "mod":
                        try
                        {
                            if (num2 != 0) rightop = (num1 % num2).ToString();
                            else throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Деление на ноль запрещено");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "div":
                        try
                        {
                            if (num2 != 0) rightop = Math.Truncate((double)num1 / num2).ToString();
                            else throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Деление на ноль запрещено");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "^":
                        try
                        {
                            if (Math.Pow(num1, num2) < int.MaxValue) rightop = Math.Pow(num1, num2).ToString();
                            else throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Достигнуто максимальное число разрядов");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break; 
                }
            }
            catch
            {
                MessageBox.Show("Неправильно введены операнды. Проверьте ввод");
                leftop = operation = rightop = "";
                textBlock.Text = "0";
            }
        }
    }
}
