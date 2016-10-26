using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjJobLogger
{
    class FileLogWriter : LogWriter, ILogWriter, IPersistentLog
    {
        private string _logPath=string.Empty; 

        public FileLogWriter(bool logMessage, bool logWarning, bool logError) : base(logMessage, logWarning, logError)
        {
        }

        public override int WriteLog(string message)
        {
            string logFile = string.Empty;

            if (_logPath.Trim() == string.Empty)
            {
                // Seteamos la ruta por defecto del archivo log
                _logPath = System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"];
            }

            if (!System.IO.Directory.Exists(_logPath))
            {
                throw new Exception("Path not found");
            }

            logFile = _logPath + "LogFile" + DateTime.Now.ToShortDateString().Replace("/","-") + ".txt";

            string l = String.Empty;

            if (System.IO.File.Exists(logFile))
            {
                l = System.IO.File.ReadAllText(logFile);
            }

            if (l.Trim() != string.Empty)
            {
                l += Environment.NewLine;
            }
            l += message;

            System.IO.File.WriteAllText(logFile, l);

            return 1;
        }

        public void SetDetination(string destination)
        {
            _logPath = destination;
        }
    }
}
