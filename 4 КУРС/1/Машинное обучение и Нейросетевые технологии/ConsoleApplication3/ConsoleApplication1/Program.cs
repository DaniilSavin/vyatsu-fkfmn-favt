using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class Program
    {

        class Animals
        {
            public string name;
            public string otlichie;
            public string whatdoing;
        }

        static List<string> questions = new List<string>() { };
        static List<string> answers = new List<string>() { };

        string path = "";
        static async void ReadFile(string path, List<string> list)
        {
            string line = "";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {

                while ((line = await sr.ReadLineAsync()) != null)
                {
                    list.Add(line);
                }
            }
            
        }

        static async void WriteToFile(string writePath, List<string> list)
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    await sw.WriteLineAsync(list[i]);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, start game..");
            int i = 0; string answer = ""; string tmp = "";
            //WriteToFile("ques.txt", questions);
            //WriteToFile("ans.txt", answers);
            ReadFile("ques.txt", questions);
            ReadFile("ans.txt", answers);
            bool end = false;
            //for (int i=0; i< questions.Length; i++)
            {
                while (!end)
                {
                    if (i < questions.Count)
                    {
                        Console.WriteLine(questions[i]);
                        answer = Console.ReadLine();
                        if (answer.ToLower() == "да")
                        {
                            Console.WriteLine("это " + answers[i]  + "?\n-> ");
                            answer = Console.ReadLine();
                            if (answer.ToLower() == "да")
                            {
                                end = true;
                            }
                            else
                            {
                                if (answer.ToLower() == "нет")
                                {
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    end = true;
                                }
                            }
                            
                        }
                        else
                        {
                            if (answer.ToLower() == "нет")
                            {
                                i++;
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("я не знаю." + "\nЧто оно делает?");
                        Console.Write("оно .. ");
                        tmp = Console.ReadLine();
                        questions.Add("оно "+ tmp.ToLower());
                        Console.WriteLine("кто это?\n-> ");
                        tmp = Console.ReadLine();
                        answers.Add(tmp.ToLower());
                        end = true;
                    }
                }

            }
            Console.WriteLine("END.");
            Console.ReadLine();
        }
    }
}
