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
   public class PatientTreatmentManager:CommonManager<PatientTreatment>,IPatientTreatmentManager
   {
       private IPatientTreatmentRepository _patientTreatmentRepository;

       //public PatientTreatmentManager():base(new PatientTreatmentRepository())
       //{
       //    _patientTreatmentRepository=new PatientTreatmentRepository();
       //}
       public PatientTreatmentManager(IPatientTreatmentRepository repository) : base(repository)
       {
           _patientTreatmentRepository = repository;
       }
    }
}
