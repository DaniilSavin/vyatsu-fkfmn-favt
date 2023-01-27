using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie_2
{
    public partial class Form1 : Form
    {

        int N = 0;
        double[] arr_x = new double[20];
        double[] arr_y = new double[20];
        bool fl = false;
        double[] d1 = new double[20];
        double[] d2 = new double[20];
        double[] d3 = new double[20];
        double[] d4 = new double[20];
        double h;
        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            FileButton.Checked = false;
            TextBoxButton.Checked = false;



        }

        private void FileButton_CheckedChanged(object sender, EventArgs e)
        {
            
            textBox1.Enabled = false;
            if (FileButton.Checked == true)
            {
                fl = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            N = int.Parse(textBox2.Text);
            if (N > 20)
            {
                Environment.Exit(-1);
            }

            var lines = new List<string>();
            lines.AddRange(textBox1.Lines);

            if (TextBoxButton.Checked == true)
            {
                for (int i=0; i<N; i++)
                {
                    arr_x[i] = int.Parse(lines[i]);
                }
                for (int i= 0; i< N; i++) arr_y[i]= f(arr_x[i]);
                for (int i= 0; i<N; i++) d1[i]= arr_y[i + 1] - arr_y[i];
                for (int i = 0; i < N-1; i++) d2[i]= d1[i + 1] - d1[i];
                for (int i = 0; i < N-2; i++) d3[i]= d2[i + 1] - d2[i];
                for (int i = 0; i < N-3; i++) d4[i]= d3[i + 1] - d3[i];
                h= Math.Abs(arr_x[2] - arr_x[1]);
                switch ()
                {
                    case 1:
                        FirstFormula();
                        break;

                        case 2:begin
                            i:= 1;
                        while a > x[i] do i:= i + 1;


                          k:= i;
                        q:= (a - x[k]) / h;
                        f:= y[k] + d1[k - 1] * q + d2[k - 2] * q * (q + 1) / 2 +
                                     d3[k - 3] * q * (q + 1) * (q + 2) / 6;
                        R:= abs(d4[k - 4] * q * (q + 1) * (q + 2) * (q + 3) / 24);
                        break;
                }
            }

        }
        double FirstFormula()
        {
            double i, a, k, q, f, R;
            i = 1;
            while (a > arr_x[i])
                i = i + 1;
            k = i - 1;
            q = (a - arr_x[k]) / h;
            f = arr_y[k] + d1[k] * q + d2[k] * q * (q - 1) / 2 + d3[k] * q * (q - 1) * (q - 2) / 6;
            R = Math.Abs(d4[k] * q * (q - 1) * (q - 2) * (q - 3) / 24);
            return 0;
        }
        double f(double x)
        {
           return x + Math.Exp(-Math.Sqrt(x));
        }
        private void TextBoxButton_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }
    }
}
