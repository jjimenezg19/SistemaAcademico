using DTO;

namespace BL.Factory
{
    public class UsuarioFactoryManager
    {
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
            user.Email = email;
            user.UserName = username;
            user.Contrasena = contrasena;
            user.Rol = rol;

            return user;
        }
    }
}