using DTO;

namespace BL.Factory
{
    public class ProfesorCreator : UsuarioCreator
    {
        public override Usuario CrearUsuario()
        {
            return new Profesor();
        }
    }
}