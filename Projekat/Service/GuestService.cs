using Model;
using Repository;
using System;
using System.Text.RegularExpressions;

namespace Service
{
   public class GuestService
   {
      public Guest CreateGuest(Guest guest)
      {
            ValidateGuestInformation(guest);
            utilityService.ValidatePersonalNumberUniquePatient(guest.PersonalNumber);
            return guestRepository.Create(guest);
      }

        public void ValidateGuestInformation(Guest guest)
        {
            Regex regexJMBG = new Regex(@"^[0-9]{13}");
            if (String.IsNullOrEmpty(guest.Name)) throw new EmptyFieldException("Name");
            if (String.IsNullOrEmpty(guest.Surname)) throw new EmptyFieldException("Surname");
            if (String.IsNullOrEmpty(guest.PhoneNumber)) throw new EmptyFieldException("PhoneNumber");
            if (!regexJMBG.IsMatch(guest.PersonalNumber)) throw new JmbgInvalidException();
        }
      
      public Guest GetGuestInformation(int guestId)
      {
            return guestRepository.GetById(guestId);
      }
      
      public GuestRepository guestRepository = new GuestRepository();
        public UtilityService utilityService = new UtilityService();
   
   }
}