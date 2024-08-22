using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        void IGenericDal<T>.Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        T IGenericDal<T>.GetById(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
        }

        List<T> IGenericDal<T>.GetLİst()
        {
            using var c = new Context();
             return c.Set<T>().ToList();
        }
        List<T> IGenericDal<T>.GetAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        void IGenericDal<T>.Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        void IGenericDal<T>.Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }


    }
}
