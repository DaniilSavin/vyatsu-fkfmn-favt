using System;
using System.Collections.Generic;

namespace Builder
{
    public interface IEquationBuilder
    {
        void SetPowerOfEquation(int power);

        void SetAnswer(int answer);

        void PositiveOnly(bool floors);
    }

    public class EquationBuilder : IEquationBuilder
    {
        private Hotel _product = new Hotel();

        public EquationBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Hotel();
        }

        public void SetPowerOfEquation(int stars)
        {
            this._product.Add(stars.ToString());
        }

        public void SetAnswer(int meals)
        {
            this._product.Add(meals.ToString());
        }

        public void PositiveOnly(int floors)
        {
            this._product.Add(floors.ToString());
        }

        public Hotel GetProduct()
        {
            Hotel result = this._product;

            this.Reset();

            return result;
        }
    }
    public class Hotel
    {
        private List<object> Attributes = new List<object>();

        public void Add(string part)
        {
            this.Attributes.Add(part);
        }

        public 

        public string ListAttributes()
        {
            string str = string.Empty;

            for (int i = 0; i < this.Attributes.Count; i++)
            {
                str += this.Attributes[i] + ", ";
            }

            str = str.Remove(str.Length - 2);

            return "Характеристики отеля: " + str + "\n";
        }
    }
    public class Director
    {
        private IEquationBuilder _builder;

        public IEquationBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildCheapHotel()
        {
            this._builder.SetPowerOfEquation(3);
            this._builder.SetAnswer(2);
            this._builder.PositiveOnly(3);
        }

        public void BuildExpensiveHotel()
        {
            this._builder.SetPowerOfEquation(5);
            this._builder.SetAnswer(3);
            this._builder.PositiveOnly(10);
        }

        public void BuildCustomHotel()
        {
            this._builder.SetPowerOfEquation(2);
            this._builder.PositiveOnly(10);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();
            var builder = new EquationBuilder();
            director.Builder = builder;

            Console.WriteLine("Дешевый отель");
            director.BuildCheapHotel();
            Console.WriteLine(builder.GetProduct().ListAttributes());

            Console.WriteLine("Дорогой отель:");
            director.BuildExpensiveHotel();
            Console.WriteLine(builder.GetProduct().ListAttributes().);

            Console.WriteLine("Кастомный отель:");
            builder.SetPowerOfEquation(10);
            builder.PositiveOnly(20);
            Console.Write(builder.GetProduct().ListAttributes());
        }
    }
}
