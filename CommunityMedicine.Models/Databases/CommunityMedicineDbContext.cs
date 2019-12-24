using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicine.Models.IdentityModels;
using CommunityMedicine.Models.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CommunityMedicine.Models.Databases
{
   public class CommunityMedicineDbContext:IdentityDbContext<ApplicationUser>
    {
        public CommunityMedicineDbContext():base("CommunityMedicineDbContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public static CommunityMedicineDbContext Create()
        {
            return new CommunityMedicineDbContext();
        }
        public DbSet<Medicine> Medicines { set; get; }
        public DbSet<Disease> Diseases { set; get; }
        public DbSet<Center> Centers { set; get; }
        public DbSet<Doctor> Doctors { set; get; }
        public DbSet<MedicineStore> MedicineStores { set; get; }
        public DbSet<Patient> Patients { set; get; }
        public DbSet<District> Districts { set; get; }
        public DbSet<Thana> Thanas { set; get; }
        public DbSet<CenterLogin> CenterLogins { set; get; }
        public DbSet<PreferedDrug> PreferedDrugs { set; get; }
        public DbSet<PatientTreatment> PatientTreatements { set; get; }
        public DbSet<PatientDisease> PatientDiseases { set; get; }
    }
}
