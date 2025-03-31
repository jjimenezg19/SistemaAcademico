using System;
using DataAccess.Dao;
using DTO;

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

            if (row.ContainsKey("role_id") && int.TryParse(row["role_id"].ToString(), out int userId))
                user.Id = userId;

            if (row.ContainsKey("role_id") && int.TryParse(row["role_id"]))

           

            return null;
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

