using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicine.Models.Databases;
using CommunityMedicine.Models.Models;
using CommunityMedicine.Repository.Interfaces;

namespace CommunityMedicine.Repository
{
   public class DiseaseRepository:CommonRepository<Disease>,IDiseaseRepository
    {
        //private CommunityMedicineDbContext db;
        public DiseaseRepository(DbContext db) : base(db)
        {
            
           //db=new CommunityMedicineDbContext();
        }

        public ICollection<Medicine> GetAllMedicineByDisease(int deseaseId)
        {
            var context = (CommunityMedicineDbContext)db;
            var drugs = from drug in context.PreferedDrugs.ToList() where drug.DiseaseId == deseaseId select drug;
            List<Medicine> medicines=new List<Medicine>();
            foreach (PreferedDrug sample in drugs)
            {
               Medicine medicine= context.Medicines.FirstOrDefault(m => m.Id == sample.MedicineId);
                medicines.Add(medicine);
            }

            return medicines;
        }
    }
}
