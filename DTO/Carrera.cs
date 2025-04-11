using System.Collections.Generic;

namespace DTO
{
    public class Carrera : BaseClass
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public List<Curso> Cursos { get; set; } = new List<Curso>();

        public void AgregarCurso(Curso curso) => Cursos.Add(curso);
        public void EliminarCurso(Curso curso) => Cursos.Remove(curso);
    }
}