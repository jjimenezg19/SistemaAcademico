using DTO;
using DataAccess.Dao;

namespace BL
{
    public class CursoManager
    {
        private readonly CursoDao _cursoDao = new CursoDao();

        public List<Curso> BuscarCursosPorNombre(string nombre)
        {
            return _cursoDao.BuscarPorNombre(nombre);
        }

        public Curso BuscarCursoPorCodigo(int codigo)
        {
            return _cursoDao.BuscarPorCodigo(codigo);
        }

        public List<Curso> BuscarCursosPorCarrera(int carreraId)
        {
            return _cursoDao.BuscarPorCarrera(carreraId);
        }
    }
}