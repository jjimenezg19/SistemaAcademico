using DTO;

namespace BL.Factory
{
    public class MatriculadorCreator : UsuarioCreator
    {
        public override Usuario CrearUsuario()
        {
            return new Matriculador();
        }
    }
}