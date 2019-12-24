using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicine.Models.Models
{
   public class PreferedDrug
    {
        public int Id { set; get; }
        public int DiseaseId { set; get; }
        public Disease Disease { set; get; }
        public int MedicineId { set; get; }
        public virtual  Medicine Medicine { set; get; }
    }
}
