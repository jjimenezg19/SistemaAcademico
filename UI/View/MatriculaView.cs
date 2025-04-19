using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BL;
using DTO;

namespace UI.View
{
    public class MatriculaView
    {
        private readonly MatriculaManager _manager = new MatriculaManager();

        public void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("--- MATRÍCULA DE ESTUDIANTE ---");

            Console.Write("Ingrese la cédula del alumno: ");
            string cedula = Console.ReadLine();

            Console.Write("Ingrese el año del ciclo: ");
            int anio = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el número del ciclo (1 o 2): ");
            int numeroCiclo = int.Parse(Console.ReadLine());

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine($"--- Matrícula de {cedula} para {anio}-{numeroCiclo} ---");
                var grupos = _manager.ObtenerGruposMatriculados(cedula, anio, numeroCiclo);

                if (grupos.Count == 0)
                {
                    Console.WriteLine("No hay grupos matriculados.");
                }
                else
                {
                    Console.WriteLine("Grupos matriculados:");
                    foreach (var g in grupos)
                    {
                        Console.WriteLine($"Curso: {g.CodigoCurso}, Grupo: {g.NumeroDeGrupo}, Horario: {g.Horario}");
                    }
                }

                Console.WriteLine("\n1. Agregar matrícula");
                Console.WriteLine("2. Eliminar matrícula");
                Console.WriteLine("3. Cambiar ciclo");
                Console.WriteLine("4. Volver");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarMatricula(cedula, anio, numeroCiclo);
                        break;
                    case "2":
                        EliminarMatricula(cedula, anio, numeroCiclo);
                        break;
                    case "3":
                        Console.Write("Nuevo año: ");
                        anio = int.Parse(Console.ReadLine());

                        Console.Write("Nuevo número de ciclo (1 o 2): ");
                        numeroCiclo = int.Parse(Console.ReadLine());
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void AgregarMatricula(string cedula, int anio, int numeroCiclo)
        {
            Console.Write("Código del curso: ");
            int codigoCurso = int.Parse(Console.ReadLine());

            Console.Write("Número del grupo: ");
            int numeroGrupo = int.Parse(Console.ReadLine());

            try
            {
                _manager.AgregarMatricula(cedula, codigoCurso, numeroGrupo, anio, numeroCiclo);
                Console.WriteLine("✅ Matrícula agregada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }

        private void EliminarMatricula(string cedula, int anio, int numeroCiclo)
        {
            Console.Write("Código del curso a eliminar: ");
            int codigoCurso = int.Parse(Console.ReadLine());

            Console.Write("Número del grupo: ");
            int numeroGrupo = int.Parse(Console.ReadLine());

            try
            {
                _manager.EliminarMatricula(cedula, codigoCurso, numeroGrupo, anio, numeroCiclo);
                Console.WriteLine("✅ Matrícula eliminada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }
    }
}

