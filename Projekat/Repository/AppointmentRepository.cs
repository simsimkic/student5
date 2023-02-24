using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class AppointmentRepository : GenericRepository<Appointment>
    {
        public List<Appointment> GetAppointmentsByTime(DateTime time)
        {
            throw new NotImplementedException();
        }


        public List<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            List<Appointment> appointments = GetAll();
            List<Appointment> appointmentsForDoctor = new List<Appointment>();
            foreach (Appointment appointment in appointments)
                if (appointment.Doctor != null)
                    if(appointment.Doctor.Id == doctorId) appointmentsForDoctor.Add(appointment);
            return appointmentsForDoctor;
        }

        public List<Appointment> GetAllScheduledAppointments()
        {
            List<Appointment> scheduledAppointemts = new List<Appointment>();
            foreach (Appointment appointment in GetAll())
                if (appointment.IsInFuture())
                    scheduledAppointemts.Add(appointment);

            return scheduledAppointemts;
        }

        public void CancelAppointmentsForPatient(Patient patient)
        {
            foreach (Appointment appointment in GetAppointmentsForPatient(patient))
                Delete(appointment.Id);
        }

        public List<Appointment> GetAppointmentsForPatient(Patient patient)
        {
            List<Appointment> appointmentsForPatient = new List<Appointment>();

            foreach (Appointment appointment in GetAll())
                if (appointment.BelongsToPatient(patient))
                    appointmentsForPatient.Add(appointment);

            return appointmentsForPatient;
        }

        public List<Appointment> GetPatientScheduledAppointments(Patient patient)
        {
            List<Appointment> PatientScheduledAppointments = new List<Appointment>();

            foreach (Appointment appointment in GetAppointmentsForPatient(patient))
                if (appointment.IsInFuture())
                    PatientScheduledAppointments.Add(appointment);

            return PatientScheduledAppointments;

        }
    }
}