using Hospital.Exception;
using Model;
using Service;
using System;

namespace Controller
{
    public class UserController
    {
       

        public void Logout(int userId)
        {
            throw new NotImplementedException();
        }

        public User UpdateUserInformation(User user)
        {
            throw new NotImplementedException();
        }

        public BugReport CreateBugReport(BugReport bugReport, BugReportLogger bugReportLogger)
        {
            throw new NotImplementedException();
        }

        public void DeactivateAccount(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserInformation(int userId)
        {
            throw new NotImplementedException();
        }

        public UserService userService;

    }
}