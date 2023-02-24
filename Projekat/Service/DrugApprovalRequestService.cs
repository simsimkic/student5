using Model;
using System;
using Repository;
using System.Collections.Generic;

namespace Service
{
   public class DrugApprovalRequestService
   {
      public void CreateDrugApprovalRequest(DrugApprovalRequest drugApprovalRequest)
        {
            //da li ce Nebojsa da postavi inicijalizuje liste iz DrugA?
            drugService.ValidateDrugInformation(drugApprovalRequest.Drug);
            InitializeFields(ref drugApprovalRequest);
            drugApprovalRequestRepository.Create(drugApprovalRequest);
        }
      private void InitializeFields(ref DrugApprovalRequest drugApprovalRequest)
        {
            drugApprovalRequest.ApprovedByDoctors = new List<Doctor>();
            drugApprovalRequest.NumberOfConfirmation = 0;
        }
      public List<DrugApprovalRequest> GetAll()
      {
         throw new NotImplementedException();
      }


        public Boolean HasDoctorUpdatedRequest(DrugApprovalRequest request, Doctor doctor)
        {
            Boolean doctorExists = false;
            for (int i = 0; i < request.ApprovedByDoctors.Count; i++)
                if (request.ApprovedByDoctors[i].Id == doctor.Id)
                    doctorExists = true;
            return doctorExists;
        }      
      public DrugApprovalRequest UpdateDrugApprovalRequest(DrugApprovalRequest request, Doctor doctor)
      {
            DrugApprovalRequest updatedRequest = this.drugApprovalRequestRepository.GetById(request.Id);
            Boolean doctorExists = false;
            for (int i = 0; i < updatedRequest.ApprovedByDoctors.Count; i++)
                if (updatedRequest.ApprovedByDoctors[i].Id == doctor.Id)
                    doctorExists = true;
            if (!doctorExists)
            {
                updatedRequest = request;
                updatedRequest.ApprovedByDoctors.Clear();
                updatedRequest.ApprovedByDoctors.Add(doctor);
                updatedRequest.NumberOfConfirmation = 0;
                this.drugApprovalRequestRepository.Update(updatedRequest);
                Console.WriteLine("Successfuly updated!");
                return updatedRequest;
            }

            return null;
            
      }
      
      public void DeleteDrugApprovalRequest(DrugApprovalRequest drugApprovalRequest)
      {
            this.drugApprovalRequestRepository.Delete(drugApprovalRequest.Id);
      }
      
      public DrugApprovalRequest GetDrugApprovalRequest(int requestId)
      {
            return this.drugApprovalRequestRepository.GetById(requestId);
      }
      
      public void ConfirmDrugApprovalRequest(DrugApprovalRequest request, Doctor doctor)
      {
            DrugApprovalRequest confirmedRequest = this.drugApprovalRequestRepository.GetById(request.Id);
            if(!HasDoctorUpdatedRequest(confirmedRequest, doctor))
            {
                confirmedRequest.ApprovedByDoctors.Add(doctor);
                confirmedRequest.NumberOfConfirmation++;
                if (confirmedRequest.NumberOfConfirmation >= 2)
                {
                    DeleteDrugApprovalRequest(confirmedRequest);
                    confirmedRequest.Drug.Approved = true;
                    this.drugService.CreateDrug(confirmedRequest.Drug);
                }
                else
                    this.drugApprovalRequestRepository.Update(confirmedRequest);
            }
      }
      
      public Repository.DrugApprovalRequestRepository drugApprovalRequestRepository = new Repository.DrugApprovalRequestRepository();
      public DrugService drugService = new DrugService();
   
   }
}