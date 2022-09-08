using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //B1 : Xac dinh IpEndPoint
                IPEndPoint s_iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

                //B2 : Khoi tao socket
                Socket clientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);

                //B3 : Ket noi voi server
                clientSocket.Connect(s_iep);
                Console.WriteLine("Ket noi thanh cong");

                //B4 : Gui nhan thong diep
                while (true)
                {
                    //B4.1 : Gui thong diep
                    Console.Write("Nhap thong diep gui di : ");
                    string send = Console.ReadLine();
                    byte[] bSend = ASCIIEncoding.ASCII.GetBytes(send);
                    clientSocket.Send(bSend);

                    if (send.Contains("exit"))
                    {
                        break;
                    }

                    //B4.2 : Nhan thong diep
                    byte[] bReceive = new byte[1024];
                    int length = clientSocket.Receive(bReceive);
                    string message = ASCIIEncoding.ASCII.GetString(bReceive, 0, length);
                    Console.WriteLine("- Server : " + message);

                    if (message.Contains("exit"))
                    {
                        break;
                    }
                }

                //B5 : Dong ket noi
                Console.WriteLine("Dong ket noi!");
                clientSocket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
