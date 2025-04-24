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
                Codigo = Convert.ToInt32(row["CODIGO"]),
                Anio = Convert.ToInt32(row["ANIO"]),
                Numero = Convert.ToInt32(row["NUMERO"]),
                FechaInicio = Convert.ToDateTime(row["FECHA_INICIO"]),
                FechaFinalizacion = Convert.ToDateTime(row["FECHA_FINALIZACION"]),
                Activo = Convert.ToBoolean(row["ACTIVO"])
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