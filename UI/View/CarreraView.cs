using System;
using DTO;
using BL;

namespace UI.View
{
    public class CarreraView
    {
        private readonly CarreraManager _carreraManager = new CarreraManager();

        public void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("--- MANTENIMIENTO DE CARRERAS ---");
                Console.WriteLine("1. Buscar por nombre");
                Console.WriteLine("2. Buscar por código");
                Console.WriteLine("3. Ver todas");
                Console.WriteLine("4. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el nombre de la carrera: ");
                        string nombre = Console.ReadLine();
                        var carreraPorNombre = _carreraManager.BuscarPorNombre(nombre);
                        MostrarCarrera(carreraPorNombre);
                        break;

                    case "2":
                        Console.Write("Ingrese el código de la carrera: ");
                        if (int.TryParse(Console.ReadLine(), out int codigo))
                        {
                            var carreraPorCodigo = _carreraManager.BuscarPorCodigo(codigo);
                            MostrarCarrera(carreraPorCodigo);
                        }
                        else Console.WriteLine("⚠️ Código inválido.");
                        break;

                    case "3":
                        var carreras = _carreraManager.ObtenerTodas();
                        if (carreras.Count == 0) Console.WriteLine("No hay carreras registradas.");
                        else foreach (var c in carreras) MostrarCarrera(c);
                        break;

                    case "4":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void MostrarCarrera(Carrera carrera)
        {
            if (carrera == null)
            {
                Console.WriteLine("Carrera no encontrada.");
                return;
            }

            Console.WriteLine($"\nCódigo: {carrera.Codigo}");
            Console.WriteLine($"Nombre: {carrera.Nombre}");

            Console.WriteLine("\n¿Desea modificar los cursos de esta carrera? (s/n)");
            string opcion = Console.ReadLine();
            if (opcion?.ToLower() == "s")
            {
                SubmenuCursos(carrera.Codigo);
            }
        }

        private void SubmenuCursos(int carreraId)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== MANTENIMIENTO DE CURSOS DE LA CARRERA ===");
                Console.WriteLine("1. Ver cursos asociados");
                Console.WriteLine("2. Agregar curso");
                Console.WriteLine("3. Quitar curso");
                Console.WriteLine("4. Cambiar orden de un curso");
                Console.WriteLine("5. Volver");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        var cursos = _carreraManager.ObtenerCursosDeCarrera(carreraId);
                        if (cursos.Count == 0)
                            Console.WriteLine("No hay cursos asociados.");
                        else
                            foreach (var c in cursos)
                                Console.WriteLine($"{c.Codigo} - {c.Nombre}");
                        break;

                    case "2":
                        Console.Write("ID del curso a agregar: ");
                        if (int.TryParse(Console.ReadLine(), out int idAgregar))
                            _carreraManager.AgregarCurso(carreraId, idAgregar);
                        else
                            Console.WriteLine("ID inválido.");
                        break;

                    case "3":
                        Console.Write("ID del curso a quitar: ");
                        if (int.TryParse(Console.ReadLine(), out int idQuitar))
                            _carreraManager.QuitarCurso(carreraId, idQuitar);
                        else
                            Console.WriteLine("ID inválido.");
                        break;

                    case "4":
                        Console.Write("ID del curso a modificar orden: ");
                        if (int.TryParse(Console.ReadLine(), out int idCurso))
                        {
                            Console.Write("Nuevo orden: ");
                            if (int.TryParse(Console.ReadLine(), out int nuevoOrden))
                            {
                                _carreraManager.CambiarOrdenCurso(carreraId, idCurso, nuevoOrden);
                                Console.WriteLine("✅ Orden actualizado.");
                            }
                            else
                            {
                                Console.WriteLine("Orden inválido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        break;

                    case "5":
                        volver = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
