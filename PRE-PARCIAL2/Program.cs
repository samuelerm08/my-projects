using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRE_PARCIAL2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] Usuarios = new string[3, 3];
            int[,] matriz = new int[10, 10];
            int f = 0, c = 0;
            int libres = 0, ocupados = 0;
            string user, password;
            user = "";
            password = "";
            int intentos = 3;
            bool validacion = false;
            int opcion = 0;


            for (int i = 0; i < Usuarios.GetLength(0); i++)
            {
                for (int j = 0; j < Usuarios.GetLength(1); j++)
                {
                    switch (i)
                    {
                        case 0:
                            Usuarios[i, 0] = "admin";
                            Usuarios[i, 1] = "admin";
                            break;
                        case 1:
                            Usuarios[i, 0] = "elmaxpc";
                            Usuarios[i, 1] = "12332";
                            break;
                        case 2:
                            Usuarios[i, 0] = "base";
                            Usuarios[i, 1] = "datos";
                            break;
                        default:
                            break;
                    }
                }
            }

            while (intentos != 0 && validacion == false)
            {
                Console.WriteLine("Ingrese su nombre de usuario: ");
                user = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Ingrese su clave: ");
                password = Console.ReadLine();
                Console.Clear();

                validacion = Validacion(user, password, Usuarios, validacion);
                if (validacion)
                {
                    Console.WriteLine($"Bienvenido de nuevo! {user}");
                    validacion = true;
                    
                }
                else
                {
                    Console.WriteLine("Usuario y/o contraseña incorrectos vuelva a intentarlo");
                    validacion = false;
                    intentos--;
                    Console.WriteLine($"Intentos restantes {intentos}");
                    
                }

            }
            if (intentos == 0)
            {
                Console.WriteLine("Usted ha consumido todos los intentos. Sesion bloqueada\nVuelva a intentarlo mas tarde");

            }
            Console.ReadKey();
            Console.Clear();
            while (opcion != 4)
            {

                Console.WriteLine("--Sistema de Reservas--");
                Console.WriteLine("--1- Reservar Asiento--");
                Console.WriteLine("--2- Cancelar Reserva--");
                Console.WriteLine("--3- Ver Asientos Disponibles--");
                Console.WriteLine("--4- Salir--");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        RellenarMatriz(f, c, matriz);
                        Console.Clear();
                        break;
                    case 2:
                        VaciarMatriz(f, c, matriz);
                        Console.Clear();
                        break;
                    case 3:
                        MatrizVacia(matriz, libres, ocupados);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("Gracias por usar nuestros servicios");
                        break;
                    default:
                        Console.WriteLine("Opcion Invalida");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            Console.ReadKey();


        }
        static bool Validacion(string user, string password, string[,] Usuarios, bool validacion)
        {
            for (int i = 0; i < Usuarios.GetLength(0); i++)
            {
                for (int j = 0; j < Usuarios.GetLength(1); j++)
                {
                    if (user == Usuarios[i, 0] && password == Usuarios[i, 1])
                    {
                        validacion = true;
                    }

                }
            }
            return validacion;
        }
        static int MatrizVacia(int[,] matriz, int libres, int ocupados)
        {
            libres = 0;
            ocupados = 0;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"|{matriz[i, j]}");

                    if (matriz[i, j] == 0)
                    {
                        libres++;
                    }
                    if (matriz[i, j] == 1)
                    {
                        ocupados++;
                    }
                }
                Console.WriteLine("|");
            }
            Console.WriteLine($"Asientos Libres : {libres}");
            Console.WriteLine($"Asientos Ocupados : {ocupados}");
            return 0;
        }
        static int RellenarMatriz(int f, int c, int[,] matriz)
        {
            Console.WriteLine("Ingrese la fila del asiento:");
            f = Convert.ToInt16(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Ingrese la columna del asiento:");
            c = Convert.ToInt16(Console.ReadLine());
            Console.Clear();

            if (matriz[f - 1, c - 1] == 0)
            {
                matriz[f - 1, c - 1] = 1;
            }
            else
            {
                Console.WriteLine("Fila y/o columna invalida");
            }
            return 0;
        }
        static int VaciarMatriz(int f, int c, int[,] matriz)
        {
            Console.WriteLine("Ingrese la fila del asiento:");
            f = Convert.ToInt16(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Ingrese la columna del asiento:");
            c = Convert.ToInt16(Console.ReadLine());
            Console.Clear();

            if (matriz[f - 1, c - 1] == 1)
            {
                matriz[f - 1, c - 1] = 0;
            }
            else
            {
                Console.WriteLine("Fila y/o columna invalida");
            }
            return 0;
        }
    }
}

