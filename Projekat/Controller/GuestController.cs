using Model;
using Service;
using System;

namespace Controller
{
   public class GuestController
   {
      public string CreateGuest(Guest guest)
      {
            try
            {
                guestService.CreateGuest(guest);
                return "success";
            }
            catch (EmptyFieldException e)
            {
                return "Field " + e.FieldName + " must not be empty";
            }
            catch (JmbgInvalidException e)
            {
                return "JMBG must contain exactly 13 digits";
            }
            catch(JmbgNotUniqueException e)
            {
                return "There is registrated patient with this personal number";
            }
        }
      
      public Guest GetGuestInformation(int guestId)
      {
            return guestService.GetGuestInformation(guestId);
      }
      
      public GuestService guestService = new GuestService();
   
   }
}