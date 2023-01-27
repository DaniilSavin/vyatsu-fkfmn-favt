using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = { 0.1, 10.2, 3.56, 1.2, 0.1, 0.4, 11.4, 90.1, 4.23, 10.24 };
            Calculation(arr);
        }

        public static double Calculation(double[] arr)
        {
           /*  int n = 10;
                       //double[] arr = new double[n];
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
            Console.WriteLine(min);
            return min;
        }
    }
}
