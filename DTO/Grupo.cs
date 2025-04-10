using Observer

namespace DTO
{
    public class Grupo : ISubject 
    {
        public int CicloAnio { get; set; }
        public int CicloNumero { get; set; }
        public int CodigoCurso { get; set; }
        public int NumeroDeGrupo { get; set; }
        public DateTime Horario { get; set; }
        public Profesor Profesor { get; set; }
        public Curso Curso { get; set; }
        public List<Alumno> Estudiantes { get; set; } = new List<Alumno>();

        private List<IObserver> observers = new List<IObserver>();

        public void AsignarProfesor(Profesor profesor) => Profesor = profesor;

        public void RegistrarNota(Alumno alumno, float nota)
        {
            RegistroNota registro = new RegistroNota { Alumno = alumno, Grupo = this, Nota = nota };
            alumno.HistorialAcademico.Add(registro);

            string mensaje = $"Se ha registrado una nueva nota en el curso {Curso.Nombre}. Nota: {nota}";
            NotificarObservers(mensaje);
        }

        public void RegistrarObser(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoverObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotificarObservers(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
    }

}
