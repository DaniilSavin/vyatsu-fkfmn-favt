<<<<<<< HEAD
﻿using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SERVER
{
    internal class Program
    {

        //static string fileName = "1.txt";
        static Byte[] bytes = new Byte[256];
        static string response = "";
        static async Task Main()
        {
           
            try
            {
                //IPAddress localAddress1 = IPAddress.Parse("192.168.0.1") ;

                IPAddress localAddress = IPAddress.Any;
                
                //localAddress = IPAddress.Parse(Console.ReadLine());
                int localPort = 139;
                //Console.Write(" Input port: ");
                //localPort = int.Parse(Console.ReadLine
                
                var server = new TcpListener(localAddress, localPort);
                server.Start();
                Console.WriteLine(localAddress + " Сервер запущен.");
                Console.WriteLine("Жду подключение.");
                while (true)
                {
                    

                    var client = await server.AcceptTcpClientAsync();
                    Console.WriteLine("Принято соединение от {0}", client.Client.RemoteEndPoint);
                   // _ = Task.Run(() => Serve(client));
                }

            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.ToString());
            }

            
            
        }
        static void ping(string ip)
        {
            try
            {
                Console.WriteLine("ping " + ip);
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                options.DontFragment = true;

                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                PingReply reply = pingSender.Send(ip, timeout, buffer, options);

                if (reply.Status == IPStatus.Success)
                {
                    response += "Address: " + reply.Address.ToString() + "\n";
                    response += "RTT: " + reply.RoundtripTime.ToString() + " ms\n";
                    response += "TTL: " + reply.Options.Ttl.ToString() + "\n";
                }
                else
                {
                    response = reply.Status.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        static async Task Serve(TcpClient client)
        {
            try
            {
                Console.WriteLine("Клиент подключился.");
                Console.WriteLine("Жду запрос от клиента: ");
                //using var _ = client;
                var stream = client.GetStream();
                int i;
                string data = "";
                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Получил от клиента: {0}", data);
                    Console.WriteLine("_________________________________\n");
                    // Process the data sent by the client.
                    ping(data);
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(response);
                    await stream.WriteAsync(msg, 0, msg.Length);
                    Console.WriteLine("_________________________________\n");
                    Console.WriteLine("Отправил клиенту: \n" + response);
                    response = "";
                    Console.WriteLine("_________________________________\n");
                }

                // Shutdown and end connection
                //stream.Close();
                //client.Close();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }
            

        }

    }
}
=======
﻿using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SERVER
{
    internal class Program
    {

        //static string fileName = "1.txt";
        static Byte[] bytes = new Byte[256];
        static string response = "";
        static async Task Main()
        {
           
            try
            {
                //IPAddress localAddress1 = IPAddress.Parse("192.168.0.1") ;

                IPAddress localAddress = IPAddress.Any;
                
                //localAddress = IPAddress.Parse(Console.ReadLine());
                int localPort = 139;
                //Console.Write(" Input port: ");
                //localPort = int.Parse(Console.ReadLine
                
                var server = new TcpListener(localAddress, localPort);
                server.Start();
                Console.WriteLine(localAddress + " Сервер запущен.");
                Console.WriteLine("Жду подключение.");
                while (true)
                {
                    

                    var client = await server.AcceptTcpClientAsync();
                    Console.WriteLine("Принято соединение от {0}", client.Client.RemoteEndPoint);
                   // _ = Task.Run(() => Serve(client));
                }

            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.ToString());
            }

            
            
        }
        static void ping(string ip)
        {
            try
            {
                Console.WriteLine("ping " + ip);
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                options.DontFragment = true;

                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                PingReply reply = pingSender.Send(ip, timeout, buffer, options);

                if (reply.Status == IPStatus.Success)
                {
                    response += "Address: " + reply.Address.ToString() + "\n";
                    response += "RTT: " + reply.RoundtripTime.ToString() + " ms\n";
                    response += "TTL: " + reply.Options.Ttl.ToString() + "\n";
                }
                else
                {
                    response = reply.Status.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        static async Task Serve(TcpClient client)
        {
            try
            {
                Console.WriteLine("Клиент подключился.");
                Console.WriteLine("Жду запрос от клиента: ");
                //using var _ = client;
                var stream = client.GetStream();
                int i;
                string data = "";
                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Получил от клиента: {0}", data);
                    Console.WriteLine("_________________________________\n");
                    // Process the data sent by the client.
                    ping(data);
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(response);
                    await stream.WriteAsync(msg, 0, msg.Length);
                    Console.WriteLine("_________________________________\n");
                    Console.WriteLine("Отправил клиенту: \n" + response);
                    response = "";
                    Console.WriteLine("_________________________________\n");
                }

                // Shutdown and end connection
                //stream.Close();
                //client.Close();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }
            

        }

    }
}
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
