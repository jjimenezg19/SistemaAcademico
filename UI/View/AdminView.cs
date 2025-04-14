using BL;
using DTO;
using BL.Factory; 
namespace UI.View;

public class AdminView
{
    private readonly UserManager _userManger;
    
    public void MostrarMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("--- Menú del Adminstrador ---");
            Console.WriteLine("1. Mantenimiento de alumnos.");
            Console.WriteLine("2. Mantenimiento de profesores.");
            Console.WriteLine("7. Volver al menú principal.");
            Console.Write("Opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MantenimientoDeAlumnos();
                    break;

                case "2":
                    break;

                case "3":
                    break;

                case "4":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    private void MantenimientoDeAlumnos()
    {
        Console.Clear();
        Console.WriteLine("--- Mantenimiento de alumnos ---");
        Console.WriteLine("1. Registrar alumnos.");
        Console.WriteLine("2. Actualizar alumnos.");
        Console.WriteLine("3. Eliminar alumnos.");
        Console.WriteLine("4. Buscar alumno por nombre.");
        Console.WriteLine("5. Buscar alumno por cedula.");
        Console.WriteLine("6. Buscar alumno por carrera.");
        Console.WriteLine("7. Volver al menú principal.");
        Console.Write("Opción: ");

        var opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                RegistrarAlumno();
                break;

            case "2":
                ActulizarAlumno();
                break;

            case "3":
                
                break;

            case "4":
                return;
                break;

            default:
                Console.WriteLine("Opción no válida.");
                break;
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
    
    private void RegistrarAlumno()
        {
            Console.WriteLine("\n--- Registro de Alumno ---");
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

            string rol = "alumno";
            
            // Crear usuario con Factory Method
            Usuario nuevoAlumno = UsuarioFactoryManager.ConstruirUsuario(rol, nombre, cedula, email, username, contrasena);
            nuevoAlumno.Telefono = telefono;
            nuevoAlumno.FechaNacimiento = fechaNacimiento;
            nuevoAlumno.Rol = rol;

            try
            {
                string resultado = _userManger.RegisterUser(nuevoAlumno);
                Console.WriteLine($"\nResultado: {resultado}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al registrar: {ex.Message}");
            }
        }

    private void ActulizarAlumno()
    {
        Console.WriteLine("\n--- Actulizar Alumno ---");
        Console.Write("Ingrese el Nombre: ");
        string nombre = Console.ReadLine();
    }
    
    private void BuscarAlumnoPorNombre(string nombre)
    {
        Console.WriteLine("\n--- Buscar alumnos por Nombre ---");
        Console.Write("Ingrese el Nombre: ");
        nombre = Console.ReadLine();
        
        
    }
}