using System;
using BL;
using DTO;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                        RegistrarUsuario();
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

        static void RegistrarUsuario()
        {
            Usuario nuevoUsuario = new Usuario();

            Console.WriteLine("\n--- Registro de Usuario ---");
            Console.Write("Nombre: ");
            nuevoUsuario.Nombre = Console.ReadLine();

            Console.Write("Teléfono: ");
            nuevoUsuario.Telefono = Console.ReadLine();

            Console.Write("Email: ");
            nuevoUsuario.Email = Console.ReadLine();

            Console.Write("Fecha de nacimiento (yyyy-MM-dd): ");
            nuevoUsuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Username: ");
            nuevoUsuario.UserName = Console.ReadLine();

            Console.Write("Contraseña: ");
            nuevoUsuario.Contrasena = Console.ReadLine();

            Console.Write("Rol: ");
            nuevoUsuario.Rol = Console.ReadLine();

            var userManager = new UserManager();

            try
            {
                string resultado = userManager.RegisterUser(nuevoUsuario);
                Console.WriteLine($"\nResultado: {resultado}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al registrar: {ex.Message}");
            }
        }
    }
}