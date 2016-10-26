using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace prjJobLogger
{

    public class JobLogger
    {
        private static bool _logToFile;
        private static bool _logToConsole;
        private static bool _logToDatabase;

        private static bool _logMessage;
        private static bool _logWarning;
        private static bool _logError;

        private static List<LogWriter> _logWriters;

        public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase, bool logMessage, bool logWarning, bool logError)
        {
            _logError = logError;
            _logMessage = logMessage;
            _logWarning = logWarning;
            _logToDatabase = logToDatabase;
            _logToFile = logToFile;
            _logToConsole = logToConsole;

            _logWriters = new List<LogWriter>();

            if (_logToConsole)
            {
                _logWriters.Add(new ConsoleLogWriter(logMessage, logWarning, logError));
            }
            if (_logToFile)
            {
                _logWriters.Add(new FileLogWriter(logMessage, logWarning, logError));
            }
            if (logToDatabase)
            {
                _logWriters.Add(new DBLogWriter(logMessage, logWarning, logError));
            }
        }

        public int LogMessage(string message, LogType type)
        {
            int retVal = -1;

            message = message.Trim();
            if (message == null || message.Length == 0)
            {
                return retVal;
            }
            if (!_logToConsole && !_logToFile && !_logToDatabase)
            {
                throw new Exception("Invalid configuration");
            }
            if (!_logError && !_logMessage && !_logWarning)
            {
                throw new Exception("Error or Warning or Message must be specified");
            }

            foreach (LogWriter Writer in _logWriters)
            {
                retVal = Writer.LogMessage(message, type);
            }

            return retVal;
        }
    }

}
