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
   public class CenterManager:CommonManager<Center>, ICenterManager
   {
       private ICenterRepository _centerRepository;

        //public CenterManager() : base(new CenterRepository())
        //{
        //    _centerRepository = new CenterRepository();
        //}
        public CenterManager(ICenterRepository repository) : base(repository)
        {
            _centerRepository = repository;
        }

       public ICollection<District> GetAllDistricts()
       {
           return _centerRepository.GetAllDistricts();
       }

       public ICollection<Thana> GetAllThanas()
       {
           return _centerRepository.GetAllThanas();
       }

       public ICollection<Thana> GetThanasByDistrict(int districtId)
       {
           return _centerRepository.GetThanasByDistrict(districtId);
       }

       public ICollection<Center> GetCentersByThana(int thanaId)
       {
           return _centerRepository.GetCentersByThana(thanaId);
       }
    }
}
