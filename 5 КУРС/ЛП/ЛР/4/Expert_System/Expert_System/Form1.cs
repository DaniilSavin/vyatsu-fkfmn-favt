using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expert_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double[] coeff = new double[8];
        private void button1_Click(object sender, EventArgs e)
        {
            double _result = 0;
            string result = "";
            if (son_yes.Checked) { result += "0,5"; coeff[0] = 0.5; }
            else { result += "-0,5"; coeff[0] = -0.5; }

            if (bol_head_yes.Checked) { result += "\n-2"; coeff[1] = -2.0; }
            else { result += "\n2"; coeff[1] = 2.0; }

            if (nastr_no.Checked) { result += "\n-0,5"; coeff[2] = -0.5; }
            else { result += "\n0,5"; coeff[2] = 0.5; }

            if (med_osm_yes.Checked) { result += "\n-0,5"; coeff[3] = -0.5; }
            else { result += "\n0,5"; coeff[3] = 0.5; }

            if (vred_yes.Checked) { result += "\n-1"; coeff[4] = -1.0; }
            else { result += "\n1"; coeff[4] = 1.0; }

            if (voln_yes.Checked) { result += "\n-0,5"; coeff[5] = -0.5; }
            else { result += "\n0,5"; coeff[5] = 0.5; }

            if (ves_yes.Checked) { result += "\n-0,5"; coeff[6] = -0.5; }
            else { result += "\n0,5"; coeff[6] = 0.5; }

            if (bol_yes.Checked) { result += "\n-2"; coeff[7] = -2.0; }
            else { result += "\n2"; coeff[7] = 2.0; }

            for (int i = 0; i < coeff.Length; i++)
            {
                _result += coeff[i];
            }

            StreamWriter sw = new StreamWriter("Test.txt");

            sw.WriteLine(result);
            sw.Close();
            richTextBox1.Text = result + "\nfile created\n" + _result.ToString();
        }
    }
}
