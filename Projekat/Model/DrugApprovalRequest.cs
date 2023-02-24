using System;
using System.Collections.Generic;

namespace Model
{
    public class DrugApprovalRequest
    {
        public static int idGenerator = 0;
        public int Id { get; set; }
        public int NumberOfConfirmation { get; set; }
        public List<Doctor> ApprovedByDoctors { get; set; }
        public Drug Drug { get; set; }

        public DrugApprovalRequest()
        {
        }

        public DrugApprovalRequest(int id, int numberOfConfirmation, List<Doctor> approvedByDoctors, Drug drug)
        {
            Id = id;
            NumberOfConfirmation = numberOfConfirmation;
            ApprovedByDoctors = approvedByDoctors;
            Drug = drug;
        }
        public DrugApprovalRequest(DrugApprovalRequest drugApprovalrequest)
        {
            Id = drugApprovalrequest.Id;
            NumberOfConfirmation = drugApprovalrequest.NumberOfConfirmation;
            ApprovedByDoctors = drugApprovalrequest.ApprovedByDoctors;
            Drug = drugApprovalrequest.Drug;
        }

        public override bool Equals(object obj)
        {
            return obj is DrugApprovalRequest request &&
                   Id == request.Id;
        }
    }
}