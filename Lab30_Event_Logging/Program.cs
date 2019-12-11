using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab30_Event_Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog.WriteEntry("Application", "Haha I just deleted firewall.exe, I now have access to all of your cat videos!!! Good luck trying to enjoy your day without Mr.Bubbles",
                EventLogEntryType.Error,5001,1239);
        }
    }
}
