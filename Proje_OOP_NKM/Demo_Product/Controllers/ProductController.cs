using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Extensions;

namespace Demo_Product.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new(new EfProductDal());
        private readonly object p;

        public IActionResult Index()
        {
            var values = productManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            ModelState.Clear(); // Validation sorunsuz gözükmesi için ilk başta temizleniyor.
            ProductValidator validationRules = new ProductValidator();
            ValidationResult results = validationRules.Validate(p);
            if (results.IsValid)
            {
                productManager.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }

        public IActionResult DeleteProduct(int id)
        {
            Product value = productManager.TGetById(id);
            productManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id) 
        {
            var value = productManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            
           productManager.TUpdate(p);
           return RedirectToAction("Index");
        }

    }
}
