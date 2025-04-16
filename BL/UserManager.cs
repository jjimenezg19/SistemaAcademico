using DTO;
using DataAccess.CRUD;
using MySql.Data.MySqlClient;
using DataAccess.Dao;

namespace BL
{
	public class UserManager
	{
		private readonly UserCrudFactory us_crud;
		public UserManager()
		{
			us_crud = new UserCrudFactory();
		}
		
		public String RegisterUser(Usuario user)
		{
			return us_crud.Create(user);
		}
		public (Usuario, string) Login(string username, string password)
		{
			return us_crud.RetrieveLoginVerification(username, password);
        }
	}
}

