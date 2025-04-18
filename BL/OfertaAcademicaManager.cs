using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DTO;

namespace BL
{
    public class OfertaAcademicaManager
    {
        private readonly CarreraDao _carreraDao = new CarreraDao();
        private readonly GrupoDao _grupoDao = new GrupoDao();

        public List<Curso> ObtenerCursosPorCarrera(int carreraId)
        {
            return _carreraDao.ObtenerCursosPorCarrera(carreraId);
        }

        public List<Grupo> ObtenerGruposPorCursoYCiclo(int cursoId, int anio, int numeroCiclo)
        {
            return _grupoDao.ObtenerGrupos(cursoId, anio, numeroCiclo);
        }

        public void AgregarGrupo(Grupo grupo)
        {
            _grupoDao.InsertarGrupo(grupo);
        }

        public void ModificarGrupo(Grupo grupo)
        {
            _grupoDao.ModificarGrupo(grupo);
        }
    }

}
