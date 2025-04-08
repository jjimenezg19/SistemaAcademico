using DTO;

namespace BL.Factory
{
    public class AlumnoCreator : UsuarioCreator
    {
        public override Usuario CrearUsuario()
        {
            return new Alumno();
        }
    }
}