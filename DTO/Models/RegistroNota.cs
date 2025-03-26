using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaDisenno
{
    public class RegistroNota
    {
        public int Id { get; set; }
        public Alumno Alumno { get; set; }
        public Grupo Grupo { get; set; }
        public float Nota { get; set; }
    }
}
