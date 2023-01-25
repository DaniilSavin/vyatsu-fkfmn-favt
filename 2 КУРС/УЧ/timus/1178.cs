using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        public struct Node
        {
            public int x, y, num;
        }

        static void Main(string[] args)
        {
            Queue<Node> city = new Queue<Node>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int x, y;
                string[] input = Console.ReadLine().Split(' ');
                x = int.Parse(input[0]);
                y = int.Parse(input[1]);

                int num = i + 1;
                Node node;
                node.x = x;
                node.y = y;
                node.num = num;
                city.Enqueue(node);
            }

            if (n == 0)
            {
                Console.WriteLine("0");
                Console.ReadKey();
            }

            var query = city.OrderByDescending(node => node.y).ToArray<Node>();
            for (int i = 0; i < n; i += 2)
            {
                Console.WriteLine(query[i].num + " " + query[i + 1].num);
            }
            Console.ReadKey();
        }
    }
}
