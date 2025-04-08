using DTO;

namespace BL.Factory
{
    public class AdministradorCreator : UsuarioCreator
    {
        public override Usuario CrearUsuario()
        {
            return new Administrador();
        }
    }
}