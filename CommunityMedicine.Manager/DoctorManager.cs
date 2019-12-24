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
   public class DoctorManager:CommonManager<Doctor>,IDoctorManager
   {
       private IDoctorRepository _doctorRepository;
       //public DoctorManager() : base(new DoctorRepository())
       //{
       //    _doctorRepository=new DoctorRepository();
       //}
        public DoctorManager(IDoctorRepository repository) : base(repository)
        {
            _doctorRepository = repository;
        }
    }
}
