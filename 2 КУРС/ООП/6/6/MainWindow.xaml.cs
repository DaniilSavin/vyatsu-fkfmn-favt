using System;
using System.Windows;
using System.Windows.Controls;

namespace _6
{

    public partial class MainWindow : Window
    {
        string leftop = "";
        string op = "";
        string rightop = "";

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
            if (textBlock.Text == "0")
                textBlock.Text = "";
            textBlock.Text += s;
            int num;
            bool result = Int32.TryParse(s, out num);
            if (result)
            {
                if (op == "")
                {
                    leftop += s;
                }
                else rightop += s;
            }
            else
            {
                switch (s)
                {
                    case "=":
                        Update_RightOp();
                        if (op != "")
                        {
                            textBlock.Text = rightop;
                            op = "";
                            leftop = textBlock.Text;
                            rightop = "";
                        }
                        break;
                    case "CLEAR":
                        leftop = "";
                        rightop = "";
                        op = "";
                        textBlock.Text = "0";
                        break;
                    case "del":
                        if (op != "" && rightop.Equals(""))
                        {
                            op = "";
                            textBlock.Text = leftop;
                        }
                        else
                        if (op == "" && !leftop.Equals(""))
                        {
                            leftop = leftop.Remove(leftop.Length - 1);
                            textBlock.Text = leftop;
                        }
                        else if (!rightop.Equals(""))
                        {
                            rightop = rightop.Remove(rightop.Length - 1);
                            textBlock.Text = leftop + op + rightop;
                        }
                        if (leftop.Equals("") || leftop.Equals(""))
                        {
                            textBlock.Text = "";
                        }
                        break;
                    case "+/-":
                        if (op == "")
                        {
                            if (leftop[0] != '-') 
                                leftop = leftop.Insert(0, "-");
                            else 
                                leftop = leftop.Replace("-", " ");
                            textBlock.Text = leftop;
                        }
                        else
                        {
                            if (rightop[0] != '-') 
                                rightop = rightop.Insert(0, "-");
                            else 
                                rightop = rightop.Replace("-", " ");
                            textBlock.Text = leftop + op + '(' + rightop + ')';
                        }
                        break;
                    case "1/x":
                        try
                        {
                            double number = double.Parse(leftop);
                            if (number != 0)
                            {
                                leftop = Math.Pow(number, -1).ToString();
                                textBlock.Text = leftop;
                            }
                            else 
                                throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Деление на ноль");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "n!":
                        try
                        {
                            double number = double.Parse(leftop);
                            int digit = 1;
                            for (int i = 2; i <= number; digit *= i, i++);
                            if (digit < int.MaxValue) 
                                leftop = digit.ToString();
                            else 
                                throw new ArgumentException();
                            textBlock.Text = leftop;
                        }
                        catch
                        {
                            MessageBox.Show("Слишком большое число");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "a^2":
                        try
                        {
                            int number = int.Parse(leftop);
                            int digit = number * number;
                            if (digit < int.MaxValue) 
                                leftop = digit.ToString();
                            else 
                                throw new ArgumentException();
                            textBlock.Text = leftop;
                        }
                        catch
                        {
                            MessageBox.Show("Слишком большое число");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "sqrt":
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
                        break;
                    case "sin":
                        try
                        {
                            double number = double.Parse(leftop);
                            leftop = Math.Sin(number).ToString();
                            textBlock.Text = leftop;
                        }
                        catch
                        {
                            MessageBox.Show("Не корректное число");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "cos":
                        try
                        {
                            double number = double.Parse(leftop);
                            leftop = Math.Cos(number).ToString();
                            textBlock.Text = leftop;
                        }
                        catch
                        {
                            MessageBox.Show("Не корректное число");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "tan":
                        try
                        {
                            double number = double.Parse(leftop);
                            leftop = Math.Tan(number).ToString();
                            textBlock.Text = leftop;
                        }
                        catch
                        {
                            MessageBox.Show("Не корректное число");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "exp":
                        leftop = Math.Exp(1).ToString();
                        textBlock.Text = leftop;
                        break;
                    case "e^x":
                        try
                        {
                            double number = double.Parse(leftop);
                            if (Math.Exp(number) < double.MaxValue) leftop = Math.Exp(number).ToString();
                            else throw new ArgumentException();
                            textBlock.Text = leftop;
                        }
                        catch
                        {
                            MessageBox.Show("Слишком большое число");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "pi":
                        leftop = Math.PI.ToString();
                        textBlock.Text = leftop;
                        break;
                    default:
                        if (rightop != "")
                        {
                            Update_RightOp();
                            leftop = rightop;
                            rightop = "";
                        }
                        op = s;
                        break;
                }
            }
        }

        private void Update_RightOp()
        {
            try
            {
                int number1 = int.Parse(leftop);
                int number2 = int.Parse(rightop);
                switch (op)
                {
                    case "+":
                        try
                        {
                            if (number1 + number2 < int.MaxValue)
                                rightop = (number1 + number2).ToString();
                            else
                                throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Слишком большое число");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "-":
                        try
                        {
                            if (number1 - number2 > int.MinValue)
                                rightop = (number1 - number2).ToString();
                            else
                                throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Слишком большое число");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "*":
                        try
                        {
                            if (number1 * number2 < int.MaxValue)
                                rightop = (number1 * number2).ToString();
                            else
                                throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Слишком большое число");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "/":
                        try
                        {
                            if (number2 != 0)
                                rightop = ((double)number1 / number2).ToString();
                            else
                                throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Деление на ноль");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "MOD":
                        try
                        {
                            if (number2 != 0)
                                rightop = (number1 % number2).ToString();
                            else
                                throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Деление на ноль");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "DIV":
                        try
                        {
                            if (number2 != 0)
                                rightop = Math.Truncate((double)number1 / number2).ToString();
                            else
                                throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Деление на ноль");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                    case "^":
                        try
                        {
                            if (Math.Pow(number1, number2) < int.MaxValue)
                                rightop = Math.Pow(number1, number2).ToString();
                            else
                                throw new ArgumentException();
                        }
                        catch
                        {
                            MessageBox.Show("Слишком большое число");
                            leftop = rightop = "";
                            textBlock.Text = "0";
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                leftop = op = rightop = "";
                textBlock.Text = "0";
            }
        }
    }
}
