using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicine.Manager.Interfaces;
using CommunityMedicine.Repository;
using CommunityMedicine.Repository.Interfaces;

namespace CommunityMedicine.Manager
{
   public class CommonManager<T>:ICommonManager<T> where T:class
   {
       private ICommonRepository<T> _repository;
        protected CommonManager(ICommonRepository<T> repository)
        {
            _repository=repository;
        }
        public virtual bool Add(T entity)
        {
            return _repository.Add(entity);
        }

        public virtual bool Update(T entity)
        {
            return _repository.Update(entity);
        }

        public virtual bool Delete(T entity)
        {
           return _repository.Delete(entity);
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
