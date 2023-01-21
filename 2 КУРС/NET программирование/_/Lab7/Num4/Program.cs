using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Num4
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo fi1 = new FileInfo(@"C:\Users\zagos\source\repos\Num5\Num4\bin\Debug\text.txt");
            if (!fi1.Exists)
            {
                Random rand = new Random();
                StreamWriter sw = fi1.CreateText();
                    for(int i = 0; i < 50; i++ )
                    {
                        int st = rand.Next(-50, 250);
                        sw.WriteLine(st + " ");
                    }
                sw.Close();
            }
            FileStream fileIn = new FileStream("text.txt",
                                    FileMode.Open,
                                    FileAccess.Read);
            byte[] array = new byte[fileIn.Length];
            fileIn.Read(array, 0, array.Length);
            string textFromFile = Encoding.Default.GetString(array);
            //FileStream fileOut = new FileStream("newText.txt",
            //                                     FileMode.Create,
            //                                     FileAccess.Write);
            Console.WriteLine(textFromFile);
            string obSt ="";
            StringBuilder sb = new StringBuilder(textFromFile);
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] != '*' && sb[i] != '\n')
                {
                    obSt += sb[i];
                    char ob = sb[i];
                    for (int j = 0; j < sb.Length; j++)
                    {
                        if (sb[j] == ob)
                        {
                            sb[j] = '*';
                        }
                    }
                }
            }
            Console.WriteLine(sb);
        }
    }
}
