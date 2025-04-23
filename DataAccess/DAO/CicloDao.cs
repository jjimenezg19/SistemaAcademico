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

        // READ: Obtener todos los ciclos
        public List<Ciclo> ObtenerTodos()
        {
            var operation = new MySqlOperation { ProcedureName = "ObtenerTodosLosCiclos" };
            var result = dao.ExecuteStoredProcedureWithQuery(operation);
            return mapper.BuildObjects(result);
        }

        // READ: Buscar ciclos por año
        public List<Ciclo> BuscarPorAnio(int anio)
        {
            var operation = new MySqlOperation { ProcedureName = "BuscarCiclosPorAnio" };
            operation.AddIntegerParam("p_anio", anio);
            var result = dao.ExecuteStoredProcedureWithQuery(operation);
            return mapper.BuildObjects(result);
        }

        // CREATE: Crear nuevo ciclo
        public void CrearCiclo(Ciclo ciclo)
        {
            var operation = new MySqlOperation { ProcedureName = "CrearCiclo" };
            operation.AddIntegerParam("p_anio", ciclo.Anio);
            operation.AddIntegerParam("p_numero", ciclo.Numero);
            operation.AddDateTimeParam("p_fechaInicio", ciclo.FechaInicio);
            operation.AddDateTimeParam("p_fechaFinalizacion", ciclo.FechaFinalizacion);
            dao.ExecuteStoredProcedure(operation);
        }

        // UPDATE: Actualizar ciclo existente
        public void ActualizarCiclo(Ciclo ciclo, int codigo)
        {
            var operation = new MySqlOperation { ProcedureName = "ActualizarCiclo" };
            operation.AddIntegerParam("p_codigo", codigo);
            operation.AddIntegerParam("p_anio", ciclo.Anio);
            operation.AddIntegerParam("p_numero", ciclo.Numero);
            operation.AddDateTimeParam("p_fechaInicio", ciclo.FechaInicio);
            operation.AddDateTimeParam("p_fechaFinalizacion", ciclo.FechaFinalizacion);
            dao.ExecuteStoredProcedure(operation);
        }

        // DELETE: Eliminar ciclo
        public void EliminarCiclo(int codigo)
        {
            var operation = new MySqlOperation { ProcedureName = "EliminarCiclo" };
            operation.AddIntegerParam("p_codigo", codigo);
            dao.ExecuteStoredProcedure(operation);
        }

        // Activar ciclo
        public void ActivarCiclo(int codigo)
        {
            var operation = new MySqlOperation { ProcedureName = "ActivarCiclo" };
            operation.AddIntegerParam("p_codigo", codigo);
            dao.ExecuteStoredProcedure(operation);
        }
    }
}
