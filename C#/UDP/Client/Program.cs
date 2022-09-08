using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // B1 : Xac dinh IpEndPoint cua Server
                IPEndPoint s_iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

                // B2 : Tao socket
                Socket clientSokcket = new Socket(SocketType.Dgram, ProtocolType.Udp);

                // B3 : Gui nhan goi tin voi Socket

                
                while (true)
                {
                    // B3.1 : Tao goi tin
                    Console.Write("Nhap thong diep gui di : ");
                    string send = Console.ReadLine();
                    byte[] bSend = ASCIIEncoding.ASCII.GetBytes(send);
                    clientSokcket.SendTo(bSend, s_iep);
                    Console.WriteLine("Goi tin da duoc gui di");

                    if (send.Contains("exit"))
                    {
                        break;
                    }

                    // B3.2 : Nhan goi tin tu server
                    byte[] bReceive = new byte[1024];
                    EndPoint iep = new IPEndPoint(IPAddress.None, 0);
                    int length = clientSokcket.ReceiveFrom(bReceive, ref iep);
                    string message = ASCIIEncoding.ASCII.GetString(bReceive, 0, length);
                    Console.WriteLine("- Server : " + message);

                    if (message.Contains("exit"))
                    {
                        break;
                    }
                }


                // B4 : Dong ket noi
                Console.WriteLine("Dong ket noi!");
                clientSokcket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex);
            }

            Console.ReadKey();
        }
    }
}
