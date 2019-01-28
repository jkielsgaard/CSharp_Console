using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// Simple Logning to create error or event logs
    /// </summary>

    public class SimpleLog
    {
        string _filepath = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath">The path to where the log file shall be saved</param>
        public SimpleLog(string filepath)
        {
            _filepath = filepath;
        }

        /// <summary>
        /// Log file streamwriter
        /// </summary>
        /// <param name="LogData">The data from AWS GetLogEventsResponse</param>
        public void write(List<LogData> LogData)
        {
            List<LogData> log = new List<LogData>();

            foreach (var logs in LogData)
            {
                using (StreamWriter file = new StreamWriter(_filepath, true))
                {
                    file.WriteLine("[" + logs.unixtimestamp + "] [ErrorMsg: " + logs.ErrorMessage + "]");
                }
            }
        }
    }

    public class LogData
    {
        public int unixtimestamp { get; set; }
        public string ErrorMessage { get; set; }
    }
}
