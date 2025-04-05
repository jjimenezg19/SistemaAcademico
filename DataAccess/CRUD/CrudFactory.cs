using DataAccess.Dao;
using DTO; 

namespace DataAccess.CRUD
{
	public abstract class CrudFactory
	{
		protected MySqlDao dao;

		public abstract String Create(BaseClass entityDTO);
        public abstract void Update(BaseClass entityDTO);
        public abstract void Delete(BaseClass entityDTO);
        public abstract List<T> RetrieveAll<T>();
        public abstract BaseClass RetrieveById(int id);

    }
}

