using System.ComponentModel.DataAnnotations;

namespace Demo_Product.Models
{
    public class UserRegisterViewModel
    {
        [Required (ErrorMessage ="Lütfen adınızı giriniz")]
        public string Name { get; set; }

    [Required (ErrorMessage ="Lütfen soyadınızı giriniz")]
        public string SurName { get; set; }

    [Required (ErrorMessage ="Lütfen kullanıcı adınızı giriniz")]
        public string UserName { get; set; }

         [Required (ErrorMessage ="Lütfen mail giriniz")]
        public string Mail { get; set; }

    [Required (ErrorMessage ="Lütfen şifre giriniz")]
        public string Password { get; set; }

    [Required (ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
    [Compare ("Password", ErrorMessage ="Lütfen şifrelerin eşleştiğinden emin olun")]
        public string ConfirmPassword { get; set; }
    }
}
