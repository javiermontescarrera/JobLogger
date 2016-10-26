using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjJobLogger
{
    abstract class LogWriter
    {
        public static bool _logMessage;
        public static bool _logWarning;
        public static bool _logError;
        public static LogType _logType;
        public static int _maxMessageSize;

        public LogWriter(bool logMessage, bool logWarning, bool logError)
        {
            _logMessage = logMessage;
            _logWarning = logWarning;
            _logError = logError;
            _maxMessageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MaxMessageSize"]);
        }

        public int LogMessage(string message, LogType type)
        {
            // Sólo realizamos esta acción si es que se cumplen las condiciones requeridas
            if ((type == LogType.Error && _logError) || (type == LogType.Warning && _logWarning) || (type == LogType.Message && _logMessage))
            {
                _logType = type;

                message = DateTime.Now.ToLongTimeString() + " - Type: " + _logType.ToString() + " - " + message;
                message = message.Trim();

                //Nos aseguramos de que el mensaje no supere el tamaño máximo
                
                if (message.Length > _maxMessageSize)
                {
                    message = message.Substring(0, _maxMessageSize - 1);
                }

                return WriteLog(message);
            }
            else
            {
                throw new Exception("The type of the message does not match with the configured type(s)");
            }
        }

        public abstract int WriteLog(string message);
    }
}
