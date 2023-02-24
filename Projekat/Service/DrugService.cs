using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class DrugService
    {
        public List<Drug> GetAllDrugs()
        {
            return drugRepository.GetAll();
        }

        public String GetDrugInfo(Drug drug)
        {
            throw new NotImplementedException();
        }

        public Boolean IsDrugInformationValid()
        {
            throw new NotImplementedException();
        }

        public Boolean IsDrugNameValid()
        {
            throw new NotImplementedException();
        }

        public Boolean IsDrugQuantityValid()
        {
            throw new NotImplementedException();
        }
        
        public void ValidateDrugInformation(Drug drug)
        {
            if (String.IsNullOrEmpty(drug.DrugInformation)) throw new EmptyFieldException("Drug Information");
            if (!IsDrugNameUnique(drug.Name)) throw new DrugNameNotUniqueException();
            //MOZDA NEKA METODA U UTILITYSERVICE - QUANTITY NOT VALID!
            if (drug.Quantity < 1) throw new DrugQuantityException();
        }

        private bool IsDrugNameUnique(String drugName)
        {
            drugName = drugName.ToUpper();
            List<Drug> allDrugs = drugRepository.GetAll();
            foreach (Drug drug in allDrugs)
            {
                if (drugName.Equals(drug.Name.ToUpper())) return false;
            }
            return true;
        }

        public Drug CreateDrug(Drug drug)
        {
            return drugRepository.Create(drug);
        }
        public Drug UpdateDrug(Drug drug)
        {
            return drugRepository.Update(drug);
        }

        public DrugRepository drugRepository = new DrugRepository();

    }
}