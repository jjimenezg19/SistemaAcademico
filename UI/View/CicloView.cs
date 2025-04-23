using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;

namespace UI
{
    public class CicloView
    {
        private CicloDao cicloDao = new CicloDao();

        public void MostrarMenu()
        {
            int opcion = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("==== Mantenimiento de Ciclos ====");
                Console.WriteLine("1. Ver todos los ciclos");
                Console.WriteLine("2. Buscar ciclos por año");
                Console.WriteLine("3. Activar un ciclo");
                Console.WriteLine("0. Volver al menú principal");
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
                        ActivarCiclo();
                        break;
                    case 0:
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

            } while (opcion != 0);
        }

        private void VerTodosLosCiclos()
        {
            var ciclos = cicloDao.ObtenerTodos();
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
                var ciclos = cicloDao.BuscarPorAnio(anio);
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

        private void ActivarCiclo()
        {
            Console.Write("\nIngrese el código del ciclo que desea activar: ");
            if (int.TryParse(Console.ReadLine(), out int codigo))
            {
                cicloDao.ActivarCiclo(codigo);
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
