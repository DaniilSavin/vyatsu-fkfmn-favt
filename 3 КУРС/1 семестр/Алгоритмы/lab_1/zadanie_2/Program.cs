using System;

namespace zadanie_2
{
    class Program
    {
        static double F(double x)
        {
            return x + 5;
        }
        static void Main()
        {
            const double element = 0;
            double E = 0.00000001;
            double a = -100;
            double b = 100;
            double x;
            double k = 0;
            Console.WriteLine("["+a+";"+b+"]");
            do
            {
                k++;
                x = F(((a + b) / 2));
                if (x > element)
                {
                    b = (a + b) / 2;
                }
                else
                {
                    a = (a + b) / 2;
                }
                
            } while (!(Math.Abs(F(a)-F(b)) <= E));
            if (E - Math.Abs(F(a)) > E - Math.Abs(F(b)))
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine( b);
            }
            Console.WriteLine("k= "+k);


             x=0;
            k = 0;

            do
            {
                k++;
                x = F(((a + b) / 2));
                if (x > element)
                {
                    b = (a + b) / 2;
                }
                else
                {
                    a = (a + b) / 2;
                }

            } while (!(Math.Abs(F(a)) <= E || Math.Abs(F(b)) <= E));
            if (E - Math.Abs(F(a)) > E - Math.Abs(F(b)))
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
            Console.WriteLine("k= " + k);



            x = 0;
            k = 0;
            do
            {
                k++;
                x = F(((a + b) / 2));
                if (x > element)
                {
                    b = (a + b) / 2;
                }
                else
                {
                    a = (a + b) / 2;
                }

            } while (!(Math.Abs(F(a) - F(b)) <= 1e-12));
            if (E - Math.Abs(F(a)) > E - Math.Abs(F(b)))
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
            Console.WriteLine("k= " + k);   

            Console.ReadKey();
        }
    }
}

