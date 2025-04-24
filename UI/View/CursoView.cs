using System;
using System.Collections.Generic;
using BL;
using DTO;

namespace UI.View
{
    public class CursoView
    {
        private readonly CursoManager _cursoManager = new CursoManager();

        public void MantenimientoDeCursos()
        {
            MostrarMenu();
        }

        private void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("--- MANTENIMIENTO DE CURSOS ---");
                Console.WriteLine("1. Buscar por nombre");
                Console.WriteLine("2. Buscar por código");
                Console.WriteLine("3. Buscar por carrera");
                Console.WriteLine("4. Crear nuevo curso");
                Console.WriteLine("5. Actualizar curso");
                Console.WriteLine("6. Eliminar curso");
                Console.WriteLine("7. Volver al menú principal");
                Console.Write("Opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        BuscarPorNombre();
                        break;
                    case "2":
                        BuscarPorCodigo();
                        break;
                    case "3":
                        BuscarPorCarrera();
                        break;
                    case "4":
                        CrearCurso();
                        break;
                    case "5":
                        ActualizarCurso();
                        break;
                    case "6":
                        EliminarCurso();
                        break;
                    case "7":
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

        private void BuscarPorNombre()
        {
            Console.Write("Ingrese el nombre del curso: ");
            string nombre = Console.ReadLine();
            var cursos = _cursoManager.BuscarCursosPorNombre(nombre);
            MostrarCursos(cursos);
        }

        private void BuscarPorCodigo()
        {
            Console.Write("Ingrese el código del curso: ");
            if (int.TryParse(Console.ReadLine(), out int codigo))
            {
                var curso = _cursoManager.BuscarCursoPorCodigo(codigo);
                MostrarCurso(curso);
            }
            else Console.WriteLine("⚠️ Código inválido.");
        }

        private void BuscarPorCarrera()
        {
            Console.Write("Ingrese el ID de la carrera: ");
            if (int.TryParse(Console.ReadLine(), out int carreraId))
            {
                var cursos = _cursoManager.BuscarCursosPorCarrera(carreraId);
                MostrarCursos(cursos);
            }
            else Console.WriteLine("⚠️ ID inválido.");
        }

        private void CrearCurso()
        {
            Console.Write("Nombre del curso: ");
            string nombre = Console.ReadLine();

            Console.Write("Horas semanales: ");
            int horas = int.Parse(Console.ReadLine());

            Console.Write("ID de la carrera: ");
            int carreraId = int.Parse(Console.ReadLine());

            Curso nuevo = new Curso
            {
                Nombre = nombre,
                HorasSemanales = horas,
                CarreraId = carreraId
            };

            _cursoManager.CrearCurso(nuevo);
            Console.WriteLine("✅ Curso creado correctamente.");
        }

        private void ActualizarCurso()
        {
            Console.Write("Código del curso a actualizar: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Nuevo nombre del curso: ");
            string nombre = Console.ReadLine();

            Console.Write("Nuevas horas semanales: ");
            int horas = int.Parse(Console.ReadLine());

            Console.Write("Nuevo ID de la carrera: ");
            int carreraId = int.Parse(Console.ReadLine());

            Curso actualizado = new Curso
            {
                Codigo = codigo,
                Nombre = nombre,
                HorasSemanales = horas,
                CarreraId = carreraId
            };

            _cursoManager.ActualizarCurso(actualizado);
            Console.WriteLine("✅ Curso actualizado correctamente.");
        }

        private void EliminarCurso()
        {
            Console.Write("Código del curso a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int codigo))
            {
                _cursoManager.EliminarCurso(codigo);
                Console.WriteLine("✅ Curso eliminado correctamente.");
            }
            else Console.WriteLine("Código inválido.");
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
            if (curso == null)
            {
                Console.WriteLine("Curso no encontrado.");
                return;
            }

            Console.WriteLine($"\nCódigo: {curso.Codigo}");
            Console.WriteLine($"Nombre: {curso.Nombre}");
            Console.WriteLine($"Horas semanales: {curso.HorasSemanales}");
            Console.WriteLine($"Carrera ID: {curso.CarreraId}");
        }
    }
}
