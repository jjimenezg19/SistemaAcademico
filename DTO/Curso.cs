using System;

namespace DTO
{
    public class Curso : BaseClass
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int HorasSemanales { get; set; }
        public int CarreraId { get; set; } 
    }
}