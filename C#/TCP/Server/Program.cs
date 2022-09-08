using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                //B1 : Khoi tao IpEndPoint
                IPEndPoint s_iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

                //B2 : Tao socket
                Socket serverSokcket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //B3 : Dang ki s_iep cho server socket thong qua bind
                serverSokcket.Bind(s_iep);

                //B4 : Cho ket noi
                Console.WriteLine("Cho ket noi");
                serverSokcket.Listen(10);
                Socket clientSocket = serverSokcket.Accept();
                Console.WriteLine("Co 1 ket noi : " + clientSocket.RemoteEndPoint.ToString());

                //B5 : Gui nhan thong diep

                while (true)
                {
                    //B5.1 : Nhan thong diep
                    byte[] bReceive = new byte[1024];
                    int length = clientSocket.Receive(bReceive);
                    string message = ASCIIEncoding.ASCII.GetString(bReceive, 0, length);
                    Console.WriteLine(" - Client : " + message);

                    if (message.Contains("exit"))
                    {
                        break;
                    }

                    //B5.2 : Gui thong diep
                    Console.Write("Nhap thong diep gui di : ");
                    string send = Console.ReadLine();
                    byte[] bSend = ASCIIEncoding.ASCII.GetBytes(send);
                    clientSocket.Send(bSend);

                    if (send.Contains("exit"))
                    {
                        break;
                    }
                }

                //B6 : Dong ket noi
                Console.WriteLine("Dong ket noi!");
                clientSocket.Close();
                serverSokcket.Close();
            } catch (Exception e) 
            {
                Console.WriteLine("Loi : " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
