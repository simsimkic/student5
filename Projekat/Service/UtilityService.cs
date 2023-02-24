using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Service
{
    public class UtilityService
    {
        PatientRepository patientRepository = new PatientRepository();
        DoctorRepository doctorRepository = new DoctorRepository();
        SecretaryRepository secretaryRepository = new SecretaryRepository();

        public static void ValidateWorkingTime(WorkingTime workingTime)
        {
            
        }
        public static void ValidateSelectedTime(DateTime dateTime)
        {
            DateTime current = DateTime.Now;
            int result = DateTime.Compare(current, dateTime);
            if (result >= 0)
                throw new Hospital.Exception.InvalidDateException("You entered the date in past");
        }
        public static bool isMaxInventoryItemsValid(Room room)
        {
            return room.MaxInventoryItems < 1 || room.MaxInventoryItems > 1000 || room.MaxInventoryItems.Equals(null);
        }
        public static bool isRoomSizeValid(Room room)
        {
            return room.Size < 1 || room.Size > 500 || room.Size.Equals(null);
        }

        public static void ValidateDurationTimeValid(TimeSpan duration)
        {
            if (duration < new TimeSpan(0, 0, 0) | duration > new TimeSpan(12, 0, 0))
                throw new InvalidDurationException("You entered invalid duration");
        }

        public static void CheckUserForNull(User user)
        {
            if (user == null)
                throw new InvalidUserException("User is invalid.");
        }

        public void ValidatePersonalNumberUnique(User user)
        {
            if (user.GetType() == typeof(Doctor) && doctorRepository.GetAll() != null)
            {
                foreach (Doctor doctor in doctorRepository.GetAll())
                {
                    if (doctor.PersonalNumber.Equals(user.PersonalNumber)) throw new JmbgNotUniqueException();
                }
            }
            else if(user.GetType() == typeof(Secretary) && secretaryRepository.GetAll() != null)
            {
                foreach (Secretary secretary in secretaryRepository.GetAll())
                {
                    if (secretary.PersonalNumber.Equals(user.PersonalNumber)) throw new JmbgNotUniqueException();
                }
            }
        }

        public static bool isRoomTypeValid(Room room)
        {
            return room.Type.GetType() != typeof(RoomType);
        }

        internal static bool IsTimeValidForCancel(DateTime time)
        {
            return (time > DateTime.Now.AddDays(2));
        }

        public void ValidatePersonalNumberUniquePatient(String personalNumber)
        {
            foreach (Patient patient in patientRepository.GetAll())
            {
                if (patient.PersonalNumber.Equals(personalNumber)) throw new JmbgNotUniqueException();
            }
        }


        public static bool IsPersonalNumberValid(string personalNumber)
        {
            return new Regex(@"[0-9]{13}").IsMatch(personalNumber);
        }

        public static Boolean IsPasswordStrong(String password)
        {
            throw new NotImplementedException();
        }

        public static Boolean IsEmailValid(String email)
        {
            return new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").IsMatch(email);
        }

        public static Boolean IsPhoneNumberValid(String phoneNumber)
        {
            throw new NotImplementedException();
        }

        public static Boolean IsCharOnlyField(String checkString)
        {
            throw new NotImplementedException();
        }

        public static Boolean IsEmptyField(String field)
        {
            throw new NotImplementedException();
        }

        public static bool IsCommentTooLong(string comment)
        {
            return (comment.Length > 2000);
        }

        public static bool IsInGradeRange(int grade)
        {
            return ((grade > 0) & (grade <= 10));
        }


    }
}