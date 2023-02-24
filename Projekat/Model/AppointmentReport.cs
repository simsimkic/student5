using System;
using System.Net.Sockets;

namespace Model
{
    public class AppointmentReport
    {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public String Opinion { get; set; }
        public String Diagnosis { get; set; }
        public String Disease { get; set; }
        public String ChronicDisease { get; set; }
        public Therapy Therapy { get; set; }
        public Appointment Appointment { get; set; }

        public AppointmentReport()
        {
        }

        public AppointmentReport(int id, string opinion, string diagnosis, string disease, string chronicDisease, Therapy therapy, Appointment appointment)
        {
            Id = id;
            Opinion = opinion;
            Diagnosis = diagnosis;
            Disease = disease;
            ChronicDisease = chronicDisease;
            Therapy = therapy;
            Appointment = appointment;
        }

        public AppointmentReport(AppointmentReport appointmentReport)
        {
            Id = appointmentReport.Id;
            Opinion = appointmentReport.Opinion;
            Diagnosis = appointmentReport.Diagnosis;
            Disease = appointmentReport.Disease;
            ChronicDisease = appointmentReport.ChronicDisease;
            Therapy = appointmentReport.Therapy;
            Appointment = appointmentReport.Appointment;
        }


    }
}