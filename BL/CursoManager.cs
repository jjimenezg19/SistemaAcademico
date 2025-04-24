using DTO;
using DataAccess.Dao;
using System.Collections.Generic;

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

        public void CrearCurso(Curso curso)
        {
            _cursoDao.CrearCurso(curso);
        }

        public void ActualizarCurso(Curso curso)
        {
            _cursoDao.ActualizarCurso(curso);
        }

        public void EliminarCurso(int codigo)
        {
            _cursoDao.EliminarCurso(codigo);
        }
    }
}