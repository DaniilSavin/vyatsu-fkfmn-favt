using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameoftheatre;
            string nameofperformance;
            string time;
            int price;
            Console.WriteLine("Введите данные:");
            Console.WriteLine("Название театра:");
            nameoftheatre=Console.ReadLine();
            Console.WriteLine("Название спектакля:");
            nameofperformance =Console.ReadLine();
            Console.WriteLine("Время:");
            time =Console.ReadLine();
            Console.WriteLine("Стоимость спектакля:");
            price= int.Parse(Console.ReadLine());
            Console.WriteLine("Приглашаем в наш театр \"" +nameoftheatre+"\". У нас вы можете насладиться спектаклем \"" + nameofperformance + "\" в " + time + ". Цена билета " + price + " р.");
            Console.ReadKey();
        }
    }
}
