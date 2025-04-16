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

    public (Usuario, string) BuscarPorNombre(string nombre)
    {
        return _crud.RetrieveByName(nombre); 
    }
    
}