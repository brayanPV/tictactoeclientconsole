using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace TicTacToeClientConsole
{
    class Program
    {

        private static String recibido = "";
        private static char[] cbuf;
        /**
         * @param args the command line arguments
         */
        public static String recibirSocket(StreamReader leer)
        {
            cbuf = new char[512];
            recibido = "";
            leer.Read(cbuf);
            foreach (char c in cbuf)
            {
                recibido += c;
                if (c == 00)
                {
                    break;
                }
            }
            return recibido;
        }

      
        



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
                NetworkStream net =  new NetworkStream(cliente);
                StreamWriter escribir = new StreamWriter(net);
                StreamReader leer = new StreamReader(net);
                String mensaje = recibirSocket(leer);
                Console.WriteLine(mensaje);
                
           
            

            while (true) {

                /* 
                 *Ingresar nombre de usuario -- Hasta el momento esto no funciona
                */

                Console.WriteLine();
                String enviar = Console.ReadLine();
                escribir.Write(enviar);
                escribir.Flush();


                //AQUI RECIBO EL SEGUNDO MENSAJE
                String puntaje = recibirSocket(leer);
                if (puntaje.Equals("false"))
                {
                    Console.WriteLine("Este usuario ya inicio sesion en otro pc\n" +
                        "Intentelo de nuevo");
                }
                else {
                    Console.WriteLine(puntaje);
                    break;
                }
                
}
            while (true) {
                /*
                 * Retorna estado de la partida 
                */
                fachada.interpretarEstadoPartidaSencillo(recibirSocket(leer));
                Console.WriteLine(fachada.MostrarTablero());
                if (fachada.Ganador != null) {
                    Console.WriteLine("Usted ha" + fachada.Ganador + " esta partida");
                }

                /* 
                Esperando turno    
                */
                Console.WriteLine(recibirSocket(leer));
                Boolean columnaValida = true;
                String columna = "";
                String fila = "";
                String movimiento = "";
                Regex regex = new Regex("(0|1|2)");
                while (columnaValida) {
                    Console.WriteLine("Ingrese el valor de la COLUMNA (0, 1, 2) "
                            + "la cual quiere marcar...");
                    columna = Console.ReadLine();
                    if (regex.IsMatch(columna)) {
                        movimiento += "-" + columna;
                        columnaValida = false;
                    }
                    else {
                        Console.WriteLine("Valor invalido, intente de nuevo");
                    }
                }
                Boolean filaValida = true;
                while (filaValida) {
                    Console.WriteLine("Ingrese el valor de la FILA (0, 1, 2) "
                        + "la cual quiere marcar...");
                    fila = Console.ReadLine();
                    if (regex.IsMatch(fila))
                    {
                        movimiento += "-" + fila;
                        filaValida = false;
                    }
                    else {
                        Console.WriteLine("Valor invalido, intente de nuevo");
                    }
                }
                /*
                 * Envia al server las coordenadas
                 * 
                 */
                escribir.Write(movimiento);
                escribir.Flush();
                /*
                 * Muestra estado de la partida
                 */
                fachada.interpretarEstadoPartida(recibirSocket(leer));
                Console.WriteLine(fachada.MostrarTablero());
                if (fachada.Ganador != null) {
                    Console.WriteLine("Usted ha " + fachada.Ganador + " esta Partida");
                } else if(!fachada.MovimientoValido){
                    Console.WriteLine("Fue un movimiento invalido, intente de nuevo");
                } 
            }
            

        }
    }
}
