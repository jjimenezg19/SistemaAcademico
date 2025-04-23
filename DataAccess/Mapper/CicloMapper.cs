using DTO;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class CicloMapper
    {
        public Ciclo BuildObject(Dictionary<string, object> row)
        {
            return new Ciclo
            {
                Codigo = Convert.ToInt32(row["codigo"]),
                Anio = Convert.ToInt32(row["anio"]),
                Numero = Convert.ToInt32(row["numero"]),
                FechaInicio = Convert.ToDateTime(row["fechaInicio"]),
                FechaFinalizacion = Convert.ToDateTime(row["fechaFinalizacion"]),
                Activo = Convert.ToBoolean(row["activo"])
            };
        }

        public List<Ciclo> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var lista = new List<Ciclo>();
            foreach (var row in rows)
            {
                lista.Add(BuildObject(row));
            }
            return lista;
        }
    }
}