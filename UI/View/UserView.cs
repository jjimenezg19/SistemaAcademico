using System;
using BL;
using DTO;

namespace UI.View
{
	public class UserView
	{
        public void RegistrarUsuario()
        {
            Console.WriteLine("\n--- Registro de Usuario ---");
            Console.Write("Nombre: ");

            Console.Write("Cedula: ");

            Console.Write("Teléfono: ");

            Console.Write("Email: ");

            Console.Write("Fecha de nacimiento (yyyy-MM-dd): ");

            Console.Write("Username: ");

            Console.Write("Contraseña: ");

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
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                default:
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
