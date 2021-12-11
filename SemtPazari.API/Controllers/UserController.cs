using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SemtPazari.Model;
using SemtPazari.Model.User;
using SemtPazari.Service.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemtPazari.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        //Kullanıcı Listeleme
        [HttpGet]
        public General<UserViewModel> GetUsers()
        {
            return userService.GetUsers();
        }

        //Kullanıcı Giriş
        [HttpPost("login")]
        public General<LoginViewModel> Login([FromBody] LoginViewModel user)
        {
            return userService.Login(user);
        }

        //Kullanıcı Ekleme
        [HttpPost]
        public General<UserViewModel> Add([FromBody] UserViewModel newUser)
        {
            return userService.Insert(newUser);
        }

        //Kullanıcı Güncelleme
        [HttpPut("{id}")]
        public General<UserViewModel> Update(int id, [FromBody] UserViewModel user)
        {
            return userService.Update(id, user);
        }

        //Kullanıcı Silme
        [HttpDelete("{id}")]
        public General<UserViewModel> Delete(int id)
        {
            return userService.Delete(id);
        }
    }
}
