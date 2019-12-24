using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicine.Manager.Interfaces;
using CommunityMedicine.Models.Models;
using CommunityMedicine.Repository;
using CommunityMedicine.Repository.Interfaces;

namespace CommunityMedicine.Manager
{
   public class DiseaseManager:CommonManager<Disease>,IDiseaseManager
   {
       private IDiseaseRepository _repository;
        //public DiseaseManager():base(new DiseaseRepository())
        //{
        //    _repository=new DiseaseRepository();
        //}
        public DiseaseManager(IDiseaseRepository repository) : base(repository)
        {
            _repository = repository;
        }

       public ICollection<Medicine> GetAllMedicineByDisease(int deseaseId)
       {
           return _repository.GetAllMedicineByDisease(deseaseId);
       }
   }
}
