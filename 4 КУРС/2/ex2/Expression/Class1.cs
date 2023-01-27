using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionNamespace
{
    public class Expression
    {
        public double A { get; }
        public double B { get; }
        public double X { get; private set; }
        public double XMin { get; }
        public double XMax { get; }
        public double Step { get; }

        public Expression(double a, double b, double x)
        {
            A = a;
            B = b;
            X = x;

            if (a == 1)
            {
                throw new ArgumentException("");//1
            }
            if (x <= 0)
            {
                throw new ArgumentException("");//2
            }
        }

        public Expression(double a, double b, double x, double xMin, double xMax, double step) : this(a, b, x)
        {
            XMin = xMin;
            XMax = xMax;
            Step = step;
            if (Step == 0)
            {
                throw new ArgumentException("");//3
            }
            if (xMin > XMax)
            {
                throw new ArgumentException("");//4
            }
            if (step > XMax-XMin)
            {
                throw new ArgumentException(""); //5
            }
        }

        public double Calc()
        {
            //Console.WriteLine(X);
            return (A + 20 * B) / Math.Pow(X, 3) * Math.Log(2 * X, Math.E) - (1 / Math.Pow(A - 1, 2));
        }

        public double[] CalcInterval()
        {
            List<double> interval = new List<double>();
            for (X = XMin; X < XMax; X += Step)
            {
                interval.Add(Calc());
            }
            return interval.ToArray();
        }

    }
}
