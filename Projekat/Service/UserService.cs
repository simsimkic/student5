using Hospital.Exception;
using Model;
using Repository;
using System;
using System.Text.RegularExpressions;

namespace Service
{
    public class UserService
    {
        public void Login(String email, String password)
        {
            ValidateLoginInformation(email, password);
        }

        public User UpdateUserInformation(User user)
        {
            throw new NotImplementedException();
        }

        public void ValidateLoginInformation(String email, String password)
        {
            if (!(UtilityService.IsEmailValid(email))) throw new InvalidEmailException();
            if (String.IsNullOrEmpty(password)) throw new EmptyFieldException();
        }

        public User GetUserInformation(User user)
        {
            throw new NotImplementedException();
        }

        public void ValidateRegistrationInformation(User user)
        {   
            if (String.IsNullOrEmpty(user.Name)) throw new EmptyFieldException("Name");
            if (String.IsNullOrEmpty(user.Surname)) throw new EmptyFieldException("Surname");
            if (String.IsNullOrEmpty(user.PhoneNumber)) throw new EmptyFieldException("PhoneNumber");
            if (String.IsNullOrEmpty(user.Password)) throw new EmptyFieldException("Password");
            if (!(UtilityService.IsPersonalNumberValid(user.PersonalNumber))) throw new JmbgInvalidException();
            if (!(UtilityService.IsEmailValid(user.Email))) throw new InvalidEmailException();
        }


        public void InitializeFields(ref User user)
        {
            user.Active = true;
        }
        public UserRepository userRepository;

    }
}