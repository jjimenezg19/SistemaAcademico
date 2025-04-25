using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DataAccess.Dao;

namespace DataAccess.Dao
{
    public class GrupoDao
    {
        public List<Grupo> ObtenerGrupos(int cursoId, int anio, int numeroCiclo)
        {
            var op = new MySqlOperation
            {
                ProcedureName = "ObtenerGruposPorCursoYCiclo"
            };

            op.AddIntegerParam("p_cursoId", cursoId);
            op.AddIntegerParam("p_anio", anio);
            op.AddIntegerParam("p_numeroCiclo", numeroCiclo);

            var resultados = MySqlDao.GetInstance().ExecuteStoredProcedureWithQuery(op);

            return resultados.Select(row => new Grupo
            {
                CodigoCurso = cursoId, 
                NumeroDeGrupo = Convert.ToInt32(row["numeroGrupo"]),
                Horario = Convert.ToDateTime(row["horarioDisponible"]),
                Profesor = new Profesor { Cedula = row["profesor_cedula"].ToString() },
                CicloAnio = anio,         
                CicloNumero = numeroCiclo
            }).ToList();
        }


        public void InsertarGrupo(Grupo grupo)
        {
            var op = new MySqlOperation
            {
                ProcedureName = "InsertarGrupo"
            };

            op.AddIntegerParam("p_cursoId", grupo.CodigoCurso);
            op.AddIntegerParam("p_anio", grupo.CicloAnio);
            op.AddIntegerParam("p_numeroCiclo", grupo.CicloNumero);
            op.AddIntegerParam("p_numeroGrupo", grupo.NumeroDeGrupo);
            op.AddDateTimeParam("p_horario", grupo.Horario);
            op.AddIntegerParam("p_profesorId", grupo.Profesor?.Id ?? 0);

            MySqlDao.GetInstance().ExecuteStoredProcedure(op);
        }

        public void ModificarGrupo(Grupo grupo)
        {
            var op = new MySqlOperation
            {
                ProcedureName = "ModificarGrupo"
            };

            op.AddIntegerParam("p_cursoId", grupo.CodigoCurso);
            op.AddIntegerParam("p_anio", grupo.CicloAnio);
            op.AddIntegerParam("p_numeroCiclo", grupo.CicloNumero);
            op.AddIntegerParam("p_numeroGrupo", grupo.NumeroDeGrupo);
            op.AddDateTimeParam("p_horario", grupo.Horario);
            op.AddIntegerParam("p_profesorId", grupo.Profesor?.Id ?? 0);

            MySqlDao.GetInstance().ExecuteStoredProcedure(op);
        }
    }
}

