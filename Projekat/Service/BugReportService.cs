using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class BugReportService
    {
        public void CreateBugReport(BugReport bugReport)
        {
            BugReportLogger logger = BugReportLogger.GetInstance();
            logger.AddBugReport(bugReport);
        }

        public List<BugReport> GetAllBugReports()
        {
            throw new NotImplementedException();
        }

        public BugReportRepository bugReportRepository = new BugReportRepository();

    }
}