using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DataAccess.Dao;

namespace BL
{
    public class MatriculaManager
    {
        private readonly MatriculaDao _matriculaDao = new MatriculaDao();

        public List<Grupo> ObtenerGruposMatriculados(string cedulaAlumno, int anio, int numeroCiclo)
        {
            return _matriculaDao.ObtenerGruposPorAlumnoYCiclo(cedulaAlumno, anio, numeroCiclo);
        }

        public void AgregarMatricula(string cedulaAlumno, int codigoCurso, int numeroGrupo, int anio, int numeroCiclo)
        {
            var matricula = new Matricula
            {
                Alumno = new Alumno { Cedula = cedulaAlumno },
                Grupo = new Grupo
                {
                    CodigoCurso = codigoCurso,
                    NumeroDeGrupo = numeroGrupo,
                    CicloAnio = anio,
                    CicloNumero = numeroCiclo
                }
            };

            _matriculaDao.InsertarMatricula(matricula);
        }

        public void EliminarMatricula(string cedulaAlumno, int codigoCurso, int numeroGrupo, int anio, int numeroCiclo)
        {
            var matricula = new Matricula
            {
                Alumno = new Alumno { Cedula = cedulaAlumno },
                Grupo = new Grupo
                {
                    CodigoCurso = codigoCurso,
                    NumeroDeGrupo = numeroGrupo,
                    CicloAnio = anio,
                    CicloNumero = numeroCiclo
                }
            };

            _matriculaDao.EliminarMatricula(matricula);
        }
    }
}

