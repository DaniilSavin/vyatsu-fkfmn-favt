using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static double Function_f(double d)
        {
            return d;
        }

        static double Function_g(double m, double x1, double x2, double gamma, double r12)
        {
            return -gamma * (m * (x1 - x2) / r12);
        }
        static void Main(string[] args)
        {
            List<double> listOfPointsX1 = new List<double>();
            List<double> listOfPointsX2 = new List<double>();
            List<double> listOfPointsY1 = new List<double>();
            List<double> listOfPointsY2 = new List<double>();
            List<double> listOfPointsgRezX1 = new List<double>();
            List<double> listOfPointsgRezX2 = new List<double>();
            List<double> listOfPointsgRezY1 = new List<double>();
            List<double> listOfPointsgRezY2 = new List<double>();
            double m1 = 1000, m2 = 1, x1 = 2, x2 = 15, y1 = 2, y2 = 12,
            dx1 = -2, dx2 = 2, dy1 = 2, dy2 = -3, h = 0.5, gamma = 1, r12, r21,
            k11, k12, k13, k14, l11, l12, l13, l14,
            k21, k22, k23, k24, l21, l22, l23, l24,
            k31, k32, k33, k34, l31, l32, l33, l34,
            k41, k42, k43, k44, l41, l42, l43, l44;

            Console.WriteLine("\tX1\t\t\t\tX2");
            for (int i = 0; i < 100; i++)
            {
                r12 = Math.Pow(Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)), 3);
                r21 = r12;
                listOfPointsX1.Add(x1);
                listOfPointsX2.Add(x2);
                listOfPointsY1.Add(y1);
                listOfPointsY2.Add(y2);

                //x1
                k11 = h * Function_f(dx1);
                l11 = h * Function_g(m2, x1, x2, gamma, r12);
                k12 = h * Function_f(dx1 + k11 / 2);
                l12 = h * Function_g(m2, x1 + k11 / 2, x2 + l11 / 2, gamma, r12);
                k13 = h * Function_f(dx1 + k12 / 2);
                l13 = h * Function_g(m2, x1 + k12 / 2, x2 + l12 / 2, gamma, r12);
                k14 = h * Function_f(dx1 + k13 / 2);
                l14 = h * Function_g(m2, x1 + k13 / 2, x2 + l13 / 2, gamma, r12);
                double fRezx1 = Function_f(dx1);
                double gRezx1 = Function_g(m2, x1, x2, gamma, r12);
                //Console.WriteLine(Convert.ToString("\t" + fRezx1 + "\t\t\t" + gRezx1));
                dx1 += 1 / 6.0 * (k11 + 2 * k12 + 2 * k13 + k14);
                x1 += 1 / 6.0 * (l11 + 2 * l12 + 2 * l13 + l14);
                listOfPointsgRezX1.Add(gRezx1);

                //x2
                k21 = h * Function_f(dx2);
                l21 = h * Function_g(m1, x2, x1, gamma, r21);
                k22 = h * Function_f(dx2 + k21 / 2);
                l22 = h * Function_g(m1, x2 + k21 / 2, x1 + l21 / 2, gamma, r21);
                k23 = h * Function_f(dx2 + k22 / 2);
                l23 = h * Function_g(m1, x2 + k22 / 2, x1 + l22 / 2, gamma, r21);
                k24 = h * Function_f(dx2 + k23 / 2);
                l24 = h * Function_g(m1, x2 + k23 / 2, x1 + l23 / 2, gamma, r21);
                double fRezx2 = Function_f(dx2);
                double gRezx2 = Function_g(m1, x2, x1, gamma, r21);
                //Console.WriteLine(Convert.ToString("\t" + fRezx2 + "\t\t\t" + gRezx2));
                dx2 += 1 / 6.0 * (k21 + 2 * k22 + 2 * k23 + k24);
                x2 += 1 / 6.0 * (l21 + 2 * l22 + 2 * l23 + l24);
                listOfPointsgRezX2.Add(gRezx2);


                //y1
                k31 = h * Function_f(dy1);
                l31 = h * Function_g(m2, y1, y2, gamma, r12);
                k32 = h * Function_f(dy1 + k31 / 2);
                l32 = h * Function_g(m2, y1 + k31 / 2, y2 + l31 / 2, gamma, r12);
                k33 = h * Function_f(dy1 + k32 / 2);
                l33 = h * Function_g(m2, y1 + k32 / 2, y2 + l32 / 2, gamma, r12);
                k34 = h * Function_f(dy1 + k33 / 2);
                l34 = h * Function_g(m2, y1 + k33 / 2, y2 + l33 / 2, gamma, r12);
                double fRezy1 = Function_f(dy1);
                double gRezy1 = Function_g(m2, y1, y2, gamma, r12);
                //Console.WriteLine(Convert.ToString("\t" + fRezy1 + "\t\t\t" + gRezy1));
                dy1 += 1 / 6.0 * (k31 + 2 * k32 + 2 * k33 + k34);
                y1 += 1 / 6.0 * (l31 + 2 * l32 + 2 * l33 + l34);
                listOfPointsgRezY1.Add(gRezy1);

                //y2
                k41 = h * Function_f(dy2);
                l41 = h * Function_g(m1, y2, y1, gamma, r21);
                k42 = h * Function_f(dy2 + k41 / 2);
                l42 = h * Function_g(m1, y2 + k41 / 2, y1 + l41 / 2, gamma, r21);
                k43 = h * Function_f(dy2 + k42 / 2);
                l43 = h * Function_g(m1, y2 + k42 / 2, y1 + l42 / 2, gamma, r21);
                k44 = h * Function_f(dy2 + k43 / 2);
                l44 = h * Function_g(m1, y2 + k43 / 2, y1 + l43 / 2, gamma, r21);
                double fRezy2 = Function_f(dy2);
                double gRezy2 = Function_g(m1, y2, y1, gamma, r21);
                //Console.WriteLine(Convert.ToString("\t" + fRezy2 + "\t\t\t" + gRezy2));
                dy2 += 1 / 6.0 * (k41 + 2 * k42 + 2 * k43 + k44);
                y2 += 1 / 6.0 * (l41 + 2 * l42 + 2 * l43 + l44);
                listOfPointsgRezY2.Add(gRezy2);
                //Console.WriteLine(Convert.ToString("\t" + gRezx1 + "\t\t\t" + gRezy1 + "\t\t\t" + gRezx2 + "\t\t\t" + gRezy2));
            }

            using (StreamWriter sw = new StreamWriter("x1.txt"))
            {
                foreach (double x in listOfPointsX1)
                    sw.WriteLine(x.ToString());
            }
            using (StreamWriter sw = new StreamWriter("x2.txt"))
            {
                foreach (double x in listOfPointsX2)
                    sw.WriteLine(x.ToString());
            }
            using (StreamWriter sw = new StreamWriter("y1.txt"))
            {
                foreach (double x in listOfPointsY1)
                    sw.WriteLine(x.ToString());
            }
            using (StreamWriter sw = new StreamWriter("y2.txt"))
            {
                foreach (double x in listOfPointsY2)
                    sw.WriteLine(x.ToString());
            }
        }
    }
}

/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static double Function_f(double d)
        {
            return d;
        }

        static double Function_g(double m, double x1, double x2, double gamma, double r12)
        {
            return -gamma * (m * (x1 - x2) / r12);
        }
        static void Main(string[] args)
        {
            List<double> listOfPointsX1 = new List<double>();
            List<double> listOfPointsX2 = new List<double>();
            List<double> listOfPointsY1 = new List<double>();
            List<double> listOfPointsY2 = new List<double>();
            List<double> listOfPointsgRezX1 = new List<double>();
            List<double> listOfPointsgRezX2 = new List<double>();
            List<double> listOfPointsgRezY1 = new List<double>();
            List<double> listOfPointsgRezY2 = new List<double>();
            double m1 = 1000, m2 = 1, x1 = 2, x2 = 15, y1 = 2, y2 = 12,
            dx1 = -2, dx2 = 2, dy1 = 2, dy2 = -3, h = 0.5, gamma = 1, r12, r21,
            k11, k12, k13, k14, l11, l12, l13, l14,
            k21, k22, k23, k24, l21, l22, l23, l24,
            k31, k32, k33, k34, l31, l32, l33, l34,
            k41, k42, k43, k44, l41, l42, l43, l44;

            Console.WriteLine("\tX1\t\t\t\tX2");
            for (int i = 0; i < 100; i++)
            {
                r12 = Math.Pow(Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)), 3);
                r21 = r12;

                //x1
                k11 = h * Function_f(dx1);
                l11 = h * Function_g(m2, x1, x2, gamma, r12);
                k21 = h * Function_f(dx2);
                l21 = h * Function_g(m1, x2, x1, gamma, r21);
                k31 = h * Function_f(dy1);
                l31 = h * Function_g(m2, y1, y2, gamma, r12);
                k41 = h * Function_f(dy2);
                l41 = h * Function_g(m1, y2, y1, gamma, r21);


                k12 = h * Function_f(dx1 + k11 / 2);
                l12 = h * Function_g(m2, x1 + l11 / 2, x2 + l21 / 2, gamma, r12);
                k22 = h * Function_f(dx2 + k21 / 2);
                l22 = h * Function_g(m1, x2 + l21 / 2, x1 + l11 / 2, gamma, r21);
                k32 = h * Function_f(dy1 + k31 / 2);
                l32 = h * Function_g(m2, y1 + l31 / 2, y2 + l41 / 2, gamma, r12);
                k42 = h * Function_f(dy2 + k41 / 2);
                l42 = h * Function_g(m1, y2 + l41 / 2, y1 + l31 / 2, gamma, r21);


                k13 = h * Function_f(dx1 + k12 / 2);
                l13 = h * Function_g(m2, x1 + l12 / 2, x2 + l22 / 2, gamma, r12);
                k23 = h * Function_f(dx2 + k22 / 2);
                l23 = h * Function_g(m1, x2 + l22 / 2, x1 + l12 / 2, gamma, r21);
                k33 = h * Function_f(dy1 + k32 / 2);
                l33 = h * Function_g(m2, y1 + l32 / 2, y2 + l42 / 2, gamma, r12);
                k43 = h * Function_f(dy2 + k42 / 2);
                l43 = h * Function_g(m1, y2 + l42 / 2, y1 + l32 / 2, gamma, r21);


                k14 = h * Function_f(dx1 + k13 / 2);
                l14 = h * Function_g(m2, x1 + l13 / 2, x2 + l23 / 2, gamma, r12);
                k24 = h * Function_f(dx2 + k23 / 2);
                l24 = h * Function_g(m1, x2 + l23 / 2, x1 + l13 / 2, gamma, r21);
                k34 = h * Function_f(dy1 + k33 / 2);
                l34 = h * Function_g(m2, y1 + l33 / 2, y2 + l43 / 2, gamma, r12);
                k44 = h * Function_f(dy2 + k43 / 2);
                l44 = h * Function_g(m1, y2 + l43 / 2, y1 + l33 / 2, gamma, r21);


                double fRezx1 = Function_f(dx1);
                double gRezx1 = Function_g(m2, x1, x2, gamma, r12);
                //Console.WriteLine(Convert.ToString("\t" + fRezx1 + "\t\t\t" + gRezx1));
                dx1 += 1 / 6.0 * (k11 + 2 * k12 + 2 * k13 + k14);
                x1 += 1 / 6.0 * (l11 + 2 * l12 + 2 * l13 + l14);
                listOfPointsX1.Add(x1);
                listOfPointsgRezX1.Add(gRezx1);

                //x2
                
                double fRezx2 = Function_f(dx2);
                double gRezx2 = Function_g(m1, x2, x1, gamma, r21);
                //Console.WriteLine(Convert.ToString("\t" + fRezx2 + "\t\t\t" + gRezx2));
                dx2 += 1 / 6.0 * (k21 + 2 * k22 + 2 * k23 + k24);
                x2 += 1 / 6.0 * (l21 + 2 * l22 + 2 * l23 + l24);
                listOfPointsX2.Add(x2);
                listOfPointsgRezX2.Add(gRezx2);


                //y1


                double fRezy1 = Function_f(dy1);
                double gRezy1 = Function_g(m2, y1, y2, gamma, r12);
                //Console.WriteLine(Convert.ToString("\t" + fRezy1 + "\t\t\t" + gRezy1));
                dy1 += 1 / 6.0 * (k31 + 2 * k32 + 2 * k33 + k34);
                y1 += 1 / 6.0 * (l31 + 2 * l32 + 2 * l33 + l34);
                listOfPointsY1.Add(y1);
                listOfPointsgRezY1.Add(gRezy1);

                //y2


                double fRezy2 = Function_f(dy2);
                double gRezy2 = Function_g(m1, y2, y1, gamma, r21);
                //Console.WriteLine(Convert.ToString("\t" + fRezy2 + "\t\t\t" + gRezy2));
                dy2 += 1 / 6.0 * (k41 + 2 * k42 + 2 * k43 + k44);
                y2 += 1 / 6.0 * (l41 + 2 * l42 + 2 * l43 + l44);
                listOfPointsY2.Add(y2);
                listOfPointsgRezY2.Add(gRezy2);
                //Console.WriteLine(Convert.ToString("\t" + gRezx1 + "\t\t\t" + gRezy1 + "\t\t\t" + gRezx2 + "\t\t\t" + gRezy2));
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Дмитрий\Desktop\runge-kutta\lab3\bin\Debug\x1.txt"))
            {
                foreach (double x in listOfPointsgRezX1)
                    sw.WriteLine(x.ToString());
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Дмитрий\Desktop\runge-kutta\lab3\bin\Debug\x2.txt"))
            {
                foreach (double x in listOfPointsgRezX2)
                    sw.WriteLine(x.ToString());
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Дмитрий\Desktop\runge-kutta\lab3\bin\Debug\y1.txt"))
            {
                foreach (double x in listOfPointsgRezY1)
                    sw.WriteLine(x.ToString());
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Дмитрий\Desktop\runge-kutta\lab3\bin\Debug\y2.txt"))
            {
                foreach (double x in listOfPointsgRezY2)
                    sw.WriteLine(x.ToString());
            }
        }
    }
}
*/