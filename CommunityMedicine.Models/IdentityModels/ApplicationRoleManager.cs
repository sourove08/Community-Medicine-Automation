using CommunityMedicine.Models.Databases;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace CommunityMedicine.Models.IdentityModels
{
   public class ApplicationRoleManager:RoleManager<ApplicationRole,string>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store)
        {
        }


       public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
       {
           var manager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context.Get<CommunityMedicineDbContext>()));
           return manager;
       }

        
    }
}
