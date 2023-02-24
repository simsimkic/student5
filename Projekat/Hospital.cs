using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital
{
    class Hospital
    {
        static public void Main(String[] args)
        {




            Repository.DoctorRepository doctorRepository = new Repository.DoctorRepository();
            Repository.AppointmentRepository appointmentRepository = new Repository.AppointmentRepository();
            Repository.PatientRepository patientRepository = new Repository.PatientRepository();
            Controller.AppointmentController appointmentController = new Controller.AppointmentController();
            Controller.PatientController patientController = new Controller.PatientController();
            Controller.TherapyController therapyController = new Controller.TherapyController();
            Controller.FeedbackController feedbackController = new Controller.FeedbackController();
            Controller.DoctorController doctorController = new DoctorController();
            SecretaryController secretaryController = new SecretaryController();
            GuestController guestController = new GuestController();
            InventoryItemController inventoryItemController = new InventoryItemController();
            DrugController drugController = new DrugController();
            DrugApprovalRequestController drugApprovalRequestController = new DrugApprovalRequestController();
            NotificationPatientController notificationPatientController = new NotificationPatientController();
            Repository.NotificationPatientRepository notificationPatientRepository = new Repository.NotificationPatientRepository();


            // PALO
            //init Patient
            List<Appointment> lista = new List<Appointment>();
            Address address = new Address();
            List<BugReport> bugReport = new List<BugReport>();
            User user = new User("Aleksandar", "Sharovich", "1234567854324", "123124", "email@aa.ba", "strongpass", true, address, bugReport);

            List<Therapy> terapije = new List<Therapy>();
            List<Drug> lijekovi = new List<Drug>();
            lijekovi.Add(new Drug(0, "brufen1", 10, "infodrug", null, null, false, false));

            terapije.Add(new Therapy(false, lijekovi));
            PatientFile patientFile = new PatientFile(0, "bolest1", "chronic1", terapije);
            Patient patient = new Patient(150, false, lista, patientFile, null, user);
            patientController.PatientRegistration(patient);

            // init Doctor and Specialist Doctor
            User userDoc = new User("Nebojsha", "Enjev", "0541687321459", "845214", "NebEnje@uns.ac.rs", "strongestpass", true, address, bugReport);
            Doctor doctor = new Doctor(0, false, new WorkingTime(), userDoc);
            doctorController.DoctorRegistration(doctor);
            doctor.Specialist = true;
            doctor.PersonalNumber = "6872140563214";
            doctorController.DoctorRegistration(doctor);

            //init Secretary
            User userSec = new User("Sara", "Popov", "0278463218654", "66745", "capa@gmail.com", "sifrasifra12", true, address, bugReport);
            Secretary secretary = new Secretary(0, new WorkingTime(), new List<NotificationFactory>(), userSec);
            secretaryController.SecretaryRegistration(secretary);

            //init Guest
            Guest guest = new Guest(0, "Micha", "Veljun", "0205221368741", "025668", new GuestAppointment());
            guestController.CreateGuest(guest);



            // init appointment, emergency appointment and operation appointment
            Appointment appointment = new Appointment();
            appointment.Completed = false;
            appointment.Duration = new TimeSpan(0, 15, 0);
            appointment.Time = new DateTime(2020, 12, 12, 13, 0, 0);
            appointment.Patient = patientRepository.GetById(0);
            appointment.Doctor = doctorRepository.GetById(1);
            appointmentController.CreateAnAppointment(appointment);
            appointment.Time = new DateTime(2020, 12, 16, 13, 0, 0);
            appointmentController.CreateEmergencyAppointment(appointment);
            appointment.Time = new DateTime(2020, 12, 20, 13, 0, 0);
            //appointmentController.CreateOperationAppointment(appointment);
            //available doctors for periods
            //List<(DateTime,DateTime,Doctor)> availablePeriods = appointmentController.PriorityTimeForAppointment(new DateTime(2020, 12, 12, 12, 0, 0), new DateTime(2020, 12, 12, 14, 0, 0));

            //available periods for doctor
            List<(DateTime, DateTime, Doctor)> availableDoctors = doctorController.PriorityDoctorForAppointment(new DateTime(2020, 12, 12, 12, 0, 0), new DateTime(2020, 12, 12, 14, 0, 0), doctorRepository.GetById(0));
            foreach (var doc in availableDoctors)
            {
                Console.WriteLine(doc.Item3.Name +"\t"+ doc.Item1.ToString() +"\t"+ doc.Item2.ToString());
            }


            // test za buduce preglede
            List<Appointment> l = appointmentController.GetPatientScheduledAppointments(patientRepository.GetById(0));
            foreach (Appointment o in l)
            {
                Console.WriteLine(o.Time.ToString() + "BUDUCI");
            }

            

            // test za sve preglede pacijenta
            List<Appointment> l2 = appointmentController.GetAppointmentsForPatient(patientRepository.GetById(0));
            foreach (Appointment o in l2)
            {
                Console.WriteLine(o.Time.ToString() + "SVI");
            }


            // test za sve preglede doktora
            List<Appointment> lD = appointmentController.GetAppointmentsForDoctor(doctorRepository.GetById(1));
            foreach (Appointment o in lD)
            {
                Console.WriteLine(o.Time.ToString() + "SVI DOKTORI");
            }
            
            // test za izvjestaj pacijenta

            String patientReport = patientController.CalculatePatientReportForOperationsAndAppointments(patientRepository.GetById(0), new DateTime(2020, 12, 12, 9, 0, 0), new DateTime(2020, 12, 12, 14, 0, 0));
            Console.WriteLine(patientReport + "\n");


            // test za prikaz svih terapija pacijenta
            List<Therapy> l3 = therapyController.GetTherapiesForPatient(patientRepository.GetById(0));
            foreach (var item in l3)
            {
                Console.WriteLine(item.Prescribed);
            }


            // test za deaktivaciju pacijenta
            // patientController.DeactivatePatient(patientRepository.GetById(0));

            // test za login pacijenta
            Console.WriteLine(patientController.PatientLogin("email@aa.ba", "strongpass"));

            // test za kreiranje feedbacka
            //Feedback feedback = new Feedback(0, "dobar je ovaj doktor", 3, appointmentRepository.GetById(0));
            //feedbackController.CreateFeedback(feedback);
            //Console.WriteLine(feedbackController.GetFeedbacksByDoctor(doctorRepository.GetById(1)));

            // test za otkazivanje pregleda pacijenta
            Appointment cancelAppointment = new Appointment();
            cancelAppointment.Id = 1;
            cancelAppointment.Time = new DateTime(2020, 12, 20, 13, 0, 0);
            cancelAppointment.Patient = patientRepository.GetById(0);
            Console.WriteLine(appointmentController.CancelAppointment(cancelAppointment));

            //appointmentController.PatientCancelAppointment(appointmentRepository.GetById(3));

            // test za pregled svih appointmenta
            List<Appointment>  appointments =  appointmentController.GetAllScheduledAppointments();
            foreach (var item in appointments)
            {
                Console.WriteLine(item.Emergency);
            }

            
            RoomController roomController = new RoomController();
            InventoryItem inventoryItem1 = new InventoryItem(0, "stvar1");
            InventoryItem inventoryItem2 = new InventoryItem(0, "stvar2");
            InventoryItem inventoryItem3 = new InventoryItem(0, "stvar3");
            List<InventoryItem> lista2 = new List<InventoryItem>();
            List<InventoryItem> listaa = new List<InventoryItem>();

            lista2.Add(inventoryItem1);
            lista2.Add(inventoryItem2);
            lista2.Add(inventoryItem3);
            listaa.Add(inventoryItem3);

            //pravljenje warehouse
            Room warehouse = new Room(0, 300, RoomType.warehouse, 25, null, null, null, null);
            roomController.CreateRoom(warehouse);
            //narucivanje stvari
            inventoryItemController.OrderInventoryItems(lista2);


            Room room = new Room(0, 25, RoomType.sickRoom, 5, null, null, null, null);
            Room roomForMerge = new Room(0, 35, RoomType.office, 15, null, null, null, null);


            List<Room> roomsForMerge = new List<Room>();
            roomsForMerge.Add(room);
            roomsForMerge.Add(roomForMerge);
            roomController.CreateRoom(room);
            roomController.CreateRoom(roomForMerge);
            //premestanje stvari po sobama
            roomController.RearangeInventory(warehouse, room, 1, listaa);
            //deljenje sobe
            roomController.DivideRoom(room, 7);
            //spajanje soba
            roomController.MergeRooms(roomsForMerge);

            //Unosenje pristiglih lekova
            drugController.GetAllDrugs();
            List<String> purpose = new List<String>();
            purpose.Add("Glavobolja");
            purpose.Add("Rukobolja");
            Drug drug0 = new Drug(0, "Paraceta", 16, "Leci sve", purpose, null);
            Repository.DrugRepository drugRepository = new Repository.DrugRepository();
            //drugRepository.Create(drug0);
            Drug drug = new Drug(0, "Aspirin", 3, "to ti je za glavu", purpose, null);
            Drug drug1 = new Drug(0, "BruFenKo", 5, "to ti je za glavu", purpose, null);
            //drugController.drugService.ValidateDrugInformation(drug1);
            DrugApprovalRequest drugApprovalRequest = new DrugApprovalRequest();
            drugApprovalRequest.Drug = drug1;
            Console.WriteLine((drugApprovalRequestController.CreateRequest(drugApprovalRequest)));


            //Update requesta
            //drugApprovalRequestController.UpdateRequest(0, doctorRepository.GetById(0));
            //Potvrdjivanje requesta
            //drugApprovalRequestController.ConfirmRequest(0, doctorRepository.GetById(0));
            //drugApprovalRequestController.ConfirmRequest(0, doctorRepository.GetById(1));

            // test za update korisnika
            Patient patient3 = patientRepository.GetById(0);
            patient3.Email = "najnoviji@mail.ba";
            patientController.UpdatePatient(patient3);

            // test za notifikacije pacijenta
            NotificationPatient np = new NotificationPatient(1, new DateTime(2021, 1, 1, 12, 0, 0), new DateTime(2021, 1, 1, 18, 0, 0), patientRepository.GetById(0));
            notificationPatientRepository.Create(np);
            List<NotificationPatient> lp =  notificationPatientController.GetNotificationForPatient(patientRepository.GetById(0));

            // test za deaktivaciju pacijenta
            //patientController.DeactivatePatient(patientRepository.GetById(0));
        
            
        }
    }
}