using Model;
using Repository;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class TherapyController
    {
        public List<Therapy> GetTherapiesForPatient(Patient patient)
        {
            try
            {
                UtilityService.CheckUserForNull(patient);
                return patient.PatientFile.Therapies;
            } catch (InvalidUserException e)
            {
                throw new InvalidUserException();
            }
            
        }

        public Therapy CreateTherapy(List<Drug> drugs, Boolean prescribed)
        {
            Therapy therapy = this.therapyService.CreateTherapy(drugs, prescribed);
            Console.WriteLine("Therapy successfuly created.");
            return therapy;
        }

        public TherapyService therapyService = new TherapyService();
    }
}