using Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class PatientFileRepository : GenericRepository<PatientFile>
   {
      public PatientFile GetPatientFileByPatientId(int patientId)
      {
            List<PatientFile> patientFiles = GetAll();
            PatientFile file = new PatientFile();

            for(int i=0; i<patientFiles.Count; i++)
            {
                if(patientId == patientFiles[i].Id)
                {
                    file = patientFiles[i];
                }
            }
            return file;
      }
   
   }
}