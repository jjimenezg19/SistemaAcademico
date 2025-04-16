using DTO;
using DataAccess.CRUD;
using DataAccess.Dao;

namespace BL
{
    public class CarreraManager
    {
        private readonly CarreraCrudFactory _factory = new CarreraCrudFactory();
        private readonly CarreraDao _carreraDao = new CarreraDao();
        private readonly CursoDao _cursoDao = new CursoDao();

        public List<Carrera> ObtenerTodas()
        {
            return _factory.RetrieveAll<Carrera>();
        }

        public Carrera BuscarPorCodigo(int codigo)
        {
            return (Carrera)_factory.RetrieveById(codigo);
        }

        public Carrera BuscarPorNombre(string nombre)
        {
            return (Carrera)_factory.RetrieveByNombre(nombre);
        }

        public List<Curso> ObtenerCursosDeCarrera(int carreraId)
        {
            return _carreraDao.ObtenerCursosPorCarrera(carreraId);
        }

        public void AgregarCurso(int carreraId, int cursoId)
        {
            _carreraDao.AgregarCursoACarrera(carreraId, cursoId);
        }

        public void QuitarCurso(int carreraId, int cursoId)
        {
            _carreraDao.QuitarCursoDeCarrera(carreraId, cursoId);
        }

        public void CambiarOrdenCurso(int carreraId, int cursoId, int nuevoOrden)
        {
            _cursoDao.ActualizarOrdenCurso(carreraId, cursoId, nuevoOrden);
        }
    }
}