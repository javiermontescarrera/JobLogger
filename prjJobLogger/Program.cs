using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjJobLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            JobLogger job = new JobLogger(true, true, true, true, true, true);

            job.LogMessage("prueba1", LogType.Error);
            */

            JobLogger job = new JobLogger(false, true, false, true, false, false);
            job.LogMessage("Message Test", LogType.Message);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tarea concluida. Por favor, presione ENTER para cerrar la consola.");
            Console.ReadLine();

        }
    }
}
