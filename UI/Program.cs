using System;
using BL;
using DTO;
using BL.Factory;
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

        static void RegistrarUsuario()
        {
            Console.WriteLine("\n--- Registro de Usuario ---");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Fecha de nacimiento (yyyy-MM-dd): ");
            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine();

            Console.Write("Rol: ");
            string rol = Console.ReadLine();

            // Crear el usuario usando el Factory Method
            Usuario nuevoUsuario = UsuarioFactoryManager.ConstruirUsuario(rol, nombre, email, username, contrasena);
            nuevoUsuario.Telefono = telefono;
            nuevoUsuario.FechaNacimiento = fechaNacimiento;

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
