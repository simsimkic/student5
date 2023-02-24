using Hospital.Exception;
using Hospital.Model;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class PatientController
    {


        public void UpdatePatient(Patient patient)
        {
            try
            {
                patientService.UpdatePatient(patient);
            }
            catch (InvalidUserException e)
            {
                throw new InvalidUserException();
            }
        }

        public PatientFile GetPatientFileByPatient(Patient patient)
        {
            return this.patientService.GetPatientFileByPatient(patient);
        }
        public PatientFile UpdatePatientFile(Patient patient)
        {
            try
            {
                patientService.UpdatePatient(patient);
                return patient.PatientFile;
            } catch (InvalidUserException e)
            {
                throw new InvalidUserException();
            }
        }

        public void DeactivatePatient(Patient patient)
        {
            try
            {
                patientService.DeactivatePatient(patient);
            } catch (InvalidUserException e)
            {
                throw new InvalidUserException();
            }
        }

        public void HospitalizePatient(Patient patient, Room room)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetPatientNotifications(int patientId)
        {
            throw new NotImplementedException();
        }

        public string PatientLogin(string email, string password)
        {
            try
            {
                patientService.PatientLogin(email, password);
            }
            catch (InvalidEmailException e)
            {
                return e.Message;
            }
            catch (EmptyFieldException e)
            {
                return "Invalid input in field: " + e.FieldName;
            } catch (InvalidUserException e)
            {
                return "There is not user with such credentials.";
            }
            return "Successfull login!";
        }

        public String PatientRegistration(Patient patient)
        {
            try
            {
                patientService.PatientRegistration(patient);
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

        public String CalculatePatientReportForOperationsAndAppointments(Patient patient, DateTime start, DateTime end)
        {
            try
            {
                UtilityService.CheckUserForNull(patient);
                PatientReport patientReport = new PatientReport(patient, start, end);
                return patientReport.ToString();
            }
            catch (InvalidUserException e) 
            {
                return e.Message;
            }
        }


        public Patient GetPatientInformation(int patientId)
        {
            return patientService.GetPatientInformation(patientId);
        }

        public PatientService patientService = new PatientService();
        public AppointmentService appointmentService = new AppointmentService();
        public UserService userService = new UserService();
    }
}