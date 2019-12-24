using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicine.Models.Models
{
   public class Thana
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int DistrictId { set; get; }
        public virtual List<Center> Centers { set; get; }
    }
}
