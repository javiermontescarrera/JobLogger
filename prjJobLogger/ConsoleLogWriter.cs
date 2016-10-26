using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjJobLogger
{
    class ConsoleLogWriter : LogWriter, ILogWriter
    {
        public ConsoleLogWriter(bool logMessage, bool logWarning, bool logError) : base(logMessage, logWarning, logError)
        {
        }

        public override int WriteLog(string message)
        {
            if (_logType == LogType.Error && _logError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            if (_logType == LogType.Warning && _logWarning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (_logType == LogType.Message && _logMessage)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine(message);

            return 1;
        }
        
    }
}
