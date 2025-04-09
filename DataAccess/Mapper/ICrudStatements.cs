using DataAccess.Dao;
using DTO;

namespace DataAccess.Mapper
{
	public interface ICrudStatements
	{
        MySqlOperation GetCreateStatement(BaseClass entityDTO);
        MySqlOperation GetUpdateStatement(BaseClass entityDTO);
        MySqlOperation GetDeleteStatement(BaseClass entityDTO);
        MySqlOperation GetRetrieveAllStatement();
        MySqlOperation GetRetrieveByIdStatement(int Id);
    }
}

