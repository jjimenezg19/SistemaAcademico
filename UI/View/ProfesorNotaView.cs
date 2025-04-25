using System;
using BL;
using DTO;

namespace UI.View
{
	public class ProfesorNotaView
	{
		private readonly NotaManager _notaManager;

		public ProfesorNotaView()
		{
			_notaManager = new NotaManager();
		}
			
		public void MostrarMenu()
		{
			bool salir = false;
			while (!salir)
			{
				Console.Clear();
				Console.WriteLine("--- MANTENIMIENTO DE NOTAS ---");
				Console.WriteLine("1. Registrar nota");
				Console.WriteLine("2. Modificar nota");
				Console.WriteLine("3. Volver al menú principal");
				Console.WriteLine("Seleccione una Opción: ");
				
				var opcion = Console.ReadLine();

				switch (opcion)
				{
					case "1":
						RegistrarNotas();
						break;
					case "2":
						RegistrarNotas(); // Por ahora usa el mismo método para registrar/modificar
						break;
					case "3":
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

		public void RegistrarNotas()
		{
			Console.Clear();
			Console.WriteLine("--- REGISTRO DE NOTAS ---");

			Console.Write("Ingrese su cédula: ");
			string cedula = Console.ReadLine();

			var grupos = _notaManager.ObtenerGruposDelProfesor(cedula);

			if (grupos == null || grupos.Count == 0)
			{
				Console.WriteLine("No hay grupos asignados.");
				return;
			}

			Console.WriteLine("\nGrupos asignados:");
			for (int i = 0; i < grupos.Count; i++)
			{
				Console.WriteLine($"{i + 1}. Grupo {grupos[i].Id} - Curso: {grupos[i].NumeroDeGrupo}");
			}

			Console.Write("Seleccione un grupo por número: ");
			if (!int.TryParse(Console.ReadLine(), out int grupoSeleccionado) || grupoSeleccionado < 1 || grupoSeleccionado > grupos.Count)
			{
				Console.WriteLine("Selección inválida.");
				return;
			}

			var grupo = grupos[grupoSeleccionado - 1];
			var estudiantes = _notaManager.ObtenerEstudiantesDelGrupo(grupo.Id);

			foreach (var estudiante in estudiantes)
			{
				Console.WriteLine($"\nEstudiante: {estudiante.Nombre} ({estudiante.Cedula})");
				Console.Write("Ingrese la nota (deje en blanco para omitir): ");
				string input = Console.ReadLine();
				if (float.TryParse(input, out float nota))
				{
					string resultado = _notaManager.RegistrarNota(estudiante.Cedula, grupo.Id, nota);
					Console.WriteLine($"Resultado: {resultado}");
				}
			}
		}
	}
}
