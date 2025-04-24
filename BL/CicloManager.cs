using DTO;
using DataAccess.Crud; // ✅ Este es el correcto para CicloDao
using System.Collections.Generic;

namespace BL
{
    public class CicloManager
    {
        private readonly CicloDao _cicloDao = new CicloDao();

        public List<Ciclo> ObtenerTodos()
        {
            return _cicloDao.ObtenerTodos();
        }

        public List<Ciclo> BuscarPorAnio(int anio)
        {
            return _cicloDao.BuscarPorAnio(anio);
        }

        public void CrearCiclo(Ciclo ciclo)
        {
            _cicloDao.CrearCiclo(ciclo);
        }

        public void ActualizarCiclo(Ciclo ciclo, int codigo)
        {
            _cicloDao.ActualizarCiclo(ciclo, codigo);
        }

        public void EliminarCiclo(int codigo)
        {
            _cicloDao.EliminarCiclo(codigo);
        }

        public void ActivarCiclo(int codigo)
        {
            _cicloDao.ActivarCiclo(codigo);
        }
    }
}