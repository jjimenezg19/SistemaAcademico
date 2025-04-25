using DataAccess.Dao;
using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class NotaMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var nota = new RegistroNota();

            if (row.ContainsKey("id"))
                nota.Id = Convert.ToInt32(row["id"]);
            if (row.ContainsKey("notaFinal"))
                nota.Nota = Convert.ToSingle(row["notaFinal"]);

            nota.Alumno = new Alumno
            {
                Cedula = row["alumno_id"].ToString()
            };

            nota.Grupo = new Grupo
            {
                Id = Convert.ToInt32(row["grupo_id"])
            };

            return nota;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> objectRows)
        {
            var list = new List<BaseClass>();
            foreach (var row in objectRows)
            {
                list.Add(BuildObject(row));
            }
            return list;
        }

        public MySqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            var nota = (RegistroNota)entityDTO;
            var operation = new MySqlOperation
            {
                ProcedureName = "CrearNota"
            };
            operation.AddVarcharParam("p_alumno_id", nota.Alumno.Cedula);
            operation.AddIntegerParam("p_grupo_id", nota.Grupo.Id);
            operation.AddFloatParam("p_nota", nota.Nota);
            return operation;
        }

        public MySqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            var nota = (RegistroNota)entityDTO;
            var operation = new MySqlOperation
            {
                ProcedureName = "ActualizarNota"
            };
            operation.AddIntegerParam("p_id", nota.Id);
            operation.AddFloatParam("p_nota", nota.Nota);
            return operation;
        }

        public MySqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            var nota = (RegistroNota)entityDTO;
            var operation = new MySqlOperation
            {
                ProcedureName = "EliminarNota"
            };
            operation.AddIntegerParam("p_id", nota.Id);
            return operation;
        }

        public MySqlOperation GetCreateStatement(BaseClass entityDTO, MySqlParameter errorMessage)
        {
            throw new NotImplementedException();
        }

        public MySqlOperation GetUpdateStatement(BaseClass entityDTO, MySqlParameter errorMessage)
        {
            throw new NotImplementedException();
        }

        public MySqlOperation GetDeleteStatement(BaseClass entityDTO, MySqlParameter errorMessage)
        {
            throw new NotImplementedException();
        }

        public MySqlOperation GetRetrieveAllStatement()
        {
            return new MySqlOperation
            {
                ProcedureName = "ObtenerTodasLasNotas"
            };
        }

        public MySqlOperation GetRetrieveByIdStatement(int id)
        {
            var operation = new MySqlOperation
            {
                ProcedureName = "ObtenerNotaPorId"
            };
            operation.AddIntegerParam("p_id", id);
            return operation;
        }

        public MySqlOperation GetRetrieveByGrupoStatement(int grupoId)
        {
            var operation = new MySqlOperation
            {
                ProcedureName = "ObtenerNotasPorGrupo"
            };
            operation.AddIntegerParam("p_grupo_id", grupoId);
            return operation;
        }
        
        public MySqlOperation GetRetrieveEstudiantesPorGrupoStatement(int grupoId)
        {
            var operation = new MySqlOperation
            {
                ProcedureName = "ObtenerEstudiantesPorGrupo"
            };
            operation.AddIntegerParam("p_grupo_id", grupoId);
            return operation;
        }
        
        public MySqlOperation GetRetrieveGruposPorProfesorStatement(string cedula)
        {
            var operation = new MySqlOperation
            {
                ProcedureName = "ObtenerGruposPorProfesor"
            };
            operation.AddVarcharParam("p_cedula", cedula);
            return operation;
        }
    }
}
        