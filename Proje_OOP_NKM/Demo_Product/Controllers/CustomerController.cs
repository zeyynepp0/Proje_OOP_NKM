using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results; // Doğru ValidationResult sınıfı
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo_Product.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        JobManager jobManager = new JobManager(new EfJobDal());

        public IActionResult Index()
        {
            var values = customerManager.GetCustomersListWithJob();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddCustomer()
        {
            
            var jobList = (List<Job>)jobManager.TGetList(); // TGetList metodunun uygun türde veri döndürmesini sağlayın.

            List<SelectListItem> values = (from x in jobList
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.JobID.ToString()
                                           }).ToList();

            ViewBag.v = values;
            return View();
        }



        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            ModelState.Clear(); // Validation sorunsuz gözükmesi için ilk başta temizleniyor.
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult results = validationRules.Validate(p);

            if (results.IsValid)
            {
                customerManager.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }

        public IActionResult DeleteCustomer(int id)
        {
            var value = customerManager.TGetById(id);
            customerManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        //public IActionResult UpdateCustomer(int id)
        //{
        //    var jobList = (List<Job>)jobManager.TGetList(); // TGetList metodunun uygun türde veri döndürmesini sağlayın.

        //    List<SelectListItem> values = (from x in jobList
        //                                   select new SelectListItem
        //                                   {
        //                                       Text = x.Name,
        //                                       Value = x.JobID.ToString()
        //                                   }).ToList();

        //    ViewBag.v = values;
        //    return View();
        //    var value = customerManager.TGetById(id);
        //    return View(value);
        //}
        public IActionResult UpdateCustomer(int id)
        {
            // ID'ye göre müşteri verisini al
            Customer customer = customerManager.TGetById(id);

            // İş listesini dropdown için al
            var jobList = (List<Job>)jobManager.TGetList(); // TGetList metodunun uygun türde veri döndürmesini sağlayın.
            List<SelectListItem> values = (from x in jobList
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.JobID.ToString()
                                           }).ToList();
            ViewBag.v = values;

            // Müşteri verisini görünüme gönder
            return View(customer);
        }


        [HttpPost]
        public IActionResult UpdateCustomer(Customer p)
        {
            customerManager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
