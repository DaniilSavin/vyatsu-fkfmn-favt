using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_1
{
    class Program
    {
        //const int n = 6;
        const int n = 23;
        const int how_many_friends = 5;

        public static double our_Pos_X = 14;
        public static double our_Pos_Y = 2;

        public static int x = 0;
        public static int y = 15;

        public static List<People> people = new List<People>();
        public static List<Rasst> rasst = new List<Rasst>();
        public static List<Rasst> final = new List<Rasst>();
        public static People s; public static Rasst rr;
        public static Random rnd = new Random();

        public static int count = 0;

        public class People
        {
            public double X;
            public double Y;
            public bool ability;
            public People(double X, double Y, bool ability)
            {
                this.X = X;
                this.Y = Y;
                this.ability = ability;
            }
        }
        public class Rasst
        {
            public double r;
            public int num;
            public bool ability;
            public Rasst(double r, int num, bool ability)
            {
                this.r = r;
                this.num = num;
                this.ability = ability;
            }
        }

        static void ReadFromFile(string fileName)
        {
            foreach (string line in File.ReadLines("input.txt"))
            {
                string[] inputString = line.Split('	');
                double Y = double.Parse(inputString[0]);
                double X = double.Parse(inputString[1]);
                bool a = bool.Parse(inputString[2]);
                people.Add(new People(X, Y, a));
            }
        }

        static void Main(string[] args)
        {
            ReadFromFile("input.txt");
            for (int i = 0; i < n; i++)
            {
                rr = new Rasst(Math.Sqrt(Math.Pow(our_Pos_X - people[i].X, 2) + Math.Pow(our_Pos_Y - people[i].Y, 2)), i, people[i].ability);
                rasst.Add(rr);
            }
            foreach (People p in people)
            {
                Console.WriteLine(p.X + " " + p.Y + " " + p.ability);
            }
           // var result = from user in rasst orderby user.r, user.num, user.ability select user;
            rasst = rasst.OrderBy(x => x.r).ToList();
            Console.WriteLine();
            foreach (Rasst u in rasst)
            {
                final.Add(u);
            }
            Console.WriteLine();
            if (how_many_friends <= n)
            {
                for (int i = 0; i < how_many_friends; i++)
                {
                    if (final[i].ability)
                    {
                        count++;
                    }
                    else
                    {
                        count--;
                    }
                }
                Console.WriteLine();
                foreach (Rasst p in final)
                {
                    Console.WriteLine(p.num + ": " + p.r + ", " + p.ability);
                }
                Console.WriteLine((count > 0) ? "Кредит одобрен." : "Кредит не одобрен.");
            }
            else
            {
                Console.WriteLine("Друзей больше чем данных.");
            }
            Console.ReadLine();
        }
    }
}
