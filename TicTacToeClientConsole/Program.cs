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
            leer.Read(buffer: cbuf);
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


            string host = "192.168.1.54";
            int port = 8088;
            //int timeout = 5000;

            using var client = new TcpClient();

            //await client.ConnectAsync(host, port);
            client.Connect(host, port);

            using var netstream = client.GetStream();
            using StreamWriter writer = new StreamWriter(netstream);
            using StreamReader reader = new StreamReader(netstream);
            writer.AutoFlush = true;
            String mensaje = recibirSocket(reader);
            //Recibe el primer mensaje del servidor
            Console.WriteLine(mensaje);




            while (true) {

                /* 
                 *Ingresar nombre de usuario -- ya funciona
                */

                Console.WriteLine();
                String enviar = Console.ReadLine();
                writer.Write(enviar);
                writer.Flush();


                //AQUI RECIBO EL SEGUNDO MENSAJE
                String puntaje = recibirSocket(reader);
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
                fachada.interpretarEstadoPartidaSencillo(recibirSocket(reader));
                Console.WriteLine(fachada.mostrarTablero());
                if (fachada.Ganador != null) {
                    Console.WriteLine("Usted ha" + fachada.Ganador + " esta partida");
                }

                /* 
                Esperando turno    
                */
                Console.WriteLine(recibirSocket(reader));
                String pos = "";
                int movimiento=0;
                Boolean valido = true;
                while (valido)
                {
                    Regex regex = new Regex("(0|1|2|3|4|5|6|7|8)");
                    Console.WriteLine("Ingrese la posicion a marcar");
                    pos = Console.ReadLine();
                    if (regex.IsMatch(pos))
                    {
                        movimiento = int.Parse(pos);
                        valido = false;
                    }
                    else
                    {
                        Console.WriteLine("Valor invalido, intente de nuevo");
                    }
                }

                /*
                 * Envia al server las coordenadas
                 * 
                 */
                writer.Write(movimiento);
                writer.Flush();
                /*
                 * Muestra estado de la partida
                 */
                fachada.interpretarEstadoPartida(recibirSocket(reader));
                Console.WriteLine(fachada.mostrarTablero());
                if (fachada.Ganador != null) {
                    Console.WriteLine("Usted ha " + fachada.Ganador + " esta Partida");
                } else if(!fachada.MovimientoValido){
                    Console.WriteLine("Fue un movimiento invalido, intente de nuevo");
                } 
            }
            

        }
    }
}
