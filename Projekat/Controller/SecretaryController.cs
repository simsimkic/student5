using Hospital.Exception;
using Model;
using Service;
using System;

namespace Controller
{
   public class SecretaryController
   {
      public String SecretaryRegistration(Secretary secretary)
      {
            try
            {
                secretaryService.SecretaryRegistration(secretary);
                return "Successful registration";
            }
            catch (EmptyFieldException e)
            {
                return "Field " + e.FieldName + " must not be empty";
            }
            catch (JmbgInvalidException e)
            {
                return "JMBG must contain exactly 13 digits";
            }
            catch (JmbgNotUniqueException e)
            {
                return "JMBG not unique";
            }
            catch(InvalidEmailException e)
            {
                return "Invalid email";
            }
      }
      public NotificationDoctor SendNotificationToDoctor(DateTime emergencyTime, int doctorId)
      {
         throw new NotImplementedException();
      }
      
      public NotificationPatient SendNotificationToPatient(int patientId)
      {
         throw new NotImplementedException();
      }
      

        public String UpdateSecretary(Secretary secretary)
        {
            try
            {
                secretaryService.UpdateSecretaryAccount(secretary);
                return "Succesful update";
            }
            catch (InvalidEmailException e)
            {
                return "Invalid email";
            }
            catch (EmptyFieldException e)
            {
                return "Field " + e.FieldName + " must not be empty";
            }
            catch (JmbgInvalidException e)
            {
                return "JMBG must contain exactly 13 digits";
            }
            catch (JmbgNotUniqueException e)
            {
                return "JMBG not unique";
            }
            catch(InvalidUserException e)
            {
                return "Invalid user";
            }
            
        }

      public SecretaryService secretaryService = new SecretaryService();
   
   }
}