using DTO;
using DataAccess.Mapper;

namespace DataAccess.Mapper
{
    public class CarreraMapper : IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var carrera = new Carrera
            {
                Codigo = Convert.ToInt32(row["codigo"]),
                Nombre = row["nombre"].ToString()
            };
            return carrera;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> rows)
        {
            return rows.Select(BuildObject).ToList();
        }
    }
}