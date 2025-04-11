using System;
using UI.View;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userView = new UserView();
            var cursoView = new CursoView();
            var carreraView = new CarreraView(); // nueva instancia

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE USUARIOS ===");
                Console.WriteLine("1. Registrar Usuario");
                Console.WriteLine("2. Iniciar Sesioón");
                Console.WriteLine("3. Mantenimiento de Cursos");
                Console.WriteLine("4. Mantenimiento de Carreras");
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
                        cursoView.MostrarMenuBusqueda();
                        break;
                    case "4":
                        carreraView.MostrarMenu();
                        break;
                    case "5":
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