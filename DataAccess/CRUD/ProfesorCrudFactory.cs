using MySql.Data.MySqlClient;
using DataAccess.Mapper;
using System.Data;
using DataAccess.Dao;
using DTO;

namespace DataAccess.CRUD;

public class ProfesorCrudFactory : CrudFactory
{
    private readonly ProfesorMapper _mapper;
    
    public ProfesorCrudFactory()
    {
        _mapper = new ProfesorMapper();
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


    public string UpdateProfesor(BaseClass entityDTO)
    { 
        var outputParam = new MySqlParameter("@p_mensaje", MySqlDbType.VarChar, 255)
        {
            Direction = ParameterDirection.Output
        };
        
       var operation = _mapper.GetUpdateStatement(entityDTO, outputParam);
       var result= dao.ExecuteStoredProcedureWithUniqueResult(operation);
       
       string message = outputParam.Value.ToString();

       if (result == null || result.Count == 0)
        return message;
       
       return message;
    }

    public override void Delete(BaseClass entityDTO)
    {
        throw new NotImplementedException();
    }
    
    public string Delete(string id)
    {
        var outputParam = new MySqlParameter("@p_mensaje", MySqlDbType.VarChar, 255)
        {
            Direction = ParameterDirection.Output
        };
        
        var operation = _mapper.GetDeleteStatement(id, outputParam);
        var result = dao.ExecuteStoredProcedureWithUniqueResult(operation);
        
        string message = outputParam.Value.ToString();
        
        if (result == null || result.Count == 0)
            return message;
        return message;
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
        var outputParam = new MySqlParameter("@p_mensaje", MySqlDbType.VarChar, 255)
        {
            Direction = ParameterDirection.Output
        };
        
        var operation = _mapper.GetRetrieveByNameStatement(name, outputParam);
        var result = dao.ExecuteStoredProcedureWithUniqueResult(operation);
        
        string message = outputParam.Value.ToString();
        
        if (result == null || result.Count == 0)
            return (null, message);
        
        var profesor = (Usuario)_mapper.BuildObject(result);
        return (profesor, message);
    }
    
    public (Usuario, string) RetrieveByCedula(string cedula)
    {
        var outputParam = new MySqlParameter("@p_mensaje", MySqlDbType.VarChar, 255)
        {
            Direction = ParameterDirection.Output
        };
        
        var operation = _mapper.GetRetrieveByCedulaStatement(cedula, outputParam);
        var result = dao.ExecuteStoredProcedureWithUniqueResult(operation);
        
        string message = outputParam.Value.ToString();
        
        if (result == null || result.Count == 0)
            return (null, message);
        
        var profesor = (Usuario)_mapper.BuildObject(result);
        return (profesor, message);
    }
}