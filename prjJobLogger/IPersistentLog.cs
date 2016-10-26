using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjJobLogger
{
    interface IPersistentLog
    {
        void SetDetination(string destination);
    }
}
