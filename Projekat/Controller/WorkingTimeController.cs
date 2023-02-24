using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class WorkingTimeController
   {
      public WorkingTime CreateWorkingTime(WorkingTime workingTime)
      {
         throw new NotImplementedException();
      }
      
      public WorkingTime UpdateWorkingTime(WorkingTime workingTime)
      {
         throw new NotImplementedException();
      }
      
      public List<WorkingTimeService> workingTimeService;
      
      public List<WorkingTimeService> WorkingTimeService
      {
         get
         {
            if (workingTimeService == null)
               workingTimeService = new List<WorkingTimeService>();
            return workingTimeService;
         }
         set
         {
            RemoveAllWorkingTimeService();
            if (value != null)
            {
               foreach (WorkingTimeService oWorkingTimeService in value)
                  AddWorkingTimeService(oWorkingTimeService);
            }
         }
      }
      
      public void AddWorkingTimeService(WorkingTimeService newWorkingTimeService)
      {
         if (newWorkingTimeService == null)
            return;
         if (this.workingTimeService == null)
            this.workingTimeService = new List<WorkingTimeService>();
         if (!this.workingTimeService.Contains(newWorkingTimeService))
            this.workingTimeService.Add(newWorkingTimeService);
      }
      
      public void RemoveWorkingTimeService(WorkingTimeService oldWorkingTimeService)
      {
         if (oldWorkingTimeService == null)
            return;
         if (this.workingTimeService != null)
            if (this.workingTimeService.Contains(oldWorkingTimeService))
               this.workingTimeService.Remove(oldWorkingTimeService);
      }
      
      public void RemoveAllWorkingTimeService()
      {
         if (workingTimeService != null)
            workingTimeService.Clear();
      }
   
   }
}