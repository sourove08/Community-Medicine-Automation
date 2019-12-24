using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicine.Repository.Interfaces;

namespace CommunityMedicine.Repository
{
   public class CommonRepository<T>:ICommonRepository<T> where T:class 
   {
       protected DbContext db;

       public CommonRepository(DbContext dbContext)
       {
           db = dbContext;
       }

       private DbSet<T> Table
       {
           get { return db.Set<T>(); }
       }

       public virtual bool Add(T entity)
       {
           Table.Add(entity);
          return db.SaveChanges() > 0;
       }

       public virtual bool Update(T entity)
       {
           db.Entry(entity).State=EntityState.Modified;
           return db.SaveChanges() > 0;
       }

       public virtual bool Delete(T entity)
       {
           Table.Remove(entity);
           return db.SaveChanges() > 0;
       }

       public virtual T GetById(int id)
       {
          return Table.Find(id);
       }

       public virtual ICollection<T> GetAll()
       {
           return Table.ToList();
       }

       public void Dispose()
       {
           db?.Dispose();
       }
   }
}
