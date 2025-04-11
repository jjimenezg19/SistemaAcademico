using System;
using BL;
using DTO;

namespace UI.View
{
    public class CursoView
    {
        private readonly CursoManager _cursoManager = new CursoManager();

        public void MostrarMenuBusqueda()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("--- BÚSQUEDA DE CURSOS ---");
                Console.WriteLine("1. Buscar por nombre");
                Console.WriteLine("2. Buscar por código");
                Console.WriteLine("3. Buscar por carrera");
                Console.WriteLine("4. Volver al menú principal");
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el nombre del curso: ");
                        string nombre = Console.ReadLine();
                        var cursosNombre = _cursoManager.BuscarCursosPorNombre(nombre);
                        MostrarCursos(cursosNombre);
                        break;

                    case "2":
                        Console.Write("Ingrese el código del curso: ");
                        if (int.TryParse(Console.ReadLine(), out int codigo))
                        {
                            var cursoCodigo = _cursoManager.BuscarCursoPorCodigo(codigo);
                            MostrarCurso(cursoCodigo);
                        }
                        else
                        {
                            Console.WriteLine("⚠️ Código inválido.");
                        }
                        break;

                    case "3":
                        Console.Write("Ingrese el ID de la carrera: ");
                        if (int.TryParse(Console.ReadLine(), out int carreraId))
                        {
                            var cursosCarrera = _cursoManager.BuscarCursosPorCarrera(carreraId);
                            MostrarCursos(cursosCarrera);
                        }
                        else
                        {
                            Console.WriteLine("⚠️ ID inválido.");
                        }
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

        private void MostrarCursos(List<Curso> cursos)
        {
            if (cursos.Count == 0)
            {
                Console.WriteLine("No se encontraron cursos.");
                return;
            }

            foreach (var curso in cursos)
            {
                MostrarCurso(curso);
            }
        }

        private void MostrarCurso(Curso curso)
        {
            Console.WriteLine($"\nCódigo: {curso.Codigo}");
            Console.WriteLine($"Nombre: {curso.Nombre}");
            Console.WriteLine($"Horas semanales: {curso.HorasSemanales}");
            Console.WriteLine($"Carrera ID: {curso.CarreraId}");
        }
    }
}
