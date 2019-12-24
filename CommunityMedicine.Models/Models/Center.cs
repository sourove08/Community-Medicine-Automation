using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicine.Models.Models
{
   public class Center
    {
        public int Id { set; get; }
        public string Name { set; get; }
        [Display(Name = "District")]
        public int DistrictId { set; get; }
        [Display(Name = "Thana")]
        public int ThanaId { set; get; }
    }
}
