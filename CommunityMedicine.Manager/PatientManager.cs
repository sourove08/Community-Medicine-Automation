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
   public class PatientManager:CommonManager<Patient>,IPatientManager
   {
       private IPatientRepository _patientRepository;
        //public PatientManager():base(new PatientRepository())
        //{
        //    _patientRepository=new PatientRepository();
        //}
        public PatientManager(IPatientRepository repository) : base(repository)
        {
            _patientRepository = repository;
        }
    }
}
