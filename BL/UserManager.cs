using DTO;
using DataAccess.CRUD;
using MySql.Data.MySqlClient;
using DataAccess.Dao;

namespace BL
{
	public class UserManager
	{
		public String RegisterUser(Usuario user)
		{
			UserCrudFactory us_crud = new UserCrudFactory();

			return us_crud.Create(user);
		}

		public String Login(string username, string password)
		{
			UserCrudFactory us_crud = new UserCrudFactory();
            string message = us_crud.RetrieveLoginVerification(username, password);

			return message;
        }
	}
}

