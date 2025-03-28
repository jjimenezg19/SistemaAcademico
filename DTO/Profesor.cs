using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DTO
{
    public class Profesor : Usuario
    {
        public void AgregarNota(Alumno alumno, Grupo grupo, float nota)
        {
            grupo.RegistrarNota(alumno, nota);
        }
    }
}
