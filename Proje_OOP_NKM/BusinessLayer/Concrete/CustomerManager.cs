using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : IGenericService<Customer>
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public Customer GetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public List<Customer> GetCustomersListWithJob()
        {
            return _customerDal.GetCustomerListWithJob();
        }

        public List<Customer> GetList()
        {
            return _customerDal.GetLİst();
        }


        public void TDelete(Customer t)
        {
            _customerDal.Delete(t);
        }

        public void TDelete(string? value)
        {
            throw new NotImplementedException();
        }

        public Customer? TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public IEnumerable<Customer> TGetList()
        {
            // Veritabanından tüm müşteri verilerini al
            return _customerDal.GetAll();
        }


        public void TInsert(Customer t)
        {
            _customerDal.Insert(t);
        }

        public void TUpdate(Customer t)
        {
            _customerDal.Update(t);
        }
    }

}
