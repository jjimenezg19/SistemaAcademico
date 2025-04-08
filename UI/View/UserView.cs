using System;
using BL;
using DTO;

namespace UI.View
{
	public class UserView
	{
	
        public void RegistrarUsuario()
        {
            Usuario nuevoUsuario = new Usuario();

            Console.WriteLine("\n--- Registro de Usuario ---");
            Console.Write("Nombre: ");
            nuevoUsuario.Nombre = Console.ReadLine();

            Console.Write("Cedula: ");
            nuevoUsuario.Cedula = Console.ReadLine();

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

            Console.WriteLine("Seleccione el rol del usuario:");
            Console.WriteLine("1. Administrador");
            Console.WriteLine("2. Profesor");
            Console.WriteLine("3. Alumno");
            Console.WriteLine("4. Matriculador");
            Console.Write("Opción: ");
            var opcionRol = Console.ReadLine();

            switch (opcionRol)
            {
                case "1":
                    nuevoUsuario.Rol = "Administrador";
                    break;
                case "2":
                    nuevoUsuario.Rol = "Profesor";
                    break;
                case "3":
                    nuevoUsuario.Rol = "Alumno";
                    break;
                case "4":
                    nuevoUsuario.Rol = "Matriculador";
                    break;
                default:
                    Console.WriteLine("Opción no válida. Se asignará 'Alumno' por defecto.");
                    nuevoUsuario.Rol = "Alumno";
                    break;
            }

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

