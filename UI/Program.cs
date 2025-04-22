using System;
using UI.View;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userView = new UserView();
            var ofertaView = new OfertaAcademicaView();
            var matriculaView = new MatriculaView();

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema Académico ===");
                Console.WriteLine("1. Registrar Usuario");
                Console.WriteLine("2. Iniciar Sesión");
                Console.WriteLine("3. Oferta Académica");
                Console.WriteLine("4. Matrícula");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        userView.RegistrarUsuario();
                        break;
                    case "2":
                        userView.Login();
                        break;
                    case "3":
                        ofertaView.MostrarMenu();
                        break;
                    case "4":
                        matriculaView.MostrarMenu();
                        break;
                    case "5":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}