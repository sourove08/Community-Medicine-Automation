using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicine.Models.Models;

namespace Community_Medicine_Automation_App.ViewModels
{
    public class ShowAllHistoryViewModel
    {
        public ShowAllHistoryViewModel()
        {
            PatientTreatments=new List<PatientTreatment>();
        }
        public Patient Patient { set; get; }
        public ICollection<PatientTreatment> PatientTreatments { set; get; }
        
    }
}