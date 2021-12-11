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
<<<<<<< HEAD
        //burada daha önce data annotationlar vardı. fakat önyüz tasarlanmayacağı için kaldırıldı.
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
=======
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
>>>>>>> 4b0ce1aa505d15dfb16d08ce6c31d8678a5e72f2
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
