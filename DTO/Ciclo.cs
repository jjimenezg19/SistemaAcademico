namespace DTO
{
    public class Ciclo
    {
        public int Codigo { get; set; } // Nuevo
        public int Anio { get; set; }
        public int Numero { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public bool Activo { get; set; } // Nuevo
    }
}