using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// To create windows events logs, need admin rights
    /// </summary>

    class WindowsEvents
    {
        public void setEvent()
        {
            string sSource;
            string sLog;
            string sEvent;

            sSource = "WindowsEvent_AccessTester";
            sLog = "Application";
            sEvent = "Sample Event";

            if (!EventLog.SourceExists(sSource)) { EventLog.CreateEventSource(sSource, sLog); }

            EventLog.WriteEntry(sSource, sEvent);
            EventLog.WriteEntry(sSource, sEvent, EventLogEntryType.Warning, 234);
        }
    }
}
