using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class DrugApprovalRequestController
   {
        public String CreateRequest(DrugApprovalRequest drugApprovalRequest)

        {
            try
            {
                drugApprovalRequestService.CreateDrugApprovalRequest(drugApprovalRequest);
                return "Uspesno napravljen zahtev!";
            }
            catch (EmptyFieldException e)
            {
                return e.FieldName + "must not be empty";
            }
            catch (DrugNameNotUniqueException e)
            {
                return "This drug is already approved!";
            }
            catch (DrugQuantityException e)
            {
                return "Drug quantity invalid";
            }
            
        }
        public DrugApprovalRequest GetRequest(int requestId)
      {
            return this.drugApprovalRequestService.GetDrugApprovalRequest(requestId);
      }

        public String ConfirmRequest(int requestId, Doctor doctor)
        {
            try
            {
                DrugApprovalRequest drugApproval = GetRequest(requestId);
                this.drugApprovalRequestService.ConfirmDrugApprovalRequest(drugApproval, doctor);
                return "Successfuly confirmed request";
            }
            catch(InvalidDrugConfirmationException e)
            {
                return e.Message;
            }
      }

      public DrugApprovalRequest UpdateRequest(int requestId, Doctor doctor)
      {
            DrugApprovalRequest approvalRequest = GetRequest(requestId);
            return this.drugApprovalRequestService.UpdateDrugApprovalRequest(approvalRequest, doctor);
      }
      
      public List<DrugApprovalRequest> GetAll()
      {
         throw new NotImplementedException();
      }
        public DrugApprovalRequestService drugApprovalRequestService = new DrugApprovalRequestService();
   }
}