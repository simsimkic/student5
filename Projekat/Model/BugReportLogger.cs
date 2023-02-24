using Repository;
using System;
using System.Collections.Generic;

namespace Model
{
    public class BugReportLogger
    {

        private static BugReportLogger instance;
        private static readonly object padlock = new object();
        public BugReportLogger Instance { get; set; }

        private BugReportLogger()
        {

        }

        public static BugReportLogger GetInstance()
        {
            if(BugReportLogger.instance == null)
            {
                lock(padlock)
                {
                    if(instance == null)
                        instance = new BugReportLogger();
                }
            }
            return instance;
        }

        internal void AddBugReport(BugReport bugReport)
        {
            bugReportRepository.Create(bugReport);
        }


        public List<BugReportLogger> bugReportLoggerB;
        public BugReportRepository bugReportRepository = new BugReportRepository();
    }
}