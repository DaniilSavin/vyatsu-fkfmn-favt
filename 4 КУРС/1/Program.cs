	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;

	namespace _2
	{
		class Program
		{

			public static readonly string inputFileName = "arrays.txt";
			public static readonly string outputFileName = "sums.txt";
			public static Queue input = new Queue();
			public static Queue output = new Queue();
			private static Mutex inputMutex = new Mutex();
			private static Mutex outputMutex = new Mutex();
			private static bool exitFlag = false;

			public static void SecondThread()
			{
				while (!exitFlag)
				{
					if (input.Count != 0 && inputMutex.WaitOne())
					{
						int[] array = (int[])input.Dequeue();
						inputMutex.ReleaseMutex();
						int sum = 0;
						for (int i = 0; i < array.Length; i++)
						{
							sum += array[i];
						}
						//Thread.Sleep(1000);
						Console.WriteLine(sum);
						while (!outputMutex.WaitOne()) { Console.WriteLine("waiting mutex"); };
						output.Enqueue(sum);
						outputMutex.ReleaseMutex();
					}
				}
			}
			static void Main(string[] args)
			{
				Thread thread = new Thread(new ThreadStart(SecondThread));
				thread.Start();
				string line;
				StreamReader file = new StreamReader(inputFileName);
				int linesToRead = int.Parse(file.ReadLine());
				int writedLines = 0;
				while ((line = file.ReadLine()) != null || writedLines != linesToRead)
				{
					if (line == null)
					{
						Console.WriteLine("all lines readed");
					}
					if (line != null && inputMutex.WaitOne())
					{
						//Console.WriteLine(line);
						int[] array = Array.ConvertAll(line.Split(' ').ToArray(), s => int.Parse(s));
						input.Enqueue(array);
						inputMutex.ReleaseMutex();
					}
					if (output.Count != 0 && outputMutex.WaitOne())
					{
						using (StreamWriter streamWriter = File.AppendText(outputFileName))
						{
							streamWriter.WriteLine(((int)output.Dequeue()).ToString());
						}
						outputMutex.ReleaseMutex();
						writedLines++;
					}
				}
				exitFlag = true;
				file.Close();
				Console.WriteLine("file closed");
				Console.ReadLine();
			}
		}
	}
