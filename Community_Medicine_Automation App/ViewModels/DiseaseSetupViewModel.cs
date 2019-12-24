using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Community_Medicine_Automation_App.ViewModels
{
    public class DiseaseSetupViewModel
    {
        public String Name { set; get; }
        public string Description { set; get; }
        public string TreatmentProcedure { set; get; }
        public string PreferedDrugs { set; get; }
    }
}