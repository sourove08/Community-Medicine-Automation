using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicine.Models.Models
{
   public class PatientTreatment
    {
        public PatientTreatment()
        {
            PatientDiseases=new List<PatientDisease>();
        }
        public int Id { set; get; }
        public string TreatmentCode { set; get; }
        public int PatientId { set; get; }
        public int CenterId { set; get; } 
        public virtual Center Center { set; get; }
        public string Observation { set; get; }
        [DataType(DataType.Date)]
        public DateTime Date { set; get; }
        public virtual Doctor Doctor { set; get; }
        public int DoctorId { set; get; }
        public int ServiceTime { set; get; }      
        public virtual ICollection<PatientDisease> PatientDiseases { set; get; }
    }
}
