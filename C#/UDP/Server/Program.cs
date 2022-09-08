using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // B1 : Tao IpEndPoint cua Server
                IPEndPoint s_iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

                // B2 : Tao socket
                Socket serverSokcket = new Socket(SocketType.Dgram, ProtocolType.Udp);


                // B3 : Dang ki sử dụng s_iep cho server bang bind
                serverSokcket.Bind(s_iep);

                // B4 : Gui nhan goi tin voi Client

                while (true) 
                {
                    // B4.1 : Server nhan goi tin tu Client
                    byte[] bReceive = new byte[1024];

                    // Tao IpEndPoint de luu dia chi cua Client
                    EndPoint c_iep = new IPEndPoint(IPAddress.None, 0);
                    Console.WriteLine("Cho nhan goi tin tu Client");

                    int length = serverSokcket.ReceiveFrom(bReceive, ref c_iep);
                    Console.WriteLine("Nhan goi tin tu client : " + c_iep.ToString());
                    string message = ASCIIEncoding.ASCII.GetString(bReceive, 0, length);
                    Console.WriteLine("- Client : " + message);

                    if (message.Contains("exit"))
                    {
                        break;
                    }


                    // B4.2 : Xu ly du lieu
                    Console.Write("Nhap thong diep gui di : ");
                    string send = Console.ReadLine();
                    byte[] bSend = ASCIIEncoding.ASCII.GetBytes(send);

                    // B4.3 : Tra thong diep ve cho server
                    serverSokcket.SendTo(bSend, c_iep);

                    if (send.Contains("exit"))
                    {
                        break;
                    }
                }

                // B5 : Dong ket noi
                Console.WriteLine("Dong ket noi!");
                serverSokcket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex);
            }

            Console.ReadKey();
        }
    }
}
