using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace prjJobLogger
{
    class DBLogWriter : LogWriter, ILogWriter, IPersistentLog
    {
        private string _connectionString = string.Empty;

        public DBLogWriter(bool logMessage, bool logWarning, bool logError) : base(logMessage, logWarning, logError)
        {
        }

        public void SetDetination(string destination)
        {
            _connectionString = destination;
        }

        public override int WriteLog(string message)
        {
            if (_connectionString.Trim()==string.Empty)
            {
                _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BDJobLogger"].ConnectionString;
            }

            try
            {

                SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("InsertLog",connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parMessage = command.Parameters.Add("Message", SqlDbType.NVarChar,500);
                parMessage.Direction = ParameterDirection.Input;
                parMessage.Value = message;

                SqlParameter parType = command.Parameters.Add("Type", SqlDbType.TinyInt);
                parType.Direction = ParameterDirection.Input;
                parType.Value = _logType;

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            return 1;
        }
    }
}
