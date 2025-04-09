using System;
using UI.View;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userView = new UserView();

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE USUARIOS ===");
                Console.WriteLine("1. Registrar Usuario");
                Console.WriteLine("2. Salir");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        userView.RegistrarUsuario();
                        break;
                    case "2":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}