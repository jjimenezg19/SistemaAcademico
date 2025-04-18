using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DTO;

namespace UI.View
{
    public class OfertaAcademicaView
    {
        private readonly OfertaAcademicaManager _manager = new OfertaAcademicaManager();
        private readonly CarreraManager _carreraManager = new CarreraManager();

        public void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("--- OFERTA ACADÉMICA ---");

            Console.WriteLine("Ingrese el ID de la carrera:");
            if (!int.TryParse(Console.ReadLine(), out int carreraId))
            {
                Console.WriteLine("⚠️ ID inválido.");
                return;
            }

            Console.WriteLine("Ingrese el año del ciclo:");
            if (!int.TryParse(Console.ReadLine(), out int anio))
            {
                Console.WriteLine("⚠️ Año inválido.");
                return;
            }

            Console.WriteLine("Ingrese el número del ciclo (1 o 2):");
            if (!int.TryParse(Console.ReadLine(), out int numeroCiclo))
            {
                Console.WriteLine("⚠️ Número de ciclo inválido.");
                return;
            }

            var cursos = _manager.ObtenerCursosPorCarrera(carreraId);
            if (cursos.Count == 0)
            {
                Console.WriteLine("⚠️ No se encontraron cursos para esta carrera.");
                return;
            }

            Console.WriteLine("\n--- Cursos Disponibles ---");
            foreach (var curso in cursos)
            {
                Console.WriteLine($"{curso.Codigo} - {curso.Nombre}");
            }

            Console.WriteLine("Seleccione el código del curso:");
            if (!int.TryParse(Console.ReadLine(), out int codigoCurso))
            {
                Console.WriteLine("⚠️ Código inválido.");
                return;
            }

            var grupos = _manager.ObtenerGruposPorCursoYCiclo(codigoCurso, anio, numeroCiclo);

            Console.WriteLine("\n--- Grupos Programados ---");
            if (grupos.Count == 0)
                Console.WriteLine("No hay grupos programados para este curso.");
            else
                foreach (var grupo in grupos)
                    Console.WriteLine($"Grupo {grupo.NumeroDeGrupo} - Horario: {grupo.Horario}");

            Console.WriteLine("\n¿Desea agregar o modificar un grupo? (a/m/n):");
            string opcion = Console.ReadLine()?.ToLower();

            if (opcion == "a")
            {
                AgregarGrupo(codigoCurso, anio, numeroCiclo);
            }
            else if (opcion == "m")
            {
                ModificarGrupo(codigoCurso, anio, numeroCiclo);
            }
        }

        private void AgregarGrupo(int cursoId, int anio, int numeroCiclo)
        {
            Console.WriteLine("\n--- Agregar Nuevo Grupo ---");
            Console.Write("Número del grupo: ");
            int numeroGrupo = int.Parse(Console.ReadLine());

            Console.Write("Horario (yyyy-MM-dd HH:mm): ");
            DateTime horario = DateTime.Parse(Console.ReadLine());

            Console.Write("ID del profesor: ");
            int profesorId = int.Parse(Console.ReadLine());

            var grupo = new Grupo
            {
                CodigoCurso = cursoId,
                CicloAnio = anio,
                CicloNumero = numeroCiclo,
                NumeroDeGrupo = numeroGrupo,
                Horario = horario,
                Profesor = new Profesor { Id = profesorId }
            };

            try
            {
                _manager.AgregarGrupo(grupo);
                Console.WriteLine("✅ Grupo agregado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al agregar grupo: {ex.Message}");
            }
        }

        private void ModificarGrupo(int cursoId, int anio, int numeroCiclo)
        {
            Console.WriteLine("\n--- Modificar Grupo ---");
            Console.Write("Número del grupo a modificar: ");
            int numeroGrupo = int.Parse(Console.ReadLine());

            Console.Write("Nuevo horario (yyyy-MM-dd HH:mm): ");
            DateTime nuevoHorario = DateTime.Parse(Console.ReadLine());

            Console.Write("Nuevo ID de profesor: ");
            int nuevoProfesorId = int.Parse(Console.ReadLine());

            var grupo = new Grupo
            {
                CodigoCurso = cursoId,
                CicloAnio = anio,
                CicloNumero = numeroCiclo,
                NumeroDeGrupo = numeroGrupo,
                Horario = nuevoHorario,
                Profesor = new Profesor { Id = nuevoProfesorId }
            };

            try
            {
                _manager.ModificarGrupo(grupo);
                Console.WriteLine("✅ Grupo modificado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al modificar grupo: {ex.Message}");
            }
        }
    }
}
