using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ProyectoFinalCsharp
{
    class Program
    {
        static int[,] tablero = new int[3, 3];
        static char[] simbolos = new char[] {' ','O','X'};
        static void Main(string[] args)
        {
            bool terminado = false;

            dibujarTablero();
            Console.WriteLine("Jugador 1=O\njugador 2=X");
            do
            {
                preguntarPosisicon(1);
                dibujarTablero();
                terminado = comprobarGanador();
                if (terminado)
                {
                    Console.WriteLine("El jugador 1 ha gando");
                }
                else
                {
                    terminado = comprobarEmpate();
                    if (terminado)
                    {
                        Console.WriteLine("Esto es un empate");
                    }
                    else
                    {
                        preguntarPosisicon(2);
                        dibujarTablero();

                        terminado = comprobarGanador();

                        if (terminado)
                        {
                            Console.WriteLine("El jugador 2 ha gando");
                        }
                    }

                }
            } while (!terminado);

        }
         static void dibujarTablero()
        {
            int fila = 0;
            int columna = 0;

            Console.WriteLine("");//mode estetico
            Console.WriteLine("---------------");//dibujar la primera linea horizontañ

            for (fila = 0; fila < 3; fila++) { 
                Console.Write("|");
                for (columna = 0; columna < 3; columna++)
                {
                    Console.Write("{0} |", simbolos[tablero[fila,columna]]);
                }
                Console.WriteLine("");
                Console.WriteLine("---------------");
            }
        }

        static void preguntarPosisicon(int jugador)
        {
            int fila, columna;

            do
            {
                Console.WriteLine();
                Console.WriteLine("turno del jugador {0}" ,jugador);

                do
                {
                    Console.Write("seleccion la fila 1 a 3 :");
                    fila = Int32.Parse(Console.ReadLine());
                } while ((fila<1) || (fila>3));
                do
                {
                    Console.Write("seleccion la columna 1 a 3 :");
                    columna = Int32.Parse(Console.ReadLine());
                } while ((columna < 1) || (columna > 3));

                if (tablero[fila-1,columna-1] != 0)
                {
                    Console.WriteLine("casilla oucpada");
                }

            } while (tablero[fila - 1, columna - 1] != 0);
            tablero[fila - 1, columna - 1] = jugador;

        }

        static bool comprobarGanador()
        {
            int fila = 0;
            int columna = 0;
            bool gato = false;
            for (fila = 0; fila < 3; fila++)
            {
                if ((tablero[fila, 0] == tablero[fila, 1]) && (tablero[fila, 0] == tablero[fila, 2]) && ((tablero[fila, 0] != 0)))
                {
                    gato = true;
                }
            }

            for (columna = 0; columna < 3; columna++)
            {
                if ((tablero[0, columna] == tablero[1, columna]) && (tablero[0, columna] == tablero[2, columna]) && ((tablero[0, columna] != 0)))
                {
                    gato = true;
                }
            }

            if ((tablero[0, 0] == tablero[1, 1]) && (tablero[0,0] == tablero[2, 2]) && ((tablero[0,0] != 0)))
                {
                gato = true;
            }
            if ((tablero[0, 2] == tablero[1, 1]) && (tablero[0, 2] == tablero[2, 0]) && ((tablero[0, 2] != 0)))
                {
                gato = true;
            }
            return gato;
        }

        static bool comprobarEmpate()
        {
            int fila = 0;
            int columna = 0;
            bool espacio = false;

            for (fila = 0; fila < 3; fila++)
            {
                for (columna = 0; columna < 3; columna++)
                {
                    if (tablero[fila, columna] == 0)
                    {
                        espacio = true;
                    }
                }
            }

            return !espacio;
        }
    }
}
