using System.Data;
using DataAccess.Dao;
using DTO;
using MySql.Data.MySqlClient;

namespace DataAccess.Mapper
{
	public class UserMapper : ICrudStatements, IObjectMapper
	{
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

            if (row.ContainsKey("fechaNacimiento") && DateTime.TryParse(row["fechaNacimiento"].ToString(), out DateTime fechaNacimiento))
                user.FechaNacimiento = fechaNacimiento;
            else
                user.FechaNacimiento = default;

            user.UserName = row.ContainsKey("userName") ? row["userName"].ToString() : null;
            user.Contrasena = row.ContainsKey("contrasena") ? row["contrasena"].ToString() : null;
            user.Rol = row.ContainsKey("rol") ? row["rol"].ToString() : null;
            return user;
        }

        public MySqlOperation GetCreateStatement(BaseClass entityDTO, MySqlParameter errorMessage)
        {
            MySqlOperation operation = new MySqlOperation
            {
                ProcedureName = "AgregarUsuario"
            };

            Usuario user = (Usuario)entityDTO;

            operation.AddVarcharParam("p_cedula", user.Cedula);
            operation.AddVarcharParam("p_nombre", user.Nombre);
            operation.AddVarcharParam("p_telefono", user.Telefono);
            operation.AddVarcharParam("p_email", user.Email);
            operation.AddDateTimeParam("p_fechanacimiento", user.FechaNacimiento);
            operation.AddVarcharParam("p_userName", user.UserName);
            operation.AddVarcharParam("p_contrasena", user.Contrasena);
            operation.AddVarcharParam("p_rol", user.Rol);

            //Parametro de salida que recibe la repsuesta del Store Procedure 
            errorMessage.ParameterName = "p_errorMessage";
            errorMessage.Direction = ParameterDirection.Output;
            errorMessage.MySqlDbType = MySqlDbType.VarChar;
            errorMessage.Size = 255;

            operation.parameters.Add(errorMessage);

            return operation;
        }

        public MySqlOperation GetLoginVerification(string username, string password, MySqlParameter outputParam)
        {
            MySqlOperation operation = new MySqlOperation
            {
                ProcedureName = "VerificacionLogin"
            };

            operation.AddVarcharParam("p_username", username);
            operation.AddVarcharParam("p_contrasena", password);

            operation.parameters.Add(outputParam);

            return operation;
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

        public MySqlOperation GetUpdateStatement(BaseClass entityDTO, MySqlParameter errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}

