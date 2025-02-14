using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankrendszer
{
    internal class Log
    {
        public DateTime Date { get; private set; }
        public string LogMessage { get; private set; }

        public Log(DateTime date, string logMessage)
        {
            Date = date;
            LogMessage = logMessage;
        }
    }
}
