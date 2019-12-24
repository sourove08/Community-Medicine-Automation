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
   public class MedicineStoreManager:CommonManager<MedicineStore>,IMedicineStoreManager
   {
       private IMedicineStoreRepository _repository;

      //public MedicineStoreManager():base(new MedicineStoreRepository())
      //{
      //    _repository = new MedicineStoreRepository();
      //}

        public MedicineStoreManager(IMedicineStoreRepository repository) : base(repository)
        {
            _repository = repository;
        }

       public override bool Add(MedicineStore entity)
       {
           MedicineStore store = _repository.GetAll().ToList().FirstOrDefault(m => m.CenterId == entity.CenterId);
           if (store==null)
           {
              return _repository.Add(entity);
           }

           foreach (StoreDetail result in entity.StoreDetails)
           {
              StoreDetail temp= store.StoreDetails.ToList().FirstOrDefault(m => m.MedicineId == result.MedicineId);
               if (temp==null)
               {
                   store.StoreDetails.Add(result);
               }
               else
               {
                   temp.Quantity = temp.Quantity + result.Quantity;
                }
       
            }

           return _repository.Update(store);
       }

       
    }
}
