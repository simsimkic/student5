using Model;
using Repository;
using System;

namespace Service
{
   public class PatientFileService
   {
      public PatientFile GetPatientFileByPatient(Patient patient)
      {
            return this.patientFileRepository.GetPatientFileByPatientId(patient.Id);
      }
      
      public PatientFile UpdatePatientFile(PatientFile patientFile)
      {
         throw new NotImplementedException();
      }
      
      public PatientFileRepository patientFileRepository = new PatientFileRepository();
      public TherapyService therapyService;
   
   }
}