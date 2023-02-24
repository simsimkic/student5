using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Model
{
    class PatientReport
    {
        public AppointmentRepository appointmentRepository = new AppointmentRepository();
        public int NumberOfOperations { get; set; }
        public int NumberOfAppointments { get; set; }
        public Patient Patient { get; set; }
        public  DateTime StartingPoint { get; set; }
        public DateTime EndingPoint { get; set; }
        public List<Appointment> FilteredAppointments { get; set; }


        public PatientReport(Patient patient, DateTime start, DateTime end)
        {
            Patient = patient;
            StartingPoint = start;
            EndingPoint = end;
            NumberOfOperations = 0;
            NumberOfAppointments = 0;
            FilteredAppointments = new List<Appointment>();
            FilterApppointments();
            CalculateReport();
        }

        void FilterApppointments()
        {
            foreach (Appointment appointment in appointmentRepository.GetAppointmentsForPatient(Patient))
            {
                if (appointment.InRange(StartingPoint, EndingPoint))
                    FilteredAppointments.Add(appointment);
            }             
        }

        void CalculateReport()
        {
            foreach (Appointment appointment in FilteredAppointments)
            {
                if (appointment.Operation)
                    NumberOfOperations++;
                else
                    NumberOfAppointments++;
            }
        }

        public override string ToString()
        {
            return "Patient Report for you: " + Patient.Name + " " + Patient.Surname + ". You had " + NumberOfOperations.ToString() +
                " operations and " + NumberOfAppointments.ToString() + " appointments. Calculation was applied on period from " + StartingPoint.ToString() +
                " to " + EndingPoint.ToString();
        }
    }
}
