using BL;
using BL.Factory;
using DTO;

namespace UI.View;

public class AlumnoView
{
    private readonly UserManager _userManger;
    private readonly AlumnoManager _alumnoManger;
    
    public AlumnoView()
    {
        _userManger = new UserManager();
        _alumnoManger = new AlumnoManager();
    }
     public void MantenimientoDeAlumnos()
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
        Console.Write("Seleccione una ppción: ");

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
                EliminarAlumno();
                break;
            case "4":
                BuscarAlumnoPorNombre();
                break;
            case "5":
                BuscarAlumnoPorCedula();
                break;
            case "6":
                BuscarAlumnoPorCedula();
                break;
            case "7":
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
        Console.WriteLine($"\nIdentificación: {alumno.Cedula}");
        Console.WriteLine($"Nombre: {alumno.Nombre}");

        Console.WriteLine("\n¿Desea realizar algún otra acción en el mantenimiento de alumnos? (s/n)");
        string opcion = Console.ReadLine();
        if (opcion?.ToLower() == "s")
        {
            MantenimientoDeAlumnos();
        }
    }

    private void EliminarAlumno()
    {
        Console.WriteLine("\n--- Eliminar Alumno ---");
        
        Console.Write("Ingrese la cedula del alumno que desea eliminar: ");
        string cedula = Console.ReadLine();
        
        try
        {
            string resultado = _alumnoManger.EliminarAlumno(cedula);
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
            Console.WriteLine($"\nError al eliminar el alumno: {ex.Message}");
        }
    }
    
    private void ActulizarAlumno()
    {
        Console.WriteLine("\n--- Actulizar Alumno ---");
        
        Console.Write("Ingrese la cedula del alumno que desea actualizar: ");
        string cedula = Console.ReadLine();
        
        Console.Write("Ingrese el nuevo nombre: ");
        string nombre = Console.ReadLine();
        
        Console.Write("Ingrese el nuevo username: ");
        string userName = Console.ReadLine();
        
        Console.Write("Ingrese la nueva contraseña: ");
        string contrasena = Console.ReadLine();
        
        Console.Write("Ingrese el nuevo telefono: ");
        string telefono = Console.ReadLine();
        
        Console.Write("Ingrese el nuevo email: ");
        string email = Console.ReadLine();

        Usuario nuevoAlumno = UsuarioFactoryManager.ConstruirUsuario("alumno", nombre, cedula, email, userName, contrasena);
        nuevoAlumno.Telefono = telefono;
        
        try
        {
            string resultado = _alumnoManger.ActaulizarAlumno(nuevoAlumno);
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
            Console.WriteLine($"\nError al actualizar el alumno: {ex.Message}");
        }
    }

    private void BuscarAlumnoPorNombre()
    {
        Console.WriteLine("\n--- Buscar Alumno por Nombre ---");
        Console.Write("Ingrese el Nombre: ");
        string nombre = Console.ReadLine();
        
        var (alumno, message) = _alumnoManger.BuscarPorNombre(nombre);
        MostrarAlumno(alumno, message);
    }
    
    private void BuscarAlumnoPorCedula()
    {
        Console.WriteLine("\n--- Buscar Alumno por Cedula ---");
        Console.Write("Ingrese la cedula del alumno: ");
        string cedula = Console.ReadLine();
        
        var (alumno, message) = _alumnoManger.BuscarPorCedula(cedula);
        MostrarAlumno(alumno, message);
    }
    
    private void BuscarAlumnoPorCarrera()
    {
        Console.WriteLine("\n--- Buscar Alumno por Cedula ---");
        Console.Write("Ingrese la cedula del alumno: ");
        string cedula = Console.ReadLine();
        
        var (alumno, message) = _alumnoManger.BuscarPorCedula(cedula);
        MostrarAlumno(alumno, message);
    }
    
}