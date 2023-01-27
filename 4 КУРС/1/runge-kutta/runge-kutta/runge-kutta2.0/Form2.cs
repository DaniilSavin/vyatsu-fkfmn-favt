using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;

namespace runge_kutta2._0
{
    public partial class Form2 : Form
    {
        public static List<double> listOfPointsX = new List<double>();
        public static List<double> listOfPointsZ = new List<double>();
        public static List<double> listOfPointsT = new List<double>();
        public Form2()
        {
            InitializeComponent();
            DrawGraph();
        }
        //1
        static double Function_f(double a, double x, double z)
        {
            return z;
        }

         /* static double Function_g(double a, double x, double z)
          {
              return -2*x; //1
              return -2 * x + z;//2
              return -2 * x + z + z * x * x;//3
              return -2 * x - 0.02 * x * x + z + z * x * x;//4
          }*/

        //5
        static double Function_g(double a, double x, double z, double t)
        {
            return 1 * Math.Sin(Math.Sqrt(2) * t) - (2 * x) - (0.02 * x * x) + (1 + x * x) * z;
        }

        static void Calculation5()
         {
            double x = 2.0, z = 0, t = 0, a = 2.0, k1, k2, k3, k4, l1, l2, l3, l4;
            double h = 0.01;
             for (int i = 0; i < 5000; i++)
             {
                 listOfPointsX.Add(x);
                 listOfPointsZ.Add(z);
                 listOfPointsT.Add(t);
                 k1 = h * Function_f(a, x, z);
                 l1 = h * Function_g(a, x, z, t);
                 k2 = h * Function_f(a, x + k1 / 2, z + l1 / 2);
                 l2 = h * Function_g(a, x + k1 / 2, z + l1 / 2, t);
                 k3 = h * Function_f(a, x + k2 / 2, z + l2 / 2);
                 l3 = h * Function_g(a, x + k2 / 2, z + l2 / 2, t);
                 k4 = h * Function_f(a, x + k3 / 2, z + l3 / 2);
                 l4 = h * Function_g(a, x + k3 / 2, z + l3 / 2, t);
                 double fRez = (Function_f(a, x, z));
                 double gRez = (Function_g(a, x, z, t));
                 x += 1 / 6.0 * (k1 + 2 * k2 + 2 * k3 + k4);
                 z += 1 / 6.0 * (l1 + 2 * l2 + 2 * l3 + l4);
                 t += h;
             }
         }

       /*static void Calculation()
        {
            double x = 2.0, z = 0, t = 0, a = 2.0, k1, k2, k3, k4, l1, l2, l3, l4;
            double h = 0.01;
            //Console.WriteLine("\tX\t\t\t\tZ");
            for (int i = 0; i < 5000; i++)
            {
                listOfPointsX.Add(x);
                listOfPointsZ.Add(z);
                listOfPointsT.Add(t);
                k1 = h * Function_f(a, x, z);
                l1 = h * Function_g(a, x, z);
                k2 = h * Function_f(a, x + k1 / 2, z + l1 / 2);
                l2 = h * Function_g(a, x + k1 / 2, z + l1 / 2);
                k3 = h * Function_f(a, x + k2 / 2, z + l2 / 2);
                l3 = h * Function_g(a, x + k2 / 2, z + l2 / 2);
                k4 = h * Function_f(a, x + k3 / 2, z + l3 / 2);
                l4 = h * Function_g(a, x + k3 / 2, z + l3 / 2);
                double fRez = (Function_f(a, x, z));
                double gRez = (Function_g(a, x, z));
                x += 1 / 6.0 * (k1 + 2 * k2 + 2 * k3 + k4);
                z += 1 / 6.0 * (l1 + 2 * l2 + 2 * l3 + l4);
                t += h;
            }
        }*/

        private void DrawGraph()
        {
            GraphPane pane = zedGraph.GraphPane;
            pane.CurveList.Clear();
            pane.Title.Text = "График z(x)";
            pane.YAxis.Title.Text = "Y";
            pane.XAxis.Title.Text = "X";
            PointPairList list = new PointPairList();
            Calculation5();
            for (int i = 0; i < listOfPointsX.Count; i++)
            {
                list.Add(listOfPointsZ.ElementAt(i), listOfPointsX.ElementAt(i));
            }
            LineItem myCurve = pane.AddCurve("", list, Color.Black, SymbolType.None);
            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }
    }
}
