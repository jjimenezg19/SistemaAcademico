using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Dao
{
    public class MySqlOperation
    {
        public string ProcedureName { get; set; }
        public List<MySqlParameter> parameters;

        public MySqlOperation()
        {
            parameters = new List<MySqlParameter>();
        }

        public void AddVarcharParam(string parameterName, string paramValue)
        {
            parameters.Add(new MySqlParameter("@" + parameterName, paramValue));
        }

        public void AddTextParam(string parameterName, string paramValue)
        {
            parameters.Add(new MySqlParameter("@" + parameterName, paramValue));
        }

        public void AddDateTimeParam(string parameterName, DateTime paramValue)
        {
            parameters.Add(new MySqlParameter("@" + parameterName, paramValue));
        }

        public void AddTimeSpanParam(string parameterName, TimeSpan? paramValue)
        {
            if (paramValue.HasValue)
            {
                parameters.Add(new MySqlParameter("@" + parameterName, SqlDbType.Time) { Value = paramValue.Value });
            }
            else
            {
                parameters.Add(new MySqlParameter("@" + parameterName, SqlDbType.Time) { Value = DBNull.Value });
            }
        }


        public void AddIntegerParam(string parameterName, int? paramValue)
        {
            if (paramValue.HasValue)
            {
                parameters.Add(new MySqlParameter("@" + parameterName, SqlDbType.Int) { Value = paramValue.Value });
            }
            else
            {
                parameters.Add(new MySqlParameter("@" + parameterName, SqlDbType.Int) { Value = DBNull.Value });
            }
        }

        public void AddDecimalParam(string parameterName, decimal? paramValue)
        {
            if (paramValue.HasValue)
            {
                parameters.Add(new MySqlParameter("@" + parameterName, SqlDbType.Decimal)
                {
                    Value = paramValue.Value,
                    Precision = 5,
                    Scale = 2
                });
            }
            else
            {
                parameters.Add(new MySqlParameter("@" + parameterName, SqlDbType.Decimal)
                {
                    Value = DBNull.Value,
                    Precision = 5,
                    Scale = 2
                });
            }
        }
    }
}