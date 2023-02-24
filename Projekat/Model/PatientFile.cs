using System;
using System.Collections.Generic;

namespace Model
{
   public class PatientFile
   {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public String Diseases { get; set; }
        public String ChronicDiseases { get; set; }
        public List<Therapy> Therapies { get; set; }
        //public Patient Patient { get; set; }
      
      
        public PatientFile() { }

        public PatientFile(int id, String diseases, String chronicDiseases, List<Therapy> therapies)
        {
            Id = id;
            Diseases = diseases;
            ChronicDiseases = chronicDiseases;
            Therapies = therapies;
            //Patient = patient;
        }
   
        public PatientFile(PatientFile patientFile)
        {
            Id = patientFile.Id;
            Diseases = patientFile.Diseases;
            ChronicDiseases = patientFile.ChronicDiseases;
            Therapies = patientFile.Therapies;
            //Patient = patientFile.Patient;
        }

        public override bool Equals(object obj)
        {
            return obj is PatientFile file &&
                   Id == file.Id;
        }
    }
}