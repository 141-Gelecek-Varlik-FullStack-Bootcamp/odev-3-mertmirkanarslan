using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemtPazari.Model.User
{
    public class UserViewModel
    {
        //User işlemlerinde kullanılacak view model
        [Required(ErrorMessage = "Adınızı giriniz.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Adınız 3 ile 50 karakter arasında olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kullanıcı adınızı giriniz.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Kullanıcı adınız 5 ile 50 karakter arasında olmalıdır.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mail adresinizi giriniz.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mail adresiniz 6 ile 50 karakter arasında olmalıdır.")]
        [EmailAddress(ErrorMessage = "Geçersiz bir adres girdiniz, tekrar deneyiniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrenizi giriniz.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Şifre 3 ile 50 karakter arasında olmalıdır.")]
        public string Password { get; set; }
    }
}
