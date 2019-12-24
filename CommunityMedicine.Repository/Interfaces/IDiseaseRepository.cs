using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicine.Models.Models;

namespace CommunityMedicine.Repository.Interfaces
{
   public interface IDiseaseRepository:ICommonRepository<Disease>
    {
        ICollection<Medicine> GetAllMedicineByDisease(int deseaseId);
    }
  
}
