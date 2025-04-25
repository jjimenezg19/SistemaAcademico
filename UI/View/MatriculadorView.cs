using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.View;

namespace UI.View
{
    public class MatriculadorView
    {
        private readonly OfertaAcademicaView _ofertaAcademicaView = new OfertaAcademicaView();
        private readonly MatriculaView _matriculaView = new MatriculaView();

        public void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ DE MATRICULADOR ===");
                Console.WriteLine("1. Oferta Académica");
                Console.WriteLine("2. Matrícula");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        _ofertaAcademicaView.MostrarMenu();
                        break;
                    case "2":
                        _matriculaView.MostrarMenu();
                        break;
                    case "3":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
