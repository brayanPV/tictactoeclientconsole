using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TicTacToeClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Fachada fachada = new Fachada();
            
                // Establish the remote endpoint for the socket.  
                // This example uses port 11000 on the local computer. 
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 8090);

                // Create a TCP/IP  socket.  
                Socket cliente = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
                cliente.Connect(remoteEP);
            String enviar;
                byte[] b = new byte[1024];
                int k = cliente.Receive(b);
                string szReceived = System.Text.Encoding.ASCII.GetString(b, 0, k);
            NetworkStream net =  new NetworkStream(cliente);
            BinaryWriter o = new BinaryWriter(net);    

            Console.WriteLine(szReceived);
            Console.ReadLine();

            while (true) {

                /* 
                 *Ingresar nombre de usuario 
                 */
                Console.WriteLine();
                enviar = Console.ReadLine();

                b = System.Text.Encoding.Default.GetBytes(enviar);
                cliente.Send(b);
                Console.ReadLine();

            }


            


            

        }
    }
}
