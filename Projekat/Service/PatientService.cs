using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{   
    public class PatientService
    {

        public PatientFile GetPatientFileByPatient(Patient patient)
        {
            return this.patientFileService.GetPatientFileByPatient(patient);
        }

        public PatientFile UpdatePatientFile(PatientFile patientFile, PatientFile newPatientFile)
        {
            throw new NotImplementedException();
        }

        public void UpdatePatient(Patient patient)
        {
            UtilityService.CheckUserForNull(patient);
            userService.ValidateRegistrationInformation(patient);
            patientRepository.Update(patient);
        }

        public void DeactivatePatient(Patient patient)
        {
            appointmentRepository.CancelAppointmentsForPatient(patient);
            patient = MarkPatientAsInactive(patient);
            patientRepository.Update(patient);
        }

        private Patient MarkPatientAsInactive(Patient patient)
        {
            patient.Active = false;
            return patient;
        }

        public void HospitalizePatient(Patient patient, Room room)
        {
            throw new NotImplementedException();
        }


        public Feedback CreateFeedback(Appointment appointment, String comment, double grade)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetPatientNotifications(Patient patient)
        {
            throw new NotImplementedException();
        }

        public void PatientLogin(string email, string password) {
            userService.Login(email, password);
            Patient patient = patientRepository.GetByEmailAndPassword(email, password);
            UtilityService.CheckUserForNull(patient);
        }
        
        public Patient PatientRegistration(Patient patient)
        {
            userService.ValidateRegistrationInformation(patient);
            InitializeFields(ref patient);
            utilityService.ValidatePersonalNumberUniquePatient(patient.PersonalNumber);
            patientRepository.Create(patient);
            return patient;
        }


        public void InitializeFields(ref Patient patient)
        {
            patient.Active = true;
            patient.PatientFile = new PatientFile();
            patient.Hospitalized = false;
            patient.SickRoom = null;
        }

        public Boolean IsFeedbackMessageValid(String messega)
        {
            throw new NotImplementedException();
        }

        public Boolean IsFeedbackGradeValid(float grade)
        {
            throw new NotImplementedException();
        }


        public Patient GetPatientInformation(int patientId)
        {
            return patientRepository.GetById(patientId);
        }

        public PatientFileService patientFileService = new PatientFileService();
        public UserService userService = new UserService();
        public UtilityService utilityService = new UtilityService();
        public NotificationPatientRepository notificationPatientRepository = new NotificationPatientRepository();
        public AppointmentRepository appointmentRepository = new AppointmentRepository();
        public PatientRepository patientRepository = new PatientRepository();

    }

}