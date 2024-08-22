using Demo_Product.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class RegisterController : Controller
    {
        // UserManager<AppUser> nesnesi, kullanıcı yönetimi ile ilgili işlemleri gerçekleştirmek için kullanılır.
        // ASP.NET Core Identity yapısında kullanıcı oluşturma, kullanıcı bilgilerini güncelleme, kimlik doğrulama gibi işlemleri sağlar.
        private readonly UserManager<AppUser> _userManager;

        // Constructor metodu, RegisterController sınıfından bir nesne oluşturulduğunda çağrılır.
        // Bu metod, UserManager<AppUser> nesnesini dependency injection (bağımlılık enjeksiyonu) ile alır.
        public RegisterController(UserManager<AppUser> userManager)
        {
            // Dependency injection ile gelen UserManager<AppUser> nesnesi, yerel _userManager değişkenine atanır.
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel model)
        {
            AppUser appUser= new AppUser()
            {
                Name = model.Name,
                Surname = model.SurName,
                UserName = model.UserName,
                Email = model.Mail

            };

            

            if (model.Password == model.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
                return View(model);
        }
    }     
}
