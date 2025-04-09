using DTO;

namespace DataAccess.Mapper
{
    public interface IObjectMapper
    {
        BaseClass BuildObject(Dictionary<string, object> row);
        List<BaseClass> BuildObjects(List<Dictionary<string, object>> rows);
    }
}