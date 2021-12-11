using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemtPazari.Model.User
{
    public class LoginViewModel
    {
        //Kullanıcı girişinde kullanılacak olan view model. sadece kullanıcı adı ve şifre yeterli olacaktır.
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
