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


    public string UpdateAlumno(BaseClass entityDTO)
    { 
        var outputParam = new MySqlParameter("@p_mensaje", MySqlDbType.VarChar, 255)
        {
            Direction = ParameterDirection.Output
        };
        
       var operation = _mapper.GetUpdateStatement(entityDTO, outputParam);
       var result= dao.ExecuteStoredProcedureWithUniqueResult(operation);
       
       string message = outputParam.Value.ToString();

       if (result == null || result.Count == 0)
        return null;
       
       return (string)message;
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
        var outputParam = new MySqlParameter("@p_mensaje", MySqlDbType.VarChar, 255)
        {
            Direction = ParameterDirection.Output
        };
        
        var operation = _mapper.GetRetrieveByNameStatement(name, outputParam);
        var result = dao.ExecuteStoredProcedureWithUniqueResult(operation);
        
        string message = outputParam.Value.ToString();
        
        if (result == null || result.Count == 0)
            return (null, message);
        
        var alumno = (Usuario)_mapper.BuildObject(result);
        return (alumno, message);
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
        
        var alumno = (Usuario)_mapper.BuildObject(result);
        return (alumno, message);
    }
}