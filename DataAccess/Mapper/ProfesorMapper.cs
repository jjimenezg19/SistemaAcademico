using DataAccess.Dao;
using DTO;
using MySql.Data.MySqlClient;

namespace DataAccess.Mapper;

public class ProfesorMapper : ICrudStatements, IObjectMapper
{
    public BaseClass BuildObject(Dictionary<string, object> row)
    {
        if (row == null)
            return null;

        var user = new Usuario();

        if (row.ContainsKey("user_id") && int.TryParse(row["user_id"].ToString(), out int userId))
            user.Id = userId;

        user.Cedula = row.ContainsKey("cedula") ? row["cedula"].ToString() : null;
        user.Nombre = row.ContainsKey("nombre") ? row["nombre"].ToString() : null;
        user.Telefono = row.ContainsKey("telefono") ? row["telefono"].ToString() : null;
        user.Email = row.ContainsKey("email") ? row["email"].ToString() : null;

        if (row.ContainsKey("fechaNacimiento") &&
            DateTime.TryParse(row["fechaNacimiento"].ToString(), out DateTime fechaNacimiento))
            user.FechaNacimiento = fechaNacimiento;
        else
            user.FechaNacimiento = default;

        user.UserName = row.ContainsKey("userName") ? row["userName"].ToString() : null;
        user.Contrasena = row.ContainsKey("contrasena") ? row["contrasena"].ToString() : null;
        user.Rol = row.ContainsKey("rol") ? row["rol"].ToString() : null;
        return user;
    }

    public List<BaseClass> BuildObjects(List<Dictionary<string, object>> objectRows)
    {
        List<BaseClass> users = new List<BaseClass>();

        foreach (var row in objectRows)
        {
            var user = BuildObject(row);
            users.Add(user);
        }

        return users;
    }

    public MySqlOperation GetCreateStatement(BaseClass entityDTO, MySqlParameter errorMessage )
    {
        throw new NotImplementedException();
    }

    public MySqlOperation GetUpdateStatement(BaseClass entityDTO, MySqlParameter outputParam)
    {
        var profesor = (Usuario) entityDTO;
        
        var operation = new MySqlOperation()
        {
            ProcedureName = "ActualizarUsuario"
        };
        
        operation.AddVarcharParam("p_cedula", profesor.Cedula);
        operation.AddVarcharParam("p_userName", profesor.UserName);
        operation.AddVarcharParam("p_contrasena", profesor.Contrasena);
        operation.AddVarcharParam("p_rol", profesor.Rol);
        operation.AddVarcharParam("p_nombre", profesor.Nombre);
        operation.AddVarcharParam("p_telefono", profesor.Telefono);
        operation.AddVarcharParam("p_email", profesor.Email);
        operation.AddDateTimeParam("p_fechaNacimiento", profesor.FechaNacimiento);
        operation.Parameters.Add(outputParam);
        
        return operation;
    }

    public MySqlOperation GetDeleteStatement(BaseClass entityDTO, MySqlParameter errorMessage)
    {
        throw new NotImplementedException();
    }

    public MySqlOperation GetDeleteStatement(string id, MySqlParameter outputParam)
    {
        MySqlOperation operation = new MySqlOperation()
        {
            ProcedureName = "EliminarUsuario"
        };
        
        operation.AddVarcharParam("p_cedula", id);
        operation.Parameters.Add(outputParam);
        return operation;
    }

    public MySqlOperation GetRetrieveAllStatement()
    {
        throw new NotImplementedException();
    }

    public MySqlOperation GetRetrieveByIdStatement(int Id)
    {
        throw new NotImplementedException();
    }

    public MySqlOperation GetRetrieveByNameStatement(string name, MySqlParameter outputParam)
    {
        MySqlOperation operation = new MySqlOperation()
        {
            ProcedureName = "ObtenerUsuarioPorNombre"
        };
        
        operation.AddVarcharParam("p_nombre", name);
        operation.Parameters.Add(outputParam);
        return operation;
    }
    
    public MySqlOperation GetRetrieveByCedulaStatement(string cedula, MySqlParameter outputParam)
    {
        MySqlOperation operation = new MySqlOperation()
        {
            ProcedureName = "ObtenerUsuarioPorCedula"
        };
        
        operation.AddVarcharParam("p_cedula", cedula);
        operation.Parameters.Add(outputParam);
        return operation;
    }
}