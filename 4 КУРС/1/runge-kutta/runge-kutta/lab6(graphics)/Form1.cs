using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace lab6_graphics_
{
    public partial class Form1 : Form
    {
        public static List<double> listOfPointsX = new List<double>();
        public static List<double> listOfPointsY = new List<double>();
        public static List<double> listOfPointsT = new List<double>();
        public Form1()
        {
            InitializeComponent();
            DrawGraph();
        }
        static double Function_f(double a, double b, double x, double y)
        {
            return a - (b + 1) * x + Math.Pow(x, 2) * y;
        }

        static double Function_g(double b, double x, double y)
        {
            return b * x - Math.Pow(x, 2) * y;
        }

        static void Calculation()
        {
            double a = 1, b = 1.5, x = 1, y = 1, t = 0;
            double h = 0.1,
                   k1, k2, k3, k4, l1, l2, l3, l4;
            Console.WriteLine("\tX1\t\t\t\tX2");
            for (int i = 0; i < 500; i++)
            {
                listOfPointsX.Add(x);
                listOfPointsY.Add(y);
                listOfPointsT.Add(t);
                k1 = h * Function_f(a, b, x, y);
                l1 = h * Function_g(b, x, y);
                k2 = h * Function_f(a, b, x + k1 / 2, y + l1 / 2);
                l2 = h * Function_g(b, x + k1 / 2, y + l1 / 2);
                k3 = h * Function_f(a, b, x + k2 / 2, y + l2 / 2);
                l3 = h * Function_g(b, x + k2 / 2, y + l2 / 2);
                k4 = h * Function_f(a, b, x + k3 / 2, y + l3 / 2);
                l4 = h * Function_g(b, x + k3 / 2, y + l3 / 2);

                double fRez = Function_f(a, b, x, y);
                double gRez = Function_g(b, x, y);

                Console.WriteLine(Convert.ToString("\t" + fRez + "\t\t\t" + gRez));
                //Console.WriteLine(Convert.ToString("\t" + gRez + "\t\t"));

                x += 1 / 6.0 * (k1 + 2 * k2 + 2 * k3 + k4);
                y += 1 / 6.0 * (l1 + 2 * l2 + 2 * l3 + l4);
                t += h;
            }
        }

        private void DrawGraph()
        {
            GraphPane pane = zedGraph.GraphPane;
            pane.CurveList.Clear();
            pane.Title.Text = "График x(t)";
            pane.YAxis.Title.Text = "Y";
            pane.XAxis.Title.Text = "X";
            PointPairList list = new PointPairList();
            PointPairList list2 = new PointPairList();
            Calculation();
            for (int i = 0; i < listOfPointsX.Count; i++)
            {
                list.Add(listOfPointsT.ElementAt(i), listOfPointsY.ElementAt(i));
                list2.Add(listOfPointsT.ElementAt(i), listOfPointsX.ElementAt(i));
            }
            LineItem myCurve = pane.AddCurve("", list, Color.Blue, SymbolType.None);
            LineItem myCurve2 = pane.AddCurve("", list2, Color.Red, SymbolType.None);
            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }
    }
}
