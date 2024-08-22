using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class JobController : Controller
    {
        JobManager jobManager = new JobManager(new EfJobDal());
        private readonly object p;

        public IActionResult Index()
        {
            var values = jobManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job p)
        {
                jobManager.TInsert(p);
                return RedirectToAction("Index");
        }

        public IActionResult DeleteJob(int id)
        {
            Job value = jobManager.TGetById(id);
            jobManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var value = jobManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateJob(Job p)
        {

            jobManager.TUpdate(p);
            return RedirectToAction("Index");
        }

    }
}
