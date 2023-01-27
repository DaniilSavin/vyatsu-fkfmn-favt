using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace RC4
{
    class Program
    {
        public class RC4
        {

            public byte[] text; //текст для шифрования/расшифрования
            private byte[] S = new byte[256];

            private int i = 0;
            private int j = 0;

            //просто для удобства обмена
            private void swap(byte[] array, int ind1, int ind2)
            {
                byte temp = array[ind1];
                array[ind1] = array[ind2];
                array[ind2] = temp;
            }

            //инициализация, алгоритм ключевого расписания
            public void init(byte[] key)
            {
                for (i = 0; i < 256; i++)
                {
                    S[i] = (byte)i;
                }

                j = 0;
                for (i = 0; i < 256; i++)
                {
                    j = (j + S[i] + key[i % key.Length]) % 256;
                    swap(S, i, j);
                }
                i = j = 0;
            }

            //генератор псевдослучайной последовательности
            public byte kword()
            {
                i = (i + 1) % 256;
                j = (j + S[i]) % 256;
                swap(S, i, j);
                byte K = S[(S[i] + S[j]) % 256];
                return K;
            }

            //функция шифрования/дешифрования
            public byte[] code()
            {
                byte[] data = text.Take(text.Length).ToArray();
                byte[] res = new byte[data.Length];

                for (int i = 0; i < data.Length; i++)
                {
                    res[i] = (byte)(data[i] ^ kword());
                }
                return res;
            }

            //бинарная запись в файл
            public void WriteByteArrayToFile(Byte[] buffer, string fileName)
            {
                try
                {
                    FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
                    BinaryWriter bw = new BinaryWriter(fs);

                    for (int i = 0; i < buffer.Length; i++)
                        bw.Write(buffer[i]);

                    bw.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //бинарное чтение из файла
            public Byte[] ReadByteArrayFromFile(string fileName)
            {
                Byte[] buffer = null;

                try
                {
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);

                    long numBytes = new FileInfo(fileName).Length;
                    buffer = br.ReadBytes((int)numBytes);

                    br.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return buffer;
            }
        }
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            string elapsedTime = "";
            
            TimeSpan ts;
            Console.WriteLine("Выберите действие:");
            Console.WriteLine(" 1. Шифровать");
            Console.WriteLine(" 2. Дешифровать");
            Console.WriteLine(" 3. Выход");
            Console.Write(" \n\n>>> ");

            int menu = int.Parse(Console.ReadLine());

            int key = 0;
           // Console.Write("Введите ключ: ");
            string query = "key";
            string outfile = "";
            int.TryParse(query, out key);
            byte[] bytekey = BitConverter.GetBytes(key);

            Console.Write("Входной файл: ");
            string infile = Console.ReadLine();
            if (menu == 1)
            {
                Console.WriteLine("Результирующий файл: " + infile + ".rc4");
                outfile = infile + ".rc4";
            }
            else
            {
                if (menu==2)
                {
                    string[] s1 = infile.ToCharArray().Select(c => c.ToString()).ToArray();
                    string[] s2= new string[s1.Length];
                    int count = 0; 
                    s2[0] = s1[0];
                    for (int i=1; i<infile.Length; i++)
                    {
                       
                        if (s1[i]==".")
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
                    outfile = String.Concat(s2);
                    Console.WriteLine("Результирующий файл: " + outfile);
                    
                }
            }
           

            var ob = new RC4();
            
            byte[] arr;
                switch (menu)
                {
                    case 1:
                    ob.text = ob.ReadByteArrayFromFile(infile);
                    ob.init(bytekey);
                    stopWatch.Start();
                    arr = ob.code();
                    stopWatch.Stop();
                    ob.WriteByteArrayToFile(arr, outfile);                
                    ts = stopWatch.Elapsed;
                    Console.WriteLine("Сообщение зашифровано!");
                    elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime);
                    break;
                    case 2:
                        ob.text = ob.ReadByteArrayFromFile(infile);
                    
                    ob.init(bytekey);
                    stopWatch.Start();
                    arr = ob.code();
                    stopWatch.Stop();
                    ob.WriteByteArrayToFile(arr, outfile);
                    
                    ts = stopWatch.Elapsed;
                    Console.WriteLine("Сообщение расшифровано!");
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
