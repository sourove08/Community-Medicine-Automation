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
   public class PatientRepository:CommonRepository<Patient>,IPatientRepository
    {
        public PatientRepository(DbContext db) : base(db)
        {
        }
    }
}
