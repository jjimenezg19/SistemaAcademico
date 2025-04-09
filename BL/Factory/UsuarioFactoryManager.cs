using DTO;

namespace BL.Factory
{
    public class UsuarioFactoryManager
    {
        public static Usuario ConstruirUsuario(string rol, string nombre, string cedula, string email, string username, string contrasena)
        {
            UsuarioCreator creador;

            switch (rol.ToLower())
            {
                case "alumno":
                    creador = new AlumnoCreator();
                    break;
                case "profesor":
                    creador = new ProfesorCreator();
                    break;
                case "administrador":
                    creador = new AdministradorCreator();
                    break;
                default:
                    throw new ArgumentException("Rol no válido");
            }

            Usuario user = creador.CrearUsuario();
            user.Nombre = nombre;
            user.Cedula = cedula;
            user.Email = email;
            user.UserName = username;
            user.Contrasena = contrasena;
            user.Rol = rol;

            return user;
        }
    }
}