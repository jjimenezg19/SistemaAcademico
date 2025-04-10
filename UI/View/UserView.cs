using System;
using BL;
using DTO;
using BL.Factory; 

namespace UI.View
{
    public class UserView
    {
        private readonly UserManager _userManger;

        public UserView()
        {
            _userManger = new UserManager();
        }

        public void RegistrarUsuario()
        {
            Console.WriteLine("\n--- Registro de Usuario ---");
            Console.Write("Ingrese el Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la Cedula: ");
            string cedula = Console.ReadLine();

            Console.Write("Ingrese el Teléfono: ");
            string telefono = Console.ReadLine();

            Console.Write("Ingrese el Email: ");
            string email = Console.ReadLine();

            Console.Write("ingrese la Fecha de nacimiento (yyyy-MM-dd): ");
            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese el Username: ");
            string username = Console.ReadLine();

            Console.Write("Ingrese la Contraseña: ");
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

            try
            {
                string resultado = _userManger.RegisterUser(nuevoUsuario);
                Console.WriteLine($"\nResultado: {resultado}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al registrar: {ex.Message}");
            }
        }


        public void Login()
        {
            Console.WriteLine("\n--- Inicio de Sescioón ---");

            Console.Write("Ingrese el Username: ");
            string username = Console.ReadLine();

            Console.Write("Ingrese la Contraseña: ");
            string contrasena = Console.ReadLine();

            try
            {
                string resultado = _userManger.Login(username, contrasena);
                Console.WriteLine($"\nResultado: {resultado}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"\nError en el Login: {ex.Message}");
            }
            
        }
    }
}
