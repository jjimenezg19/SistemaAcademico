
namespace DTO
{
    public class Matricula
    {
        public int Id { get; set; }
        public Alumno Alumno { get; set; }
        public Grupo Grupo { get; set; }
        public float NotaFinal { get; set; }
    }
}
