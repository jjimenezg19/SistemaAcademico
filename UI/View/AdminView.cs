using BL;
using DTO;
using BL.Factory;

namespace UI.View;

public class AdminView
{
    private readonly AlumnoView _alumnoView;
    private readonly ProfesorView _profesorView;
    private readonly CursoView _cursoView;
    private readonly CarreraView _carreraView;
    private readonly CicloView _cicloView;

    public AdminView()
    {
        _alumnoView = new AlumnoView();
        _profesorView = new ProfesorView();
        _cursoView = new CursoView();
        _carreraView = new CarreraView();
        _cicloView = new CicloView();
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
            Console.WriteLine("3. Mantenimiento de cursos.");
            Console.WriteLine("4. Mantenimiento de carreras.");
            Console.WriteLine("5. Mantenimiento de ciclos.");
            Console.WriteLine("6. Volver al menú principal.");
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
                    _cursoView.MantenimientoDeCursos();
                    break;
                case "4":
                    _carreraView.MantenimientoDeCarreras();
                    break;
                case "5":
                    _cicloView.MantenimientoDeCiclos();
                    break;
                case "6":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
