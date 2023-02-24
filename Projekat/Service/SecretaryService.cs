using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class SecretaryService
    {
        public void SecretaryLogin(string email, string password)
        {
            userService.Login(email, password);
            Secretary secretary = secretaryRepository.GetByEmailAndPassword(email, password);
            UtilityService.CheckUserForNull(secretary);
        }

        public Secretary SecretaryRegistration(Secretary secretary)
        {
            userService.ValidateRegistrationInformation(secretary);
            InitializeFields(ref secretary);
            ValidateSecretaryInfo(secretary);
            utilityService.ValidatePersonalNumberUnique(secretary);
            secretaryRepository.Create(secretary);
            return secretary;
        }
        public void DeactivateSecretaryAccount(Secretary secretary)
        {
            secretary.Active = false;
            secretaryRepository.Update(secretary);
        }
        public void InitializeFields(ref Secretary secretary)
        {
            secretary.Active = true;
        }
        public void ValidateSecretaryInfo(Secretary secretary)
        {
            if (secretary.WorkingTime.Equals(null)) throw new EmptyFieldException("Working Time");
        }
        public NotificationDoctor SendNotificationToDoctor(Doctor doctor, NotificationDoctor doctorNotification)
        {
            throw new NotImplementedException();
        }

        public List<Secretary> GetAll()
        {
            return secretaryRepository.GetAll();
        }

        public NotificationPatient SendNotificationToPatient(int patientId, NotificationPatient patientNotification)
        {
            throw new NotImplementedException();
        }

        public Secretary UpdateSecretaryAccount(Secretary secretary)
        {
            UtilityService.CheckUserForNull(secretary);
            userService.ValidateRegistrationInformation(secretary);
            InitializeFields(ref secretary);
            utilityService.ValidatePersonalNumberUnique(secretary);
            secretaryRepository.Update(secretary);
            return secretary;
        }

        public UtilityService utilityService = new UtilityService();
        public UserService userService = new UserService();
        public SecretaryRepository secretaryRepository = new SecretaryRepository();
        public GuestAppointmentService guestAppointmentService = new GuestAppointmentService();
        public AppointmentService appointmentService = new AppointmentService();
        public INotification iNotification;

    }
}