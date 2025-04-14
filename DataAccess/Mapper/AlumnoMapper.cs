using System.Data;
using DataAccess.Dao;
using DTO;
using MySql.Data.MySqlClient;

namespace DataAccess.Mapper;

public class AlumnoMapper : ICrudStatements, IObjectMapper
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

    public MySqlOperation GetUpdateStatement(BaseClass entityDTO, MySqlParameter errorMessage)
    {
        throw new NotImplementedException();
    }

    public MySqlOperation GetDeleteStatement(BaseClass entityDTO, MySqlParameter errorMessage)
    {
        throw new NotImplementedException();
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
            ProcedureName = "GetAlumnoByName"
        };

        return operation;
    }
}