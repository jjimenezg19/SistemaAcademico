using System;
using BL;
using DTO;
using BL.Factory; // ← Agregamos esta línea para usar el Factory

namespace UI.View
{
    public class UserView
    {
        public void RegistrarUsuario()
        {
            Console.WriteLine("\n--- Registro de Usuario ---");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Cedula: ");
            string cedula = Console.ReadLine();

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

            Console.WriteLine("Seleccione el rol del usuario:");
            Console.WriteLine("1. Administrador");
            Console.WriteLine("2. Profesor");
            Console.WriteLine("3. Alumno");
            Console.WriteLine("4. Matriculador");
            Console.Write("Opción: ");
            var opcionRol = Console.ReadLine();

            string rol;
            switch (opcionRol)
            {
                case "1":
                    rol = "administrador";
                    break;
                case "2":
                    rol = "profesor";
                    break;
                case "3":
                    rol = "alumno";
                    break;
                case "4":
                    rol = "matriculador";
                    break;
                default:
                    Console.WriteLine("Opción no válida. Se asignará 'alumno' por defecto.");
                    rol = "alumno";
                    break;
            }

            // Crear usuario con Factory Method
            Usuario nuevoUsuario = UsuarioFactoryManager.ConstruirUsuario(rol, nombre, cedula, email, username, contrasena);
            nuevoUsuario.Telefono = telefono;
            nuevoUsuario.FechaNacimiento = fechaNacimiento;
            nuevoUsuario.Rol = rol;

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
