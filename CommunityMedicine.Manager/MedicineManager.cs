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
   public class MedicineManager:CommonManager<Medicine>,IMedicineManager
   {
       private IMedicineRepository _repository;

        //public MedicineManager() : base(new MedicineRepository())
        //{
        //    _repository = new MedicineRepository();
        //}
        public MedicineManager(IMedicineRepository repository) : base(repository)
       {
           _repository = repository;
       }
   }
}
