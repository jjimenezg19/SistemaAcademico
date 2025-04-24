using System;
using DTO;

namespace UI.View
{
	public class ProfesorNotaView
	{
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
				Console.WriteLine("3. Opción: ");
				
				var opcion = Console.ReadLine();

				switch (opcion)
				{
					case "1":
						break;
					case "2":
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

		public void RegistroNota(Alumno alumno, float nota)
		{
			
		}
		
		
	}
}

