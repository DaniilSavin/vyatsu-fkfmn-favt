using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RationalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Rational a = new Rational(1, 3);
            Rational b = new Rational(1, 3);
            a.PrintRational("a");
            b.PrintRational("b");

            Rational aCopy = a;
            Rational bCopy = b;
            Rational c = a * b;
            c.PrintRational("a * b");

            c = aCopy - bCopy;
            c.PrintRational("a - b");
            c = a + b;
            c.PrintRational("a + b");
            c = a / b;
            c.PrintRational("a / b");

            Rational d = new Rational(3, 6);
            d.PrintRational("d");
            if (a < d)
                Console.WriteLine("a < d");
            else
                if (a == d)
                Console.WriteLine("a = d");
            else
                Console.WriteLine("a > d");*/

            // Polinomial polin = new Polinomial("x^4+3x^3-24x^2+17x+3");
            //Polinomial polin = new Polinomial("x^4-10x^3+35x^2-50x+24");//1/3x^4-2/5x^3+1/3x^2-5x-2
            Console.Write("Введите 1ый многочлен: ");
            string polinom1 = Console.ReadLine();
            Polinomial polin = new Polinomial(polinom1);
            polin.KronekerMethod();

            Console.Write("Введите x0: ");
            string x0Str = Console.ReadLine();
            Rational x0;

            if (x0Str.Contains("/"))
                x0 = new Rational(int.Parse(x0Str.Substring(0, x0Str.IndexOf('/'))), int.Parse(x0Str.Substring(x0Str.IndexOf('/') + 1)));
            else
                x0 = new Rational(int.Parse(x0Str), 1);

            Console.Write(polin.GornerScheme(x0)[0]);

            Console.Write("\nВведите 2ой многочлен: ");
            string polinom2 = Console.ReadLine();
            Polinomial polin2 = new Polinomial(polinom2);//"x^2+4x+3"

            Polinomial res = polin.Plus(polin2);
            Console.Write("Сумма = ");
            res.Print();
            Console.WriteLine();

            res = polin.Minus(polin2);
            Console.Write("Разность = ");
            res.Print();
            Console.WriteLine();

            res = polin.Multy(polin2);
            Console.Write("Умножение = ");
            res.Print();
            Console.WriteLine();

            List<Polinomial> resDiv;
            Console.WriteLine();
            resDiv = polin.Div(polin2);
            Console.WriteLine("Частное: ");
            resDiv[0].Print();
            Console.WriteLine();
            Console.WriteLine("Остаток: ");
            resDiv[1].Print();
            Console.WriteLine();

            Rational a;
            Console.Write("Введите a: ");
            string aStr = Console.ReadLine();
            if (aStr.Contains("/"))
                a = new Rational(int.Parse(aStr.Substring(0, aStr.IndexOf('/'))), int.Parse(aStr.Substring(aStr.IndexOf('/') + 1)));
            else
                a = new Rational(int.Parse(aStr), 1);

            resDiv = polin2.DivUsingGornerScheme(a);
            Console.WriteLine("По схеме Горнера: \nЧастное: ");
            resDiv[0].Print();
            Console.WriteLine();
            Console.WriteLine("Остаток: ");
            resDiv[1].Print();
            Console.WriteLine();
            Console.Write("В общем виде: (");
            resDiv[0].Print();

            if (!a.Negative())
            Console.Write(")*(x-"+a.ToString());
            else
                Console.Write(")*(x+" + a.ToString().Substring(1));

            Console.Write(") + ");
            resDiv[1].Print();
            Console.WriteLine();

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}