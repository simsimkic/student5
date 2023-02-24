using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class TherapyService
    {
        
        public Boolean AreDrugsAvailableInWarehouse(List<Drug> requested, List<Drug> warehouseDrugs)
        {
            Boolean isDrugAvailable = true;
            for (int j = 0; j < requested.Count; j++)
            {
                int counter = 0;
                for (int i = 0; i < warehouseDrugs.Count; i++)
                {
                    if (requested[j].Name.Equals(warehouseDrugs[i].Name))
                    {
                        warehouseDrugs[i].Quantity--;
                        requested[j] = warehouseDrugs[i];
                        counter++;
                    }
                }
                if (counter == 0)
                {
                    isDrugAvailable = false;
                }
            }
            return isDrugAvailable;
        }
        public Therapy CreateTherapy(List<Drug> drugs, Boolean prescribed)
        {
            if (!prescribed)
            {
                
                List<Drug> availableDrugs = drugService.GetAllDrugs();
                if (AreDrugsAvailableInWarehouse(drugs,availableDrugs))
                {
                    for(int i=0; i<drugs.Count; i++)
                        this.drugService.UpdateDrug(drugs[i]);
                    Therapy therapy = new Therapy(false,drugs);
                    this.therapyRepository.Create(therapy);
                    return therapy;
                }
            }
            else
            {
                Therapy therapy = new Therapy(true, drugs);
                this.therapyRepository.Create(therapy);
                return therapy;
            }
            return null;
        }

        public DrugService drugService = new DrugService();
        public TherapyRepository therapyRepository = new TherapyRepository();
    }
}