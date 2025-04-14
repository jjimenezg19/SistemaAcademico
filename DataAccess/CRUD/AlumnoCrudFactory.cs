using MySql.Data.MySqlClient;
using DataAccess.Mapper;
using System.Data;
using DataAccess.Dao;
using DTO;

namespace DataAccess.CRUD;

public class AlumnoCrudFactory : CrudFactory
{
    private readonly AlumnoMapper _mapper;
    
    public AlumnoCrudFactory()
    {
        _mapper = new AlumnoMapper();
        dao = MySqlDao.GetInstance();
    }
    
    public override string Create(BaseClass entityDTO)
    {
        throw new NotImplementedException();
    }

    public override void Update(BaseClass entityDTO)
    {
        throw new NotImplementedException();
    }

    public override void Delete(BaseClass entityDTO)
    {
        throw new NotImplementedException();
    }

    public override List<T> RetrieveAll<T>()
    {
        throw new NotImplementedException();
    }

    public override BaseClass RetrieveById(int id)
    {
        throw new NotImplementedException();
    }
    
    public (Usuario, string) RetrieveByName(string name)
    {
        var outputParam = new MySqlParameter("@p_errorMessage", MySqlDbType.VarChar, 255)
        {
            Direction = ParameterDirection.Output
        };
        
        return (null, "no implementado");
    }
}