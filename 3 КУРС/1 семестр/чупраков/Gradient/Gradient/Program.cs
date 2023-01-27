using System;
using System.Collections.Generic;

namespace Gradient
{
    class Program
    {

		public static int Iterations = 1;
		//константа для метода градиентного спуска с постоянным шагом
		//начальное значение eps для метода с дроблением шага
		const double LAMBDA_CONSTANT = 0.01;

		
		//максимально возможное число итераций
		const int NUMBER_OF_ITERATIONS = 100000;

		//eps для критерия останова
		const double EPS = 0.0001;

		public static double f(List<double> x)
        {
            return 9 * x[0] * x[0] - 9 * x[0] - 6 * x[0] * x[1] + 4 * x[1] * x[1] - 6 * x[1];
			//return Math.Pow((x[0]-2), 2)+2*Math.Pow(x[1]-3,2)+8*Math.Pow(x[2]-5,2);
			//return 100*Math.Pow(x[1]-x[0]*x[0],2)+Math.Pow(x[0]-1,2);
        }

        public static List<double> GradientF(List<double> x)
        //градиент исследуемой функции
        {
            List<double> tmp = new List<double>();
            tmp.Add(18 * x[0] - 6 * x[1] - 9);
            tmp.Add(-6 * x[0] + 8 * x[1] - 6);

			/*tmp.Add(2 * (x[0] -2));
			tmp.Add(4 * (x[1] - 3));
			tmp.Add(16 * (x[2] - 5));*/


			/*tmp.Add(2 * (200*x[0]*x[0]*x[0] -200*x[0]*x[1]+x[0]-1));
			tmp.Add(200 * (x[1] - x[0]*x[0]));*/



			return tmp;
        }
		public static List<double> GradientDescent(List<double> x0)
		//minimizes N-dimensional function f; x0 - start point
		{
			List<double> cur_x = new List<double>(x0);
			List<double> old;	
			List<double> gr=new List<double>();
            double s;
			double Lambda= LAMBDA_CONSTANT;
			for (Iterations = 1; Iterations <= NUMBER_OF_ITERATIONS; Iterations++)
			{

				//save old value
				old = new List<double>(cur_x);
				//compute gradient
				gr = GradientF(cur_x);

                
                //вычисляем новое значение
                for (int j = 0; j < old.Count; j++)
				{
					cur_x[j] = cur_x[j] - Lambda * gr[j];
				}

				s = Math.Abs(f(cur_x) - f(old));
				if (s < EPS)
				{
					return cur_x;
				}
			}

			return cur_x;
		}
		static void Main(string[] args)
        {
			List<double> x = new List<double>();
			x.Add(2);
			x.Add(4);

			//x.Add(1);

			//x.Add(-1);
			//x.Add(2);
			//x.Add(1);
			
			List<double> ans = GradientDescent(x);
			Console.WriteLine("Min= " + f(ans));
			Console.Write("x, y: ");
			
			for (int i = 0; i < ans.Count; i++)
            {
				Console.Write(ans[i]+" ");
            }
			Console.WriteLine("\nКоличество итераций: " + Iterations);
		}
    }
}
