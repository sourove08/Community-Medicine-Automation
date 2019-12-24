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
   public class CenterLoginManager:CommonManager<CenterLogin>,ICenterLoginManager
   {
       private ICenterLoginRepository _repository;

       //public CenterLoginManager():base(new CenterLoginRepository())
       //{
       //    _repository=new CenterLoginRepository();
       //}
        public CenterLoginManager(ICenterLoginRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
