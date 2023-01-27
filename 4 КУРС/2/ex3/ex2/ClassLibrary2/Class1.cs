using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Expression
    {
        public Expression(double a, double b, double x)
        {
            Step = -1;
            if (b - x == 0)
            {
                throw new ArgumentException(""); //2
            }
 
            A = a;
            B = b;
            X = x;
        }

        public Expression(double a, double b, double x, double xMin, double xMax, double step) : this(a, b, x)
        {
            if (xMin > xMax)
            {
                throw new ArgumentException(""); //3
            }
            if (xMax - xMin < step)
            {
                throw new ArgumentException(""); //4
            }
            if (step <= 0)
            {
                throw new ArgumentException(""); //5
            }

            XMin = xMin;
            XMax = xMax;
            Step = step;
        }

        public double A { get; }
        public double B { get; }
        public double X { get; private set; }
        public double XMin { get; }
        public double XMax { get; }
        public double Step { get; }

        public double Calc()
        {
            if (B == 0)//1
            {
                return double.NaN;  
            }
            return 2 * Math.Atan(25*A/B)+
                3*Math.Pow( Math.Cos((9 * X * B)/(B-X)),2);
        }

        public List<double> CalcRange()
        {
            if (Step <= -1)
            {
                throw new Exception();
            }
            List<double> result = new List<double>();
            X = XMin;
            double tmpStep = Step;
            while (X < XMax + tmpStep)
            {
                if (B == 0)//6
                {
                    result.Add(double.NaN);
                    X += Step;
                    continue;
                }
                result.Add(Calc());
                X += Step;
            }
            return result;
        }
    }
}
