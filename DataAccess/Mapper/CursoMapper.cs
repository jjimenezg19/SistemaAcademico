using DTO;
using DataAccess.Mapper;

namespace DataAccess.Mapper
{
    public class CursoMapper : IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var curso = new Curso
            {
                Codigo = Convert.ToInt32(row["codigo"]),
                Nombre = row["nombre"].ToString(),
                HorasSemanales = Convert.ToInt32(row["horasSemanales"]),
                CarreraId = Convert.ToInt32(row["carrera_id"])
            };
            return curso;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> rows)
        {
            return rows.Select(BuildObject).ToList();
        }
    }
}