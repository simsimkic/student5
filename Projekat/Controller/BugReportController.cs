using Model;
using Service;
using System;

namespace Controller
{
   public class BugReportController
   {
      public void CreateBugReport(BugReport bugReport)
      {
            bugReportService.CreateBugReport(bugReport);
      }
      
      public BugReportService bugReportService = new BugReportService();
   
   }
}