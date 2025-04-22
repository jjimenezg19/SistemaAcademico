using DataAccess.Dao;
using DataAccess.Mapper;
using DTO;
using System.Collections.Generic;

namespace DataAccess.Crud
{
    public class CicloDao
    {
        private MySqlDao dao = MySqlDao.GetInstance();
        private CicloMapper mapper = new CicloMapper();

        public List<Ciclo> ObtenerTodos()
        {
            var operation = new MySqlOperation { ProcedureName = "ObtenerTodosLosCiclos" };
            var result = dao.ExecuteStoredProcedureWithQuery(operation);
            return mapper.BuildObjects(result);
        }

        public List<Ciclo> BuscarPorAnio(int anio)
        {
            var operation = new MySqlOperation { ProcedureName = "BuscarCiclosPorAnio" };
            operation.AddIntegerParam("p_anio", anio);
            var result = dao.ExecuteStoredProcedureWithQuery(operation);
            return mapper.BuildObjects(result);
        }

        public void ActivarCiclo(int codigo)
        {
            var operation = new MySqlOperation { ProcedureName = "ActivarCiclo" };
            operation.AddIntegerParam("p_codigo", codigo);
            dao.ExecuteStoredProcedure(operation);
        }
    }
}