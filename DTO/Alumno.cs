using Observer;

namespace DTO
{
    public class Alumno : Usuario, IObserver
    {
        public List<RegistroNota> HistorialAcademico { get; set; } = new List<RegistroNota>();

        public void ConsultarHistorialAcademico()
        {
            foreach (var registro in HistorialAcademico)
            {
                Console.WriteLine($"Curso: {registro.Grupo.Curso.Nombre}, Nota: {registro.Nota}");
            }
        }

        public void Update(string mensaje)
        {
            Console.WriteLine($"[Notificación para {Nombre}]: {mensaje}");
        }
    }
}