using System;
using System.Net.Sockets;

namespace TicTacToeClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            Char[,] arr = new Char[3, 3];
            arr[0, 0] = 'X';
            arr[0, 1] = '\0';
            arr[0, 2] = 'O';

            arr[1, 0] = 'O';
            arr[1, 1] = 'X';
            arr[1, 2] = 'X';

            arr[2, 0] = '\0';
            arr[2, 1] = '\0';
            arr[2, 2] = 'O';

            String cadena = "   0   1   2\n";
            char[] aux = new char[9];
            char msg = ' ';

            // int c = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                cadena += i + " ";
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < aux.Length; k++)
                    {
                        aux[k] = arr[i, j];
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
            Console.WriteLine(cadena);
            Console.ReadLine();
        }
    }
}
