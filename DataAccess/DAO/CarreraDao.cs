using DataAccess.Dao;
using DataAccess.Mapper;
using DTO;

namespace DataAccess.Dao
{
    public class CarreraDao
    {
        private readonly CarreraMapper _mapper = new CarreraMapper();

        public Carrera BuscarPorCodigo(int codigo)
        {
            var op = new MySqlOperation { ProcedureName = "BuscarCarreraPorCodigo" };
            op.AddIntegerParam("codigo", codigo);

            var row = MySqlDao.GetInstance().ExecuteStoredProcedureWithUniqueResult(op);
            return (Carrera)_mapper.BuildObject(row);
        }

        public Carrera BuscarPorNombre(string nombre)
        {
            var op = new MySqlOperation { ProcedureName = "BuscarCarreraPorNombre" };
            op.AddVarcharParam("nombre", nombre);

            var row = MySqlDao.GetInstance().ExecuteStoredProcedureWithUniqueResult(op);
            return (Carrera)_mapper.BuildObject(row);
        }

        public List<Carrera> ObtenerTodas()
        {
            var op = new MySqlOperation { ProcedureName = "ObtenerTodasLasCarreras" };
            var resultados = MySqlDao.GetInstance().ExecuteStoredProcedureWithQuery(op);
            return _mapper.BuildObjects(resultados).Cast<Carrera>().ToList();
        }

        public List<Curso> ObtenerCursosPorCarrera(int carreraId)
        {
            var op = new MySqlOperation { ProcedureName = "ObtenerCursosPorCarrera" };
            op.AddIntegerParam("p_carreraId", carreraId);

            var resultados = MySqlDao.GetInstance().ExecuteStoredProcedureWithQuery(op);
            return resultados.Select(row => new Curso
            {
                Codigo = Convert.ToInt32(row["codigo"]),
                Nombre = row["nombre"].ToString(),
                HorasSemanales = Convert.ToInt32(row["horasSemanales"]),
            }).ToList();
        }

        public void AgregarCursoACarrera(int carreraId, int cursoId)
        {
            var op = new MySqlOperation { ProcedureName = "AgregarCursoACarrera" };
            op.AddIntegerParam("p_carreraId", carreraId);
            op.AddIntegerParam("p_cursoId", cursoId);
            MySqlDao.GetInstance().ExecuteStoredProcedure(op);
        }

        public void QuitarCursoDeCarrera(int carreraId, int cursoId)
        {
            var op = new MySqlOperation { ProcedureName = "QuitarCursoDeCarrera" };
            op.AddIntegerParam("p_carreraId", carreraId);
            op.AddIntegerParam("p_cursoId", cursoId);
            MySqlDao.GetInstance().ExecuteStoredProcedure(op);
        }

        public void ActualizarOrdenCurso(int carreraId, int cursoId, int nuevoOrden)
        {
            var op = new MySqlOperation
            {
                ProcedureName = "ActualizarOrdenCursoEnCarrera"
            };
            op.AddIntegerParam("p_carreraId", carreraId);
            op.AddIntegerParam("p_cursoId", cursoId);
            op.AddIntegerParam("p_nuevoOrden", nuevoOrden);

            MySqlDao.GetInstance().ExecuteStoredProcedure(op);
        }
    }
}
