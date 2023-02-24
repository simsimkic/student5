using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class DrugController
    {
        public List<Drug> GetAllDrugs()
        {
            return drugService.GetAllDrugs();
        }

        public String GetDrugInfo(int drugId)
        {
            throw new NotImplementedException();
        }

        public DrugService drugService = new DrugService();

    }
}