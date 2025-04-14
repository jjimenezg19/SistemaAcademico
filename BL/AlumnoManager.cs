using DataAccess.CRUD;

namespace BL;

public class AlumnoManager
{
    private readonly AlumnoCrudFactory al_crud ;
    public AlumnoManager()
    {
        al_crud = new AlumnoCrudFactory();
    }
    
    
    
}