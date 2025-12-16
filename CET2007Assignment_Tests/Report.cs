
using System.Collections.Generic;

namespace CET2007_Assignment
{
    class Report // report generation class
    {
        private readonly Logger loggerInstance; // logger instance

        public Report()
        {
            loggerInstance = Logger.GetInstance(); // get singleton logger instance
        }

        private void Summary(List<ReportLog> log)
        {
            if (log.Count == 0)
            {
                loggerInstance.Log("Report", "No data to generate report.");
                return;
            }
            // summary report
        }
    }
}