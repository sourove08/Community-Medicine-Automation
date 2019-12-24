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
   public class DoctorRepository:CommonRepository<Doctor>,IDoctorRepository
    {
        public DoctorRepository(DbContext db) : base(db)
        {
        }
    }
}
