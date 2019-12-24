using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicine.Models.Models
{
   public class Patient
    {
        public int Id { set; get; }
        public int VoterId { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string Age { set; get; }
        public int ServiceGiven { set; get; }
    }
}
