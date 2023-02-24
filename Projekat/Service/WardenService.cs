using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class WardenService
    {
        public void WardenLogin(string email, string password)
        {
            userService.Login(email, password);
            Warden warden = wardenRepository.GetByEmailAndPassword(email, password);
            UtilityService.CheckUserForNull(warden);
        }
 
        public String GetReport()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public void UpdateWarden(Warden warden)
        {
            UtilityService.CheckUserForNull(warden);
            userService.ValidateRegistrationInformation(warden);
            wardenRepository.Update(warden);
        }
        public WardenRepository wardenRepository = new WardenRepository();
        public WorkingTimeService workingTimeService = new WorkingTimeService();
        public UserRepository userRepository = new UserRepository();
        public UserService userService = new UserService();
    }
}