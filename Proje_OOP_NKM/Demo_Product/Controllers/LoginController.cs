using Demo_Product.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, false, true);

                if (result.Succeeded)
                {
                    // Giriş başarılı ise kullanıcıyı yönlendirin
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    // Giriş başarısızsa hata mesajı gösterin
                    ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre");
                }
            }

            return View(p); // Modeli geri döndürün ki kullanıcı girdiği bilgileri tekrar görebilsin
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
