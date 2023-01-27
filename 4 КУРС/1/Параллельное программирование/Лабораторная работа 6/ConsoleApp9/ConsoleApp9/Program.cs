using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static private void thread()
        {
            while (true)
            {
                Math.Pow(double.MaxValue, double.MaxValue);
            }
        }
        static void Main(string[] args)
        {
            string miner = "miner";
            string bitcoin = "bitcoin";
            string etherium = "etherium";
            WebRequest request = WebRequest.Create("https://pool.binance.com/ru%22");
            List < Thread > threads = new List<Thread>();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads.Add(new Thread(thread));
                threads[threads.Count - 1].Start();
            }
        }
    }
}