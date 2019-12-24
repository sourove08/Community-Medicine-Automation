using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicine.Models.Databases;
using CommunityMedicine.Models.Models;
using CommunityMedicine.Repository.Interfaces;

namespace CommunityMedicine.Repository
{
   public class CenterRepository:CommonRepository<Center>,ICenterRepository
   {
       
        public CenterRepository(DbContext db) : base(db)
        {
           
        }

        public ICollection<District> GetAllDistricts()
        {
            var context = (CommunityMedicineDbContext)db;
            return context.Districts.ToList();
        }

        public ICollection<Thana> GetAllThanas()
        {
            var context = (CommunityMedicineDbContext)db;
            return context.Thanas.ToList();
        }
       public ICollection<Center> GetAllCenters()
       {
           var context = (CommunityMedicineDbContext)db;
            return context.Centers.ToList();
       }

        public ICollection<Thana> GetThanasByDistrict(int districtId)
       {
           
            var thanas = from thana in GetAllThanas() where thana.DistrictId == districtId select thana;
           return thanas.ToList();
       }

       public ICollection<Center> GetCentersByThana(int thanaId)
       {
           var centers = from center in GetAllCenters() where center.ThanaId == thanaId select center;
           return centers.ToList();
       }
   }
}
