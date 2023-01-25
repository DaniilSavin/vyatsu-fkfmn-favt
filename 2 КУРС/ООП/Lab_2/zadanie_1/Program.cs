using System;
using System.Collections.Generic;

namespace zadanie_1
{
    class Program
    {
		static void Main(string[] args)
        {
			Console.WriteLine("Ввод 1 комплексного числа:");
			Console.Write("Введите действительную часть(число): ");
			double x = double.Parse(Console.ReadLine());
			Console.Write("Введите мнимую часть(число): ");
			double y = double.Parse(Console.ReadLine());
			ComplexNumber ComplexNumber1 = new ComplexNumber(x, y);

			Console.WriteLine("\nВвод 2 комплексного числа:");
			Console.Write("Введите действительную часть(число): ");
			x = double.Parse(Console.ReadLine());
			Console.Write("Введите мнимую часть(число): ");
			y = double.Parse(Console.ReadLine());
			ComplexNumber ComplexNumber2 = new ComplexNumber(x, y);
			Console.Write("\nВведите степень для извлечения: ");
			double n=double.Parse(Console.ReadLine());
			Console.Write("Введите степень для возведения: ");
			double z= double.Parse(Console.ReadLine());
			Console.Clear();
			Console.WriteLine("Вы ввели: "+ ComplexNumber1+", "+ ComplexNumber2);

			Console.WriteLine("\nОперация извлечения корня из ("+ ComplexNumber1+") степени "+n+":");
			List <ComplexNumber> ComplexNumbers = ComplexNumber1.Sqrt(n);
			foreach (ComplexNumber item in ComplexNumbers)
			{
				Console.WriteLine(item.ToString());
			}
			Console.WriteLine("\nОперация извлечения корня из (" + ComplexNumber2 + ") степени "+n+":");
			List<ComplexNumber> ComplexNumbers1 = ComplexNumber2.Sqrt(n);
			foreach (ComplexNumber item in ComplexNumbers1)
			{
				Console.WriteLine(item.ToString());
			}

			Console.WriteLine("\nОперация возведения "+ComplexNumber1 + " в степень "+z+" : "+ (ComplexNumber1.Pow(z)).ToString());
			Console.WriteLine("Операция возведения " + ComplexNumber2 + " в степень " + z + " : " + (ComplexNumber2.Pow(z)).ToString());
			Console.WriteLine("Операция деления: "+ ((ComplexNumber1 / ComplexNumber2).ToString()));
			Console.WriteLine("Операция умножения: "+ ((ComplexNumber1 * ComplexNumber2).ToString())) ;
			Console.WriteLine("Операция складывания: "+ ((ComplexNumber1 + ComplexNumber2).ToString()));
			Console.WriteLine("Операция вычитания: "+ ((ComplexNumber1 - ComplexNumber2).ToString()));
			Console.ReadKey();
		}
    }
}
