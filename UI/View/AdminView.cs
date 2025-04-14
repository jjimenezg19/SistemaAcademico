using BL;
using DTO;
using BL.Factory;

namespace UI.View;

public class AdminView
{
    private readonly UserManager _userManger;
    private readonly AlumnoManager _alumnoManger;
    
    public AdminView()
    {
        _userManger = new UserManager();
        _alumnoManger = new AlumnoManager();
    }
    
    public void MostrarMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine($"\n");
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
        Console.WriteLine("\n");
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
                //EliminarAlumno();
                break;
            case "4":
                BuscarAlumnoPorNombre();
                break;
            case "5":
                //BuscarAlumnoPorNombre();
                break;
            case "6":
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
        Console.Write("Ingrese el nombre del alumno: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la cedula del alumno: ");
        string cedula = Console.ReadLine();

        Console.Write("Ingrese el teléfono del alumno: ");
        string telefono = Console.ReadLine();

        Console.Write("Ingrese el email del alumno: ");
        string email = Console.ReadLine();

        Console.Write("ingrese la Fecha de nacimiento (yyyy-MM-dd) del alumno: ");
        DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

        Console.Write("Ingrese el username del alumno: ");
        string username = Console.ReadLine();

        Console.Write("Ingrese la contraseña del alumno: ");
        string contrasena = Console.ReadLine();

        string rol = "alumno";

        // Crear usuario con Factory Method
        Usuario nuevoAlumno = UsuarioFactoryManager.ConstruirUsuario(rol, nombre, cedula, email, username, contrasena);
        nuevoAlumno.Telefono = telefono;
        nuevoAlumno.FechaNacimiento = fechaNacimiento;
        
        try
        {
            string resultado = _userManger.RegisterUser(nuevoAlumno);
            Console.WriteLine($"\nResultado: {resultado}");
            
            Console.WriteLine("\n¿Desea realizar algún otra acción en el mantenimiento de alumnos? (s/n)");
            string opcion = Console.ReadLine();
            if (opcion?.ToLower() == "s")
            {
                MantenimientoDeAlumnos();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al registrar: {ex.Message}");
        }
    }
    
    private void MostrarAlumno(Usuario alumno, String message)
    {
        if (alumno == null)
        {
            Console.WriteLine($"Error: {message}");
            return;
        }
        Console.WriteLine($"\nConsulta Exitosa: {message}");
        Console.WriteLine($"\nCódigo: {alumno.Cedula}");
        Console.WriteLine($"Nombre: {alumno.Nombre}");

        Console.WriteLine("\n¿Desea realizar algún otra acción en el mantenimiento de alumnos? (s/n)");
        string opcion = Console.ReadLine();
        if (opcion?.ToLower() == "s")
        {
            MantenimientoDeAlumnos();
        }
    }

    private void ActulizarAlumno()
    {
        Console.WriteLine("\n--- Actulizar Alumno ---");
        Console.Write("Ingrese el Nombre: ");
        string nombre = Console.ReadLine();
    }

    private void BuscarAlumnoPorNombre()
    {
        Console.WriteLine("\n--- Buscar Alumno por Nombre ---");
        Console.Write("Ingrese el Nombre: ");
        string nombre = Console.ReadLine();
        
        var (alumno, message) = _alumnoManger.BuscarPorNombre(nombre);
        MostrarAlumno(alumno, message);
    }
}