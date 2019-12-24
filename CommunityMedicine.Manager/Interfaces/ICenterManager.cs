using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicine.Models.Models;

namespace CommunityMedicine.Manager.Interfaces
{
   public interface ICenterManager:ICommonManager<Center>
    {
        ICollection<District> GetAllDistricts();
        ICollection<Thana> GetAllThanas();
        ICollection<Thana> GetThanasByDistrict(int districtId);
        ICollection<Center> GetCentersByThana(int thanaId);
       // ICollection<CenterLogin> GetAllCenterLogin();
    }
}
