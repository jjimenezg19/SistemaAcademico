using System;
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
            var user = new Usuario();

            if (row.ContainsKey("user_id") && int.TryParse(row["user_id"].ToString(), out int userId))
                user.Id = userId;

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

        public MySqlOperation GetRegisterUser(BaseClass entityDTO, MySqlParameter errorMessage)
        {
            MySqlOperation operation = new MySqlOperation
            {
                ProcedureName = "AgregarUsuario"
            };

            Usuario user = (Usuario)entityDTO;

            operation.AddIntegerParam("id", user.Id);
            operation.AddVarcharParam("nombre", user.Nombre);
            operation.AddVarcharParam("telefono", user.Telefono);
            operation.AddVarcharParam("email", user.Email);
            operation.AddDateTimeParam("fechanacimiento", user.FechaNacimiento);
            operation.AddVarcharParam("userName", user.UserName);
            operation.AddVarcharParam("contrasena", user.Contrasena);
            operation.AddVarcharParam("role", user.Rol);
          
            operation.parameters.Add(errorMessage);

            return operation;
        }


        public MySqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public MySqlOperation GetDeleteStatement(BaseClass entityDTO)
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

        public MySqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}

