using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeClientConsole
{
    class Fachada
    {
        private char[] tablero;
        private Boolean movimientoValido;
        private Boolean miTurno;
        private String ganador;

        public bool MovimientoValido { get => movimientoValido; set => movimientoValido = value; }
        public bool MiTurno { get => miTurno; set => miTurno = value; }
        public string Ganador { get => ganador; set => ganador = value; }

        public Fachada()
        {
            this.tablero = new char[9];
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
            this.tablero[0] = mensaje[0][0];
            this.tablero[1] = mensaje[1][0];
            this.tablero[2] = mensaje[2][0];
            this.tablero[3] = mensaje[3][0];
            this.tablero[4] = mensaje[4][0];
            this.tablero[5] = mensaje[5][0];
            this.tablero[6] = mensaje[6][0];
            this.tablero[7] = mensaje[7][0];
            this.tablero[8] = mensaje[8][0];
        }

        /*public String MostrarTablero()
        {
            String cadena = "   0   1   2\n";
            char[] aux = new char[9];
            char msg=' ';
            
            // int c = 0;
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                cadena += i + " ";
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    for (int k = 0; k < aux.Length; k++)
                    {
                        aux[k] = tablero[i, j];
                        if (aux[k] == 0)
                        {
                            msg = ' ';
                        }
                        else
                        {
                            msg = aux[k];
                        }
                    }
                    cadena += "[" + msg + "]";
                }
                cadena += "\n";
                //  c++;

            }

            return cadena;
        }*/

        public String mostrarTablero()
        {
            String cadena = "   0   1   2\n";
            int cont = 0;

            cadena += cont + "";
            for (int i = 0; i < tablero.Length; i++)
            {

                if (tablero[i] == 0)
                {
                    tablero[i] = ' ';
                }
                cadena += "[ " + tablero[i] + " ]";
                if (i == 2 || i == 5)
                {
                    cont++;
                    cadena += "\n" + cont;
                }
            }

            return cadena;
        }

    }
}
