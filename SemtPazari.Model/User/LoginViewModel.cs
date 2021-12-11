using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemtPazari.Model.User
{
    public class LoginViewModel
    {
        //Loginde kullanılacak view model
        [Required(ErrorMessage = "Kullanıcı adınızı giriniz.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Kullanıcı adı 4 ile 50 karakter arasında olabilir.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifrenizi giriniz.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Şifre 3 ile 50 karakter arasında olabilir.")]
        public string Password { get; set; }
    }
}
