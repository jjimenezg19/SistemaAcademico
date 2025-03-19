using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaDisenno
{
    public class Carrera
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public List<Curso> Cursos { get; set; } = new List<Curso>();

        public void AgregarCurso(Curso curso) => Cursos.Add(curso);
        public void EliminarCurso(Curso curso) => Cursos.Remove(curso);
    }
}
