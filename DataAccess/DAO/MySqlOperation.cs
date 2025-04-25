using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Dao
{
    public class MySqlOperation
    {
        public string ProcedureName { get; set; }

        // ✅ Propiedad pública para acceder desde otras clases
        public List<MySqlParameter> Parameters { get; set; }

        public MySqlOperation()
        {
            Parameters = new List<MySqlParameter>();
        }

        public void AddParam(MySqlParameter param)
        {
            Parameters.Add(param);
        }

        public void AddVarcharParam(string parameterName, string paramValue)
        {
            Parameters.Add(new MySqlParameter("@" + parameterName, paramValue));
        }

        public void AddTextParam(string parameterName, string paramValue)
        {
            Parameters.Add(new MySqlParameter("@" + parameterName, paramValue));
        }

        public void AddDateTimeParam(string parameterName, DateTime paramValue)
        {
            Parameters.Add(new MySqlParameter("@" + parameterName, paramValue));
        }

        public void AddTimeSpanParam(string parameterName, TimeSpan? paramValue)
        {
            Parameters.Add(new MySqlParameter("@" + parameterName, SqlDbType.Time)
            {
                Value = paramValue ?? (object)DBNull.Value
            });
        }

        public void AddIntegerParam(string parameterName, int? paramValue)
        {
            Parameters.Add(new MySqlParameter("@" + parameterName, SqlDbType.Int)
            {
                Value = paramValue ?? (object)DBNull.Value
            });
        }

        public void AddDecimalParam(string parameterName, decimal? paramValue)
        {
            Parameters.Add(new MySqlParameter("@" + parameterName, SqlDbType.Decimal)
            {
                Value = paramValue ?? (object)DBNull.Value,
                Precision = 5,
                Scale = 2
            });
        }
    }
}
