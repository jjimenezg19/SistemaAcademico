using DTO;
using DataAccess.CRUD;

namespace BL
{
	public class UserManager
	{
		public String RegisterUser(Usuario user)
		{
			UserCrudFactory us_crud = new UserCrudFactory();

			return us_crud.Create(user);
		}
	}
}

