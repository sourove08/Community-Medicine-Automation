using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicine.Models.Models
{
   public class MedicineStore
    {
        public MedicineStore()
        {
            StoreDetails=new List<StoreDetail>();
        }
        public int Id { set; get; }
        public int DistrictId { set; get; }
        public int ThanaId{ set ; get; }
        public int CenterId { set; get; }
        public virtual ICollection<StoreDetail> StoreDetails { set; get; }
    }
}
