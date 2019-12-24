using System.Data.Entity;
using System.Web.Mvc;
using CommunityMedicine.Manager;
using CommunityMedicine.Manager.Interfaces;
using CommunityMedicine.Models.Databases;
using CommunityMedicine.Models.IdentityModels;
using CommunityMedicine.Repository;
using CommunityMedicine.Repository.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using Unity;
using Unity.Mvc5;

namespace Community_Medicine_Automation_App
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IMedicineManager, MedicineManager>();
            container.RegisterType<IDiseaseManager, DiseaseManager>();
            container.RegisterType<ICenterManager, CenterManager>();
            container.RegisterType<ICenterLoginManager, CenterLoginManager>();
            container.RegisterType<IMedicineStoreManager, MedicineStoreManager>();
            container.RegisterType<IMedicineRepository, MedicineRepository>();
            container.RegisterType<IDiseaseRepository, DiseaseRepository>();
            container.RegisterType<ICenterRepository, CenterRepository>();
            container.RegisterType<ICenterLoginRepository, CenterLoginRepository>();
            container.RegisterType<IMedicineStoreRepository, MedicineStoreRepository>();
            container.RegisterType<IDoctorManager, DoctorManager>();
            container.RegisterType<IDoctorRepository, DoctorRepository>();
            container.RegisterType<IPatientManager, PatientManager>();
            container.RegisterType<IPatientRepository, PatientRepository>();
            container.RegisterType<IPatientTreatmentManager, PatientTreatmentManager>();
            container.RegisterType<IPatientTreatmentRepository, PatientTreatmentRepository>();
            container.RegisterType<DbContext, CommunityMedicineDbContext>();
           // container.RegisterType<IdentityDbContext<ApplicationUser>>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}