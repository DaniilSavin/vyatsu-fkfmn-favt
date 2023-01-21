using System;

class Program
{
    private static int number;
    static void Main()
    {
        bool fl = false;
        while (!fl)
        {
            fl = true;
            Console.Write("Введите трехзначное число: ");
            number = Convert.ToInt32(Console.ReadLine());
            if (number < 100 || number > 999)
            {
                Console.WriteLine("Неверные исходные данные.");
                fl = false;
            }
        }
        int x, y, z;
        x = number % 10;
        y = number / 10 % 10;
        z = number / 100 % 10;
        Console.WriteLine(z + " " + y + " " + x);
            if (x != y)
                Console.WriteLine(z + " " + x + " " + y);
            if (y != 0 && y != z)
            {
                Console.WriteLine(y + " " + z + " " + x);
                if (x != z)
                    Console.WriteLine(y + " " + x + " " + z);
            }

            if (x != 0 && x != y && x != z)
            {
                Console.WriteLine(x + " " + y + " " + z);
                if (y != z)
                    Console.WriteLine(x + " " + z + " " + y);
            }
        Console.ReadKey();
    }
}