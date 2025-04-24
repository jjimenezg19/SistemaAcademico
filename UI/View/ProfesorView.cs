using BL;
using BL.Factory;
using DTO;

namespace UI.View;

public class ProfesorView
{
     private readonly UserManager _userManger;
    private readonly ProfesorManger _profesorManger;
    
    public ProfesorView()
    {
        _userManger = new UserManager();
        _profesorManger = new ProfesorManger();
    }
     public void MantenimientoDeProfesores()
    {
        Console.Clear();
        Console.WriteLine("\n");
        Console.WriteLine("--- Mantenimiento de profesores ---");
        Console.WriteLine("1. Registrar profesor.");
        Console.WriteLine("2. Actualizar profesor.");
        Console.WriteLine("3. Eliminar profesor.");
        Console.WriteLine("4. Buscar profesor por nombre.");
        Console.WriteLine("5. Buscar profesor por cedula.");
        Console.WriteLine("6. Volver al menú principal.");
        Console.Write("Seleccione una ppción: ");

        var opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                RegistrarProfesor();
                break;

            case "2":
                ActulizarProfesor();
                break;

            case "3":
                EliminarProfesor();
                break;
            case "4":
                BuscarProfesorPorNombre();
                break;
            case "5":
                BuscarProfesorPorCedula();
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
    
    private void RegistrarProfesor()
    {
        Console.WriteLine("\n--- Registro de Profesor ---");
        Console.Write("Ingrese el nombre del profesor: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la cedula del profesor: ");
        string cedula = Console.ReadLine();

        Console.Write("Ingrese el teléfono del profesor: ");
        string telefono = Console.ReadLine();

        Console.Write("Ingrese el email del profesor: ");
        string email = Console.ReadLine();

        Console.Write("ingrese la Fecha de nacimiento (yyyy-MM-dd) del profesor: ");
        DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

        Console.Write("Ingrese el username del profesor: ");
        string username = Console.ReadLine();

        Console.Write("Ingrese la contraseña del profesor: ");
        string contrasena = Console.ReadLine();

        string rol = "Profesor";

        // Crear usuario con Factory Method
        Usuario nuevoProfesor = UsuarioFactoryManager.ConstruirUsuario(rol, nombre, cedula, email, username, contrasena);
        nuevoProfesor.Telefono = telefono;
        nuevoProfesor.FechaNacimiento = fechaNacimiento;
        
        try
        {
            string resultado = _userManger.RegisterUser(nuevoProfesor);
            Console.WriteLine($"\nResultado: {resultado}");
            
            Console.WriteLine("\n¿Desea realizar algún otra acción en el mantenimiento de alumnos? (s/n)");
            string opcion = Console.ReadLine();
            if (opcion?.ToLower() == "s")
            {
                MantenimientoDeProfesores();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al registrar: {ex.Message}");
        }
    }
    
    private void MostrarProfesor(Usuario profesor, String message)
    {
        if (profesor == null)
        {
            Console.WriteLine($"Error: {message}");
            return;
        }
        Console.WriteLine($"\nConsulta Exitosa: {message}");
        Console.WriteLine($"\nIdentificación: {profesor.Cedula}");
        Console.WriteLine($"Nombre: {profesor.Nombre}");

        Console.WriteLine("\n¿Desea realizar algún otra acción en el mantenimiento de profesores? (s/n)");
        string opcion = Console.ReadLine();
        if (opcion?.ToLower() == "s")
        {
            MantenimientoDeProfesores();
        }
    }

    private void EliminarProfesor()
    {
        Console.WriteLine("\n--- Eliminar Profesor ---");
        
        Console.Write("Ingrese la cedula del profesor que desea eliminar: ");
        string cedula = Console.ReadLine();
        
        try
        {
            string resultado = _profesorManger.EliminarAlumno(cedula);
            Console.WriteLine($"\nResultado: {resultado}");
            
            Console.WriteLine("\n¿Desea realizar algún otra acción en el mantenimiento de profesores? (s/n)");
            string opcion = Console.ReadLine();
            if (opcion?.ToLower() == "s")
            {
                MantenimientoDeProfesores();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al eliminar el alumno: {ex.Message}");
        }
    }
    
    private void ActulizarProfesor()
    {
        Console.WriteLine("\n--- Actulizar Profesor ---");
        
        Console.Write("Ingrese la cedula del Profesor que desea actualizar: ");
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

        Usuario nuevoProfesor = UsuarioFactoryManager.ConstruirUsuario("Profesor", nombre, cedula, email, userName, contrasena);
        nuevoProfesor.Telefono = telefono;
        
        try
        {
            string resultado = _profesorManger.ActaulizarProfesor(nuevoProfesor);
            Console.WriteLine($"\nResultado: {resultado}");
            
            Console.WriteLine("\n¿Desea realizar algún otra acción en el mantenimiento de Profesores? (s/n)");
            string opcion = Console.ReadLine();
            if (opcion?.ToLower() == "s")
            {
                MantenimientoDeProfesores();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al actualizar el Profesor: {ex.Message}");
        }
    }

    private void BuscarProfesorPorNombre()
    {
        Console.WriteLine("\n--- Buscar Profesor por Nombre ---");
        Console.Write("Ingrese el nombre del profesor: ");
        string nombre = Console.ReadLine();
        
        var (alumno, message) = _profesorManger.BuscarPorNombre(nombre);
        MostrarProfesor(alumno, message);
    }
    
    private void BuscarProfesorPorCedula()
    {
        Console.WriteLine("\n--- Buscar Profesor por Cedula ---");
        Console.Write("Ingrese la cedula del Profesor: ");
        string cedula = Console.ReadLine();
        
        var (alumno, message) = _profesorManger.BuscarPorCedula(cedula);
        MostrarProfesor(alumno, message);
    }
}