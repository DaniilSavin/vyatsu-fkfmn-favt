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
using System.Windows.Shapes;

namespace FifteenWPF2
{
    /// <summary>
    /// Логика взаимодействия для ChangeSizeWindow.xaml
    /// </summary>
    public partial class ChangeSizeWindow : Window
    {
        int size;
        public ChangeSizeWindow()
        {
            InitializeComponent();
            size = -1;
        }

        public int Size
        {
            get => size;
        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int _size = int.Parse(sizeTextBox.Text);
                if (_size < 2 || _size > 100)
                    throw new Exception();
                size = _size;
                Close();
            }
            catch
            {
                MessageBox.Show("Введите корректное значение!");
            }
        }
    }
}