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

namespace LAB_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calcBt_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)_1rb.IsChecked)
            {
                double P1 = double.Parse(P1Tb.Text); double P2 = double.Parse(P2Tb.Text); double P3 = double.Parse(P3Tb.Text);
                int i, f = int.Parse(fTb.Text), h = int.Parse(hTB.Text);

                double G = P1 * Math.Pow(P2, f) * Math.Pow(P3, h);

                resultTb.Text = Math.Round(G, 2).ToString() + $" ({G})";
                resultLb.Visibility = Visibility.Visible;
                resultTb.Visibility = Visibility.Visible;
            }
            else
            {
                if ((bool)_2rb.IsChecked)
                {
                    double P1 = double.Parse(P1Tb.Text); double P2 = double.Parse(P2Tb.Text); double P3 = double.Parse(P3Tb.Text);
                    int i = 2, f = int.Parse(fTb.Text), h = int.Parse(hTB.Text);

                    double m_p1 = Math.Pow(1-P1, i / 2);
                    double m_p2 = Math.Pow(1-P2, f / 2);
                    double m_p3 = Math.Pow(1-P3, h / 2);

                    double G = (1 - Math.Pow(m_p1, 2)) * (1 - Math.Pow(m_p2, 2)) * (1 - Math.Pow(m_p3, 2));

                    //double G = (1 - Math.Pow(1-P1, 2)) * (1 - Math.Pow(1 - m_p1, 2)) * (1 - Math.Pow(1 - m_p2, 2));



                    resultTb.Text = Math.Round(G, 2).ToString() + $" ({G}) dup";
                    resultLb.Visibility = Visibility.Visible;
                    resultTb.Visibility = Visibility.Visible;
                }
                else
                {
                    if ((bool)_3rb.IsChecked)
                    {

                    }
                }
            }
        }
    }
}
