using DTO;
using DataAccess.CRUD;

namespace BL.Factory;

public class ProfesorManger
{
    private readonly ProfesorCrudFactory _crud ;
    public ProfesorManger()
    {
        _crud = new ProfesorCrudFactory();
    }

    public string ActaulizarProfesor(Usuario usuario)
    {
        return _crud.UpdateProfesor(usuario);
    }

    public string EliminarAlumno(string id)
    {
        return _crud.Delete(id);
    }

    public (Usuario, string) BuscarPorNombre(string nombre)
    {
        return _crud.RetrieveByName(nombre); 
    }
    
    public (Usuario, string) BuscarPorCedula(string cedula)
    {
        return _crud.RetrieveByCedula(cedula); 
    }
}