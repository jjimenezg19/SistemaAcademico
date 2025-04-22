using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Dao
{
    public class MySqlDao
    {
        private static MySqlDao instance = new MySqlDao();
        private string _connString = "Server=localhost; Database=sistema_academico; User Id=root; Password=Cmqt1234";

        public static MySqlDao GetInstance()
        {
            if (instance == null)
                instance = new MySqlDao();
            return instance;
        }

        public void ExecuteStoredProcedure(MySqlOperation operation)
        {
            using (var conn = new MySqlConnection(_connString))
            {
                using (var command = new MySqlCommand(operation.ProcedureName, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    foreach (var p in operation.Parameters)
                    {
                        command.Parameters.Add(p);
                    }

                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Dictionary<string, object>> ExecuteStoredProcedureWithQuery(MySqlOperation operation)
        {
            var results = new List<Dictionary<string, object>>();

            using (var conn = new MySqlConnection(_connString))
            {
                using (var command = new MySqlCommand(operation.ProcedureName, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    foreach (var p in operation.Parameters)
                    {
                        command.Parameters.Add(p);
                    }

                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (var i = 0; i < reader.FieldCount; i++)
                            {
                                row.Add(reader.GetName(i), reader.GetValue(i));
                            }
                            results.Add(row);
                        }
                    }
                }
            }
            return results;
        }

        public Dictionary<string, object> ExecuteStoredProcedureWithUniqueResult(MySqlOperation operation)
        {
            using (var conn = new MySqlConnection(_connString))
            {
                using (var command = new MySqlCommand(operation.ProcedureName, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    foreach (var p in operation.Parameters)
                    {
                        command.Parameters.Add(p);
                    }

                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (var i = 0; i < reader.FieldCount; i++)
                            {
                                row.Add(reader.GetName(i), reader.GetValue(i));
                            }
                            return row;
                        }
                    }
                }
            }
            return null;
        }
    }
}