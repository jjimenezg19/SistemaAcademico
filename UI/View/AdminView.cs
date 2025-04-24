using BL;
using DTO;
using BL.Factory;

namespace UI.View;

public class AdminView
{
    private readonly AlumnoView _alumnoView;
    private readonly ProfesorView _profesorView;
    
    public AdminView()
    {
        _alumnoView = new AlumnoView();
        _profesorView = new ProfesorView();
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
            Console.WriteLine("3. Volver al menú principal.");
            Console.Write("\nSeleccione una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    _alumnoView.MantenimientoDeAlumnos();
                    break;

                case "2":
                    _profesorView.MantenimientoDeProfesores();
                    break;

                case "3":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}