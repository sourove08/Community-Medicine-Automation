using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicine.Models.Models
{
   public class CenterLogin
    {
        public int Id { set; get; }
        public int CenterId { set; get; }
        public int Code { set; get; }
        public string Password { set; get; }
    }
}
