using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicine.Models.Models
{
   public class StoreDetail
    {
        public int Id { set; get; }
        public int MedicineStoreId { set; get; }
        public int MedicineId { set; get; }
        public virtual Medicine Medicine { set; get; }
        public double Quantity { set; get; }
    }
}
