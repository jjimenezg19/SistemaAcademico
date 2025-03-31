
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
