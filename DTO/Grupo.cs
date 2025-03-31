
namespace DTO
{
    public class Grupo
    {
        public int CicloAnio { get; set; }
        public int CicloNumero { get; set; }
        public int CodigoCurso { get; set; }
        public int NumeroDeGrupo { get; set; }
        public DateTime Horario { get; set; }
        public Profesor Profesor { get; set; }
        public List<Alumno> Estudiantes { get; set; } = new List<Alumno>();

        public void AsignarProfesor(Profesor profesor) => Profesor = profesor;
        public void RegistrarNota(Alumno alumno, float nota)
        {
            RegistroNota registro = new RegistroNota { Alumno = alumno, Grupo = this, Nota = nota };
            alumno.HistorialAcademico.Add(registro);
        }
    }

}
