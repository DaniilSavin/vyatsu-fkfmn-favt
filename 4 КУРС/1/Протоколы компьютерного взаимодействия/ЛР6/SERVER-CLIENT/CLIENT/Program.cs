using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CLIENT
{
    internal class Program
    {
        //static IPAddress serverAddress = IPAddress.Parse("127.0.0.1");
        static IPAddress serverAddress = IPAddress.Parse("192.168.0.199");
        const int serverPort = 139;
        
        
        static string IP = "8.8.8.8";
        static Byte[] bytes = new Byte[256];
        static async Task Main()
        {
            try
            {
                while (true)
                {
                    Console.Write("Input IP: ");

                    IP = Console.ReadLine();

                    if (IP != "" && IP != "-1")
                    {
                        Console.WriteLine("_________________________________\n");
                        TcpClient client = new TcpClient(serverAddress.ToString(), serverPort);
                        NetworkStream stream = client.GetStream();
                        Console.WriteLine("Отправил на сервер ip - " + IP);
                        byte[] data = System.Text.Encoding.UTF8.GetBytes(IP);
                        await stream.WriteAsync(data, 0, data.Length);
                        StringBuilder response = new StringBuilder();
                        do
                        {
                            int bytes = stream.Read(data, 0, data.Length);
                            response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                        }
                        while (stream.DataAvailable); // пока данные есть в потоке
                        Console.WriteLine("_________________________________\n");
                        Console.WriteLine("Данные об IP: \n" + response.ToString());

                        // Закрываем потоки
                        Console.WriteLine("_________________________________\n");
                        stream.Close();
                        client.Close();

                    }
                    else
                    {
                        Console.WriteLine("Stop.");
                        break;
                    }
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }
    }


}
