using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicine.Models.Models;

namespace CommunityMedicine.Manager.Interfaces
{
   public interface IDiseaseManager:ICommonManager<Disease>
    {
        ICollection<Medicine> GetAllMedicineByDisease(int deseaseId);
    }
}
