using System;

namespace Model
{
    public class BugReport
    {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public String PageWithBug { get; set; }
        public String BugDetail { get; set; }
        public User User { get; set; }
        public BugReportLogger BugReportLogger { get; set; }

        public BugReport()
        {
        }

        public BugReport(int id, string pageWithBug, string bugDetail, User user, BugReportLogger bugReportLogger)
        {
            Id = id;
            PageWithBug = pageWithBug;
            BugDetail = bugDetail;
            User = user;
            BugReportLogger = bugReportLogger;
        }

        public BugReport(BugReport bugReport)
        {
            Id = bugReport.Id;
            PageWithBug = bugReport.PageWithBug;
            BugDetail = bugReport.BugDetail;
            User = bugReport.User;
            BugReportLogger = bugReport.BugReportLogger;
        }

        public override bool Equals(object obj)
        {
            return obj is BugReport report &&
                   Id == report.Id;
        }
    }
}