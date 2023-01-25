using System;
using System.Collections.Generic;
using System.Text;

namespace zadanie_1
{
    class ComplexNumber
    {
		private double real { get; set; }
		private double image { get; set; }

		public ComplexNumber(double real, double image)
		{
			this.real = real;
			this.image = image;
		}
		public static ComplexNumber operator -(ComplexNumber num1, ComplexNumber num2) //операция вычитания
		{
			return new ComplexNumber(num1.real - num2.real, num1.image - num2.image);
		}

		public static ComplexNumber operator +(ComplexNumber num1, ComplexNumber num2) //операция сложения
		{
			return new ComplexNumber(num1.real + num2.real, num1.image + num2.image);
		}

		public static ComplexNumber operator *(ComplexNumber num1, ComplexNumber num2) //операция умножения
		{
			return new ComplexNumber(num1.real * num2.real - num1.image * num2.image, num1.real * num2.image + num1.image * num2.real);
		}

		public static ComplexNumber operator /(ComplexNumber num1, ComplexNumber num2) //операция деления
		{
			return new ComplexNumber((num1.real * num2.real + num1.image * num2.image) / (Math.Pow(num2.real, 2) + Math.Pow(num2.image, 2)),
				(num2.real * num1.image - num1.real * num2.image) / (Math.Pow(num2.real, 2) + Math.Pow(num2.image, 2)));
		}

		public override string ToString()
		{
			if (image > 0)
			{
				return real.ToString() + "+" + image.ToString() + "i";
			}
			else
			{
				return real.ToString() + image.ToString() + "i";
			}
		}
		private double RadToDeg(double rad)
		{
			return rad * (180 / Math.PI);
		}

		private double DegToRad(double deg)
		{
			return deg * (Math.PI / 180);
		}
		public ComplexNumber Pow(double n) //операция возведения в степень
		{
			double modul = Math.Sqrt(Math.Pow(real, 2) + Math.Pow(image, 2));
			double argument = Math.Atan(image / real);
			return new ComplexNumber(Math.Pow(modul, n) * Math.Cos(n * argument), Math.Pow(modul, n) * Math.Sin(n * argument));
		}
		public List<ComplexNumber> Sqrt(double n) //операция извлечения корня
		{
			double modul = Math.Sqrt(Math.Pow(real, 2) + Math.Pow(image, 2));
			double argument = RadToDeg(Math.Atan(image / real));
			List<ComplexNumber> result = new List<ComplexNumber>();
			for (int i = 0; i < n; i++)
			{
				result.Add(new ComplexNumber(Math.Pow((double)modul, (double)1 / n) * Math.Cos(DegToRad((argument + 2 * Math.PI * i) / n)),
					Math.Pow((double)modul, (double)1 / n) * Math.Sin(DegToRad((argument + 2 * Math.PI * i) / n))));
			}
			return result;
		}
	}
}
