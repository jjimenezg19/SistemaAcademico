using DataAccess.Mapper;
using DataAccess.Dao;
using DTO;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.CRUD
{
	public class UserCrudFactory : CrudFactory
	{
		private readonly UserMapper _mapper; 

		public UserCrudFactory()
		{
			_mapper = new UserMapper();
			dao = MySqlDao.GetInstance();
		}

        public override String Create(BaseClass entityDTO)
        {
            var errorMessage = new MySqlParameter("@errorMessage", MySqlDbType.VarChar, 255)
            {
                ParameterName = "p_errorMessage",
                MySqlDbType = MySqlDbType.VarChar,
                Size = 255,
                Direction = ParameterDirection.Output
            };

            MySqlOperation operation = _mapper.GetRegisterUser(entityDTO, errorMessage);
            dao.ExecuteStoredProcedure(operation);

            string error = errorMessage.Value?.ToString();
            return error;
        }

        public (Usuario, string) RetrieveLoginVerification(string username, string password)
        {
            var outputParam = new MySqlParameter("@p_errorMessage", MySqlDbType.VarChar, 255)
            {
                Direction = ParameterDirection.Output
            };
                
            var operation = _mapper.GetLoginVerification(username, password, outputParam);
            var result = dao.ExecuteStoredProcedureWithUniqueResult(operation);

            string message = outputParam.Value?.ToString();
            
            if (result == null || result.Count == 0)
                return (null, message); 
            
            var user = (Usuario)_mapper.BuildObject(result);
            return (user, message);
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

        public override void Update(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}

