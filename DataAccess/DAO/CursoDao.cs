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

        public List<Curso> ObtenerPorCarrera(int carreraId)
        {
            var op = new MySqlOperation
            {
                ProcedureName = "ObtenerCursosPorCarrera"
            };
            op.AddIntegerParam("p_carreraId", carreraId);

            var resultados = MySqlDao.GetInstance().ExecuteStoredProcedureWithQuery(op);
            return _mapper.BuildObjects(resultados).Cast<Curso>().ToList();
        }

        public void AgregarCursoACarrera(int carreraId, int cursoId)
        {
            var op = new MySqlOperation
            {
                ProcedureName = "AgregarCursoACarrera"
            };
            op.AddIntegerParam("p_carreraId", carreraId);
            op.AddIntegerParam("p_cursoId", cursoId);

            MySqlDao.GetInstance().ExecuteStoredProcedure(op);
        }

        public void QuitarCursoDeCarrera(int carreraId, int cursoId)
        {
            var op = new MySqlOperation
            {
                ProcedureName = "QuitarCursoDeCarrera"
            };
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

        // 🔹 Crear nuevo curso
        public void CrearCurso(Curso curso)
        {
            var op = new MySqlOperation { ProcedureName = "CrearCurso" };
            op.AddVarcharParam("p_nombre", curso.Nombre);
            op.AddIntegerParam("p_horasSemanales", curso.HorasSemanales);
            op.AddIntegerParam("p_carreraId", curso.CarreraId);
            MySqlDao.GetInstance().ExecuteStoredProcedure(op);
        }

        // 🔹 Actualizar curso
        public void ActualizarCurso(Curso curso)
        {
            var op = new MySqlOperation { ProcedureName = "ActualizarCurso" };
            op.AddIntegerParam("p_codigo", curso.Codigo);
            op.AddVarcharParam("p_nombre", curso.Nombre);
            op.AddIntegerParam("p_horasSemanales", curso.HorasSemanales);
            op.AddIntegerParam("p_carreraId", curso.CarreraId);
            MySqlDao.GetInstance().ExecuteStoredProcedure(op);
        }

        // 🔹 Eliminar curso
        public void EliminarCurso(int codigo)
        {
            var op = new MySqlOperation { ProcedureName = "EliminarCurso" };
            op.AddIntegerParam("p_codigo", codigo);
            MySqlDao.GetInstance().ExecuteStoredProcedure(op);
        }
    }
}
