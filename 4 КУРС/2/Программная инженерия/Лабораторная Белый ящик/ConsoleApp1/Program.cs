using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        public static double Calculation(double[] arr)
        {
            int n = 10;
/*            //double[] arr = new double[n];
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < arr.Length; i++)
                arr[i] = Math.Round((rand.NextDouble() * 100), 2);*/

            Console.WriteLine("Массив: ");
            foreach (double a in arr)
                Console.WriteLine(a + " ");
            Console.WriteLine();
            double min = double.MaxValue;
            for (int i = 0; i < arr.Length / 2; i++)
            {
                if (arr[i] + arr[i + 5] < min)
                    min = arr[i] + arr[i + 5];
            }
            return min;
        }
    }
}
