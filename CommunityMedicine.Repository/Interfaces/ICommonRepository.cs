using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityMedicine.Repository.Interfaces
{
   public interface ICommonRepository<T>:IDisposable where T:class 
   {
       bool Add(T entity);
       bool Update(T entity);
       bool Delete(T entity);
       T GetById(int id);
       ICollection<T> GetAll();
   }
}
