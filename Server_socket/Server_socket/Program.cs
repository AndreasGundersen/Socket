using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server_socket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ipadress of the server (this case its the localhost)
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            
            //Create a listener on the server
            TcpListener server = new TcpListener(ip, 8080);

            //Create empty client
            TcpClient client = default(TcpClient);

            //Start the server/listener
            try
            {
                server.Start();
                Console.WriteLine("Server started...");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }

            while (true)
            {
                //Accept client 
                client = server.AcceptTcpClient();

                //Empty buffer
                byte[] recievedBuffer = new byte[100];

                //Get stream from the client
                NetworkStream stream = client.GetStream();

                //Read the stream into the empty buffer
                stream.Read(recievedBuffer, 0, recievedBuffer.Length);

                //Convert buffer into a string 
                StringBuilder msg = new StringBuilder();

                foreach (var b in recievedBuffer)
                {
                    if (b.Equals(00))
                    {
                        break;
                    }
                    else
                    {
                        msg.Append(Convert.ToChar(b).ToString());
                    }
                }

                Console.WriteLine(msg.ToString() + msg.Length);
               

            }

        }
    }
}
