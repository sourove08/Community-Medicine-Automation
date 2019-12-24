using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicine.Models.Models
{
   public class PatientDisease
    {
        public int Id { set; get; }
        public int PatientTreatmentId { set; get; }
        public int DiseaseId { set; get; }
        public int MedicineId { set; get; }
        public Medicine Medicine { set; get; }
        public double MedicineQuantity { set; get; }
        public Disease Disease { set; get; }
        public string SelectedDose { set; get; }
        public string Note { set; get; }
    }
}
