using System;
using System.Collections.Generic;
using System.IO;

/*7.4.	Создайте программным образом файл input.txt и заполните его 50 целыми числами, 
 * полученными с помощью генератора случайных чисел из диапазона [–150…250]. 
 * Напишите программу, выводящую на экран и в файл output.txt числа из файла input.txt, исключив повторные вхождения.*/


namespace zadanie_4_1
{
    class Program
    {
        const int SIZE= 50;
        public static string ReadFromFileByte(string fileName)
        {
            using (FileStream fstream = File.OpenRead(fileName))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine("Текст из файла: ");
                Console.WriteLine($"{textFromFile}");
                return textFromFile;
            }
        }

        public static void WriteInFileByte(string fileName, string text)
        {
            using (FileStream fstream = new FileStream(fileName, FileMode.Create))
            {
                
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }
        }

        public static List<int> Repetitions(List <int> arr)
        {
            List<int> tmp = new List<int>() ;
            bool fl= true;
            for (int i=0; i<arr.Count; i++)
            {
                fl = true;
                for (int j=i+1; j<arr.Count && fl; j++)
                {
                    if (arr[i]==arr[j])
                    {
                        fl = false;
                    }
                }
                if (fl)
                {
                    tmp.Add(arr[i]);
                }
            }
            return tmp;
        }



        static void Main(string[] args)
        {
            string fileNameIn = "Input.txt";
            string fileNameOut = "Output.txt";
            Random rand = new Random();
            string text = "";
            //text = "250 245 230 245 115 250";
            for (int i=0; i< SIZE; i++)
            {
                text += rand.Next(150, 250+1).ToString();
                if (i < SIZE-1)
                {
                    text += " ";
                }
            }
            WriteInFileByte(fileNameIn, text);
            text=ReadFromFileByte(fileNameIn);
            string[] numAr = text.Split(' ');
            List<int> array = new List<int>();
            int size = numAr.Length;
            for (int i=0; i< numAr.Length; i++)
            {
                
                    array.Add(int.Parse(numAr[i]));
                
            }
            
            List <int> array1 = Repetitions(array);
            array.Clear();
            text = null;
            for (int i = 0; i < array1.Count; i++)
            {
                text += array1[i].ToString();
                if (i < array1.Count - 1)
                {
                    text += " ";
                }
            }
            WriteInFileByte(fileNameOut, text);
        }
    }
}
