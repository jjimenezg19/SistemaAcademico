using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DataAccess.Dao;

namespace DataAccess.Dao
{
    public class MatriculaDao
    {
        public List<Grupo> ObtenerGruposPorAlumnoYCiclo(string cedulaAlumno, int anio, int numeroCiclo)
        {
            var op = new MySqlOperation
            {
                ProcedureName = "ObtenerGruposPorAlumnoYCiclo"
            };

            op.AddVarcharParam("p_cedulaAlumno", cedulaAlumno);
            op.AddIntegerParam("p_anio", anio);
            op.AddIntegerParam("p_numeroCiclo", numeroCiclo);

            var resultados = MySqlDao.GetInstance().ExecuteStoredProcedureWithQuery(op);

            return resultados.Select(row => new Grupo
            {
                CodigoCurso = Convert.ToInt32(row["codigoCurso"]),
                NumeroDeGrupo = Convert.ToInt32(row["numeroGrupo"]),
                Horario = Convert.ToDateTime(row["horario"]),
                CicloAnio = Convert.ToInt32(row["cicloAnio"]),
                CicloNumero = Convert.ToInt32(row["cicloNumero"])
            }).ToList();
        }

        public void InsertarMatricula(Matricula matricula)
        {
            var op = new MySqlOperation
            {
                ProcedureName = "InsertarMatricula"
            };

            op.AddVarcharParam("p_cedulaAlumno", matricula.Alumno.Cedula);
            op.AddIntegerParam("p_cursoId", matricula.Grupo.CodigoCurso);
            op.AddIntegerParam("p_numeroGrupo", matricula.Grupo.NumeroDeGrupo);
            op.AddIntegerParam("p_anio", matricula.Grupo.CicloAnio);
            op.AddIntegerParam("p_numeroCiclo", matricula.Grupo.CicloNumero);

            MySqlDao.GetInstance().ExecuteStoredProcedure(op);
        }

        public void EliminarMatricula(Matricula matricula)
        {
            var op = new MySqlOperation
            {
                ProcedureName = "EliminarMatricula"
            };

            op.AddVarcharParam("p_cedulaAlumno", matricula.Alumno.Cedula);
            op.AddIntegerParam("p_cursoId", matricula.Grupo.CodigoCurso);
            op.AddIntegerParam("p_numeroGrupo", matricula.Grupo.NumeroDeGrupo);
            op.AddIntegerParam("p_anio", matricula.Grupo.CicloAnio);
            op.AddIntegerParam("p_numeroCiclo", matricula.Grupo.CicloNumero);

            MySqlDao.GetInstance().ExecuteStoredProcedure(op);
        }
    }
}

