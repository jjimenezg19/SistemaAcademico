
namespace DTO
{
    public class RegistroNota
    {
        public int Id { get; set; }
        public Alumno Alumno { get; set; }
        public Grupo Grupo { get; set; }
        public float Nota { get; set; }
    }
}
