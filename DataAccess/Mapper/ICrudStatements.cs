using DataAccess.Dao;
using DTO;
using MySql.Data.MySqlClient;

namespace DataAccess.Mapper
{
	public interface ICrudStatements
	{
        MySqlOperation GetCreateStatement(BaseClass entityDTO,  MySqlParameter errorMessage);
        MySqlOperation GetUpdateStatement(BaseClass entityDTO,  MySqlParameter errorMessage);
        MySqlOperation GetDeleteStatement(BaseClass entityDTO,  MySqlParameter errorMessage);
        MySqlOperation GetRetrieveAllStatement();
        MySqlOperation GetRetrieveByIdStatement(int Id);
    }
}

