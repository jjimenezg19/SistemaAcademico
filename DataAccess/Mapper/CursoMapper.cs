using DTO;
using DataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Mapper
{
    public class CursoMapper : IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var curso = new Curso
            {
                Codigo = Convert.ToInt32(row["CODIGO"]),
                Nombre = row["NOMBRE"].ToString(),
                HorasSemanales = Convert.ToInt32(row["HORAS_SEMANALES"]),
                CarreraId = Convert.ToInt32(row["CARRERA_ID"])
            };
            return curso;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> rows)
        {
            return rows.Select(BuildObject).ToList();
        }
    }
}