using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IGenericService<Product> // IProductService arayüzü
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetList()
        {
            return _productDal.GetLİst();
        }

        public void TDelete(Product t)
        {
           _productDal.Delete(t);
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
            throw new NotImplementedException();
        }

        public Product TGetById(object ıd)
        {
            throw new NotImplementedException();
        }

        public string? TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Product t)
        {
           _productDal.Insert(t);
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}
