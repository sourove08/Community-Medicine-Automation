using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicine.Models.Models
{
   public class Disease
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string TreatmentProcedure { set; get; }
        public virtual List<PreferedDrug> PreferedDrugs { set; get; }
    }
}
