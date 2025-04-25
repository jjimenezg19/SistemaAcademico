using BL;
using DTO;
using System;
using System.Collections.Generic;

namespace UI
{
    public class CicloView
    {
        private readonly CicloManager _cicloManager = new CicloManager();

        public void MantenimientoDeCiclos()
        {
            MostrarMenu();
        }

        private void MostrarMenu()
        {
            int opcion = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("==== Mantenimiento de Ciclos ====");
                Console.WriteLine("1. Ver todos los ciclos");
                Console.WriteLine("2. Buscar ciclos por año");
                Console.WriteLine("3. Crear nuevo ciclo");
                Console.WriteLine("4. Actualizar ciclo");
                Console.WriteLine("5. Eliminar ciclo");
                Console.WriteLine("6. Activar un ciclo");
                Console.WriteLine("7. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        VerTodosLosCiclos();
                        break;
                    case 2:
                        BuscarPorAnio();
                        break;
                    case 3:
                        CrearCiclo();
                        break;
                    case 4:
                        ActualizarCiclo();
                        break;
                    case 5:
                        EliminarCiclo();
                        break;
                    case 6:
                        ActivarCiclo();
                        break;
                    case 7:
                        Console.WriteLine("Regresando al menú principal...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 7);
        }

        private void VerTodosLosCiclos()
        {
            var ciclos = _cicloManager.ObtenerTodos();
            Console.WriteLine("\nLista de Ciclos:");
            foreach (var c in ciclos)
            {
                MostrarCiclo(c);
            }
        }

        private void BuscarPorAnio()
        {
            Console.Write("\nIngrese el año a buscar: ");
            if (int.TryParse(Console.ReadLine(), out int anio))
            {
                var ciclos = _cicloManager.BuscarPorAnio(anio);
                if (ciclos.Count == 0)
                {
                    Console.WriteLine("No se encontraron ciclos para ese año.");
                }
                else
                {
                    foreach (var c in ciclos)
                    {
                        MostrarCiclo(c);
                    }
                }
            }
            else
            {
                Console.WriteLine("Año inválido.");
            }
        }

        private void CrearCiclo()
        {
            Console.Write("\nAño del ciclo: ");
            int anio = int.Parse(Console.ReadLine());

            Console.Write("Número del ciclo (1 o 2): ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Fecha de inicio (yyyy-mm-dd): ");
            DateTime fechaInicio = DateTime.Parse(Console.ReadLine());

            Console.Write("Fecha de finalización (yyyy-mm-dd): ");
            DateTime fechaFin = DateTime.Parse(Console.ReadLine());

            Ciclo nuevoCiclo = new Ciclo
            {
                Anio = anio,
                Numero = numero,
                FechaInicio = fechaInicio,
                FechaFinalizacion = fechaFin
            };

            _cicloManager.CrearCiclo(nuevoCiclo);
            Console.WriteLine("✅ Ciclo creado exitosamente.");
        }

        private void ActualizarCiclo()
        {
            Console.Write("\nCódigo del ciclo a actualizar: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Nuevo año: ");
            int anio = int.Parse(Console.ReadLine());

            Console.Write("Nuevo número: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Nueva fecha de inicio (yyyy-mm-dd): ");
            DateTime fechaInicio = DateTime.Parse(Console.ReadLine());

            Console.Write("Nueva fecha de finalización (yyyy-mm-dd): ");
            DateTime fechaFin = DateTime.Parse(Console.ReadLine());

            Ciclo cicloActualizado = new Ciclo
            {
                Anio = anio,
                Numero = numero,
                FechaInicio = fechaInicio,
                FechaFinalizacion = fechaFin
            };

            _cicloManager.ActualizarCiclo(cicloActualizado, codigo);
            Console.WriteLine("✅ Ciclo actualizado exitosamente.");
        }

        private void EliminarCiclo()
        {
            Console.Write("\nCódigo del ciclo a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int codigo))
            {
                _cicloManager.EliminarCiclo(codigo);
                Console.WriteLine("✅ Ciclo eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Código inválido.");
            }
        }

        private void ActivarCiclo()
        {
            Console.Write("\nIngrese el código del ciclo que desea activar: ");
            if (int.TryParse(Console.ReadLine(), out int codigo))
            {
                _cicloManager.ActivarCiclo(codigo);
                Console.WriteLine($"✅ Ciclo {codigo} activado exitosamente.");
            }
            else
            {
                Console.WriteLine("Código inválido.");
            }
        }

        private void MostrarCiclo(Ciclo c)
        {
            Console.WriteLine($"\nCódigo: {c.Codigo}");
            Console.WriteLine($"Año: {c.Anio}");
            Console.WriteLine($"Número: {c.Numero}");
            Console.WriteLine($"Fecha Inicio: {c.FechaInicio:yyyy-MM-dd}");
            Console.WriteLine($"Fecha Fin: {c.FechaFinalizacion:yyyy-MM-dd}");
            Console.WriteLine($"Activo: {(c.Activo ? "Sí" : "No")}");
        }
    }
}
