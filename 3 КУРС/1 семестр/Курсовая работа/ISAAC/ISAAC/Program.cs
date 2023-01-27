using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace ISAAC
{
    class Program
    {
       
        static uint[] randrsl = new uint[256];
        static uint randcnt;
        
        static uint[] mm = new uint[256];
        static uint aa = 0, bb = 0, cc = 0;

        static void isaac()
        {
            uint i, x, y;
            cc++;    
            bb += cc;    

            for (i = 0; i <= 255; i++)
            {
                x = mm[i];
                switch (i & 3)
                {
                    case 0:
                        aa = aa ^ (aa << 13);
                        break;
                    case 1: 
                        aa = aa ^ (aa >> 6);
                        break;
                    case 2:
                        aa = aa ^ (aa << 2);
                        break;
                    case 3: 
                        aa = aa ^ (aa >> 16);
                        break;
                }
                aa = mm[(i + 128) & 255] + aa;
                y = mm[(x >> 2) & 255] + aa + bb;
                mm[i] = y;
                bb = mm[(y >> 10) & 255] + x;
                randrsl[i] = bb;
            }
        }

        // if (flag==TRUE), используем содержимое randrsl[] для инициализации mm[]. 
        static void mix(ref uint a, ref uint b, ref uint c, ref uint d, ref uint e, ref uint f, ref uint g, ref uint h)
        {
            a = a ^ b << 11;
            d += a; b += c;
            b = b ^ c >> 2;
            e += b; c += d;
            c = c ^ d << 8;
            f += c; d += e;
            d = d ^ e >> 16;
            g += d; e += f;
            e = e ^ f << 10;
            h += e; f += g;
            f = f ^ g >> 4;
            a += f; g += h;
            g = g ^ h << 8;
            b += g; h += a;
            h = h ^ a >> 9;
            c += h; a += b;
        }


        static void Init(bool flag)
        {
            short i; uint a, b, c, d, e, f, g, h;

            aa = 0; bb = 0; cc = 0;
            a = 0x9e3779b9; b = a; c = a; d = a;
            e = a; f = a; g = a; h = a;

            for (i = 0; i <= 3; i++)          
                mix(ref a, ref b, ref c, ref d, ref e, ref f, ref g, ref h);

            i = 0;
            do
            { // заполняем mm[]
                if (flag)
                {     // используем всю информацию в seed 
                    a += randrsl[i]; b += randrsl[i + 1]; c += randrsl[i + 2]; d += randrsl[i + 3];
                    e += randrsl[i + 4]; f += randrsl[i + 5]; g += randrsl[i + 6]; h += randrsl[i + 7];
                } 

                mix(ref a, ref b, ref c, ref d, ref e, ref f, ref g, ref h);
                mm[i] = a;
                mm[i + 1] = b;
                mm[i + 2] = c;
                mm[i + 3] = d;
                mm[i + 4] = e;
                mm[i + 5] = f;
                mm[i + 6] = g;
                mm[i + 7] = h;
                i += 8;
            }
            while (i < 255);

            if (flag)
            {
                // Делаем второй проход, чтобы все seed повлияло на все mm
                i = 0;
                do
                {
                    a += mm[i]; b += mm[i + 1]; c += mm[i + 2]; d += mm[i + 3];
                    e += mm[i + 4]; f += mm[i + 5]; g += mm[i + 6]; h += mm[i + 7];
                    mix(ref a, ref b, ref c, ref d, ref e, ref f, ref g, ref h);
                    mm[i] = a; mm[i + 1] = b; mm[i + 2] = c; mm[i + 3] = d;
                    mm[i + 4] = e; mm[i + 5] = f; mm[i + 6] = g; mm[i + 7] = h;
                    i += 8;
                }
                while (i < 255);
            }
            isaac();           // заполняем первый набор результатов
            randcnt = 0;       // используем первый набор результатов 
        }


        // Seed ISAAC with a string
        static void Seed(string seed, bool flag)
        {
            for (int i = 0; i < 256; i++) mm[i] = 0;
            for (int i = 0; i < 256; i++) randrsl[i] = 0;
            int m = seed.Length;
            for (int i = 0; i < m; i++)
            {
                randrsl[i] = seed[i];
            }
            // Инициализация
            Init(flag);
        }


        // Получаем случайное 32-bit значение 
        static uint Random()
        {
            uint result = randrsl[randcnt];
            randcnt++;
            if (randcnt > 255)
            {
                isaac(); randcnt = 0;
            }
            return result;
        }


        // Получаем случайный символ в диапазоне ASCII
        static byte RandA()
        {
            return (byte)(Random() % 95 + 32);
        }


        // XOR шифрование. Вывод: ASCII-байтовый массив
        static byte[] code(string msg)
        {
            int n, l;
            byte[] v = new byte[msg.Length];
            l = msg.Length;
            // XOR message
            for (n = 0; n < l; n++)
            {
                v[n] = (byte)(RandA() ^ (byte)msg[n]);
            }
            return v;
        }

        public static string ReadFromFile(string fileName)
        {
            string textFromFile="";
            try
            {
                FileStream fstream = File.OpenRead(fileName);
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                textFromFile = System.Text.Encoding.Default.GetString(array);
                fstream.Close();            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return textFromFile;

        }

        //бинарная запись в файл
        public static void WriteByteArrayToFile(Byte[] buffer, string fileName)
        {
            try
            {
                 FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
                 BinaryWriter bw = new BinaryWriter(fs);

                 for (int i = 0; i < buffer.Length; i++)
                 {

                     bw.Write(buffer[i]);
                 }

                 bw.Close();
                 fs.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void Main()
        {

            Stopwatch stopWatch = new Stopwatch();
            string elapsedTime="";
            
            TimeSpan ts;
            
            string text, key;
            byte[] encrypt, decrypt;
           
            string fileNameOut="";
            Console.WriteLine("Выберите действие:");
            Console.WriteLine(" 1. Шифровать");
            Console.WriteLine(" 2. Дешифровать");
            Console.WriteLine(" 3. Выход");
            Console.Write(" \n\n>>> ");

            int menu = int.Parse(Console.ReadLine());

            Console.Write("Входной файл: ");
            string fileNameIn = Console.ReadLine();
            if (menu == 1)
            {
                Console.WriteLine("Результирующий файл: " + fileNameIn + ".ic");
                fileNameOut = fileNameIn + ".ic";
            }
            else
            {
                if (menu == 2)
                {
                    string[] s1 = fileNameIn.ToCharArray().Select(c => c.ToString()).ToArray();
                    string[] s2 = new string[s1.Length];
                    int count = 0;
                    s2[0] = s1[0];
                    for (int i = 1; i < fileNameIn.Length; i++)
                    {

                        if (s1[i] == ".")
                        {
                            if (count == 0)
                            {
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        s2[i] = s1[i];

                    }
                    fileNameOut = String.Concat(s2);
                    Console.WriteLine("Результирующий файл: " + fileNameOut);

                }
            }
            switch (menu)
            {
                case 1:
                    
                    text = ReadFromFile(fileNameIn);
                    key = "key";
                    
                    stopWatch.Start();
                    Seed(key, true);
                    // encrypt
                    encrypt = code(text);
                    stopWatch.Stop();
                    ts = stopWatch.Elapsed;
                    WriteByteArrayToFile(encrypt, fileNameOut);
                    Console.WriteLine("Файл зашифрован! " + fileNameOut);
                    elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts.Hours, ts.Minutes, ts.Seconds,
                                ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    break;

                case 2:
                   
                    text = ReadFromFile(fileNameIn);
                    key = "key";
                    // decrypt
                    stopWatch.Start();
                    Seed(key, true);
                    decrypt = code(text);
                    stopWatch.Stop();
                    ts = stopWatch.Elapsed;
                    WriteByteArrayToFile(decrypt, fileNameOut);
                    Console.WriteLine("Файл расшифрован! " + fileNameOut);
                    elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts.Hours, ts.Minutes, ts.Seconds,
                                ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Такого действия нет!");
                    break;
            }
        }
    }
}
