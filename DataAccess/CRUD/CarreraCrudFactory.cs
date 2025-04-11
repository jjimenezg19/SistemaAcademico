using DataAccess.Dao;
using DataAccess.Mapper;
using DTO;

namespace DataAccess.CRUD
{
    public class CarreraCrudFactory : CrudFactory
    {
        private readonly CarreraMapper mapper;

        public CarreraCrudFactory()
        {
            mapper = new CarreraMapper();
            dao = MySqlDao.GetInstance();
        }

        public override string Create(BaseClass entityDTO)
        {
            throw new NotImplementedException(); // Por ahora
        }

        public override void Delete(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var operation = new MySqlOperation { ProcedureName = "ObtenerTodasLasCarreras" };
            var result = dao.ExecuteStoredProcedureWithQuery(operation);
            var list = mapper.BuildObjects(result);

            return list.Cast<T>().ToList();
        }

        public override BaseClass RetrieveById(int id)
        {
            var operation = new MySqlOperation { ProcedureName = "BuscarCarreraPorCodigo" };
            operation.AddIntegerParam("codigo", id);

            var result = dao.ExecuteStoredProcedureWithQuery(operation);
            if (result.Count > 0)
                return mapper.BuildObject(result[0]);

            return null;
        }

        public BaseClass RetrieveByNombre(string nombre)
        {
            var operation = new MySqlOperation { ProcedureName = "BuscarCarreraPorNombre" };
            operation.AddVarcharParam("nombre", nombre);

            var result = dao.ExecuteStoredProcedureWithQuery(operation);
            if (result.Count > 0)
                return mapper.BuildObject(result[0]);

            return null;
        }
    }
}