using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeClientConsole
{
    class Fachada
    {
        private char[,] tablero;
        private Boolean movimientoValido;
        private Boolean miTurno;
        private String ganador;

        public bool MovimientoValido { get => movimientoValido; set => movimientoValido = value; }
        public bool MiTurno { get => miTurno; set => miTurno = value; }
        public string Ganador { get => ganador; set => ganador = value; }

        public Fachada()
        {
            this.tablero = new char[3, 3];
        }

        public void interpretarEstadoPartidaSencillo(String estado)
        {
            /*
                mensaje[0] -> formato de tablero (X,X,X,O,X,O,O,O,X)
                mensaje[0] -> ultimo movimiento hecho es valido o no (true o  false)
                mensaje[0] -> es mi turno o no (true o  false)
                mensaje[0] -> gano el usuario (perdio: -1, empato: 0, gano: 1)
            */

            String[] mensaje = estado.Split("\n");
            this.armarTablero(mensaje[0]);
            if (mensaje.Length > 1)
            {
                if (mensaje[1].Equals("1"))
                {
                    this.ganador = "GANADO";
                }
                else if (mensaje[1].Equals("0"))
                {
                    this.ganador = "EMPATADO";
                }
                else if (mensaje[1].Equals("-1"))
                {
                    this.ganador = "PERDIDO";
                }
            }
            else
            {
                this.ganador = null;
            }

        }

        public void interpretarEstadoPartida(String estado)
        {
            /*
                mensaje[0] -> formato de tablero (X,X,X,O,X,O,O,O,X)
                mensaje[0] -> ultimo movimiento hecho es valido o no (true o  false)
                mensaje[0] -> es mi turno o no (true o  false)
                mensaje[0] -> gano el usuario (perdio: -1, empato: 0, gano: 1)
            */
            String[] mensaje = estado.Split("\n");
            this.armarTablero(mensaje[0]);
            this.movimientoValido = Boolean.Parse(mensaje[1]);
            this.miTurno = Boolean.Parse(mensaje[2]);
            if (mensaje.Length > 3)
            {
                if (mensaje[3].Equals("1"))
                {
                    this.ganador = "GANADO";
                }
                else if (mensaje[3].Equals("0"))
                {
                    this.ganador = "EMPATADO";
                }
                else if (mensaje[3].Equals("-1"))
                {
                    this.ganador = "PERDIDO";
                }
            }
            else
            {
                this.ganador = null;
            }
        }


        public void armarTablero(String tablero)
        {
            String[] mensaje = tablero.Split(",");
            this.tablero[0, 0] = mensaje[0][0];
            this.tablero[0, 1] = mensaje[1][0];
            this.tablero[0, 2] = mensaje[2][0];
            this.tablero[1, 0] = mensaje[3][0];
            this.tablero[1, 1] = mensaje[4][0];
            this.tablero[1, 2] = mensaje[5][0];
            this.tablero[2, 0] = mensaje[6][0];
            this.tablero[2, 1] = mensaje[7][0];
            this.tablero[2, 2] = mensaje[8][0];
        }

        public String MostrarTablero()
        {
            String cadena = "   0   1   2\n";
            int c = 0;
            char q;
            //aqui jhon tiene char[], pero eso da error

            /*foreach (char[] x in tablero)
             {
                 cadena += c + " ";
                 foreach (char y in x)
                 {
                     if (y==0) {
                         q = ' ';
                     }
                     cadena += "[" + q + "]";
                 }
                 cadena += "\n";
                 c++;
             }*/
            return cadena;
        }

    }
}
