using DTO;
using DataAccess.CRUD;

namespace BL;

public class AlumnoManager
{
    private readonly AlumnoCrudFactory _crud ;
    public AlumnoManager()
    {
        _crud = new AlumnoCrudFactory();
    }

    public string ActaulizarAlumno(Usuario usuario)
    {
        return _crud.UpdateAlumno(usuario);
    }

    public (Usuario, string) BuscarPorNombre(string nombre)
    {
        return _crud.RetrieveByName(nombre); 
    }
    
    public (Usuario, string) BuscarPorCedula(string cedula)
    {
        return _crud.RetrieveByName(cedula); 
    }
    
}