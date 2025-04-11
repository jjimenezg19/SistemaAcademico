using DTO;
using DataAccess.Dao;
using DataAccess.Mapper;

namespace DataAccess.Dao
{
    public class CursoDao
    {
        private readonly CursoMapper _mapper = new CursoMapper();

        public List<Curso> BuscarPorNombre(string nombre)
        {
            var op = new MySqlOperation
            {
                ProcedureName = "BuscarCursoPorNombre"
            };
            op.AddVarcharParam("p_nombre", nombre);

            var resultados = MySqlDao.GetInstance().ExecuteStoredProcedureWithQuery(op);
            return _mapper.BuildObjects(resultados).Cast<Curso>().ToList();
        }

        public Curso BuscarPorCodigo(int codigo)
        {
            var op = new MySqlOperation
            {
                ProcedureName = "BuscarCursoPorCodigo"
            };
            op.AddIntegerParam("p_codigo", codigo);

            var row = MySqlDao.GetInstance().ExecuteStoredProcedureWithUniqueResult(op);
            return (Curso)_mapper.BuildObject(row);
        }

        public List<Curso> BuscarPorCarrera(int carreraId)
        {
            var op = new MySqlOperation
            {
                ProcedureName = "BuscarCursoPorCarrera"
            };
            op.AddIntegerParam("p_carreraId", carreraId);

            var resultados = MySqlDao.GetInstance().ExecuteStoredProcedureWithQuery(op);
            return _mapper.BuildObjects(resultados).Cast<Curso>().ToList();
        }
    }
}