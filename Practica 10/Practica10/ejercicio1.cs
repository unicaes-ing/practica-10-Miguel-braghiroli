using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Miguel Braghiroli 22/10/2019
namespace Practica10
{
    class ejercicio1
    {
        static void Main(string[] args)
        {
            int menu;
            do
            {
                Console.Clear();
                Console.Write("====MENU====" +
                    "\n1-Agregar pais" +
                    "\n2-Mostrar pais" +
                    "\n3-Buscar pais" +
                    "\n4-Salir" +
                    "\n\n Ingrese su opcion: ");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        AP();
                        break;
                    case 2:
                        MP();
                        break;
                    case 3:
                        BP();
                        break;
                    case 4:
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("La opcion que elijio es incorrecta");
                        Console.ReadLine();
                        break;
                }
            } while (menu != 4);
        }
        public static void AP()
        {
            StreamWriter ArchPais = new StreamWriter("Paises_Agregados.txt", true);
            string AgrPais;
            Console.Clear();
            Console.WriteLine("(Agregar pais)");
            do
            {
                Console.Write("Paises que desea agregar(Ingrese 0 para salir): ");
                AgrPais = Console.ReadLine();
                if (AgrPais == "0")
                {
                    Console.WriteLine("\n\n\n\nCerrando...");
                    Thread.Sleep(300);
                    break;
                }
                if (AgrPais == "")
                {
                    Console.WriteLine("Dato invalido");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    ArchPais.WriteLine(AgrPais);
                }
            } while (AgrPais != "0");
            ArchPais.Close();
        }
        public static void MP()
        {
            string AllPais;
            StreamReader MostrarPais = new StreamReader("Paises_Agregados.txt");
            Console.Clear();
            Console.WriteLine("Lista de países agregados actualmente: ");
            AllPais = MostrarPais.ReadToEnd();
            Console.Write(AllPais);
            Console.Write("\n\nPresione ENTER para salir");
            Console.ReadLine();
            MostrarPais.Close();
        }
        public static void BP()
        {
            string registro, Bpais;
            bool encontrado = false;
            Console.Clear();
            StreamReader BusPais = new StreamReader("Paises_Agregados.txt");
            Console.Write("Ingrese el pais que desea buscar: ");
            Bpais = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            do
            {
                registro = BusPais.ReadLine();
                if (Bpais.Equals(registro))
                {
                    Console.Write("\nPaís encontrado exitosamente");
                    Console.ReadLine();
                    encontrado = true;
                    break;
                }
            } while (registro != null);
            if (encontrado == false)
            {
                Console.WriteLine("\n\nNo se encontro el pais en la base de datos: ");
                Console.Write("sin embargo puedes agregarlo desde el menu principal");
                Console.ReadLine();
            }
            BusPais.Close();
        } 
    }
}
