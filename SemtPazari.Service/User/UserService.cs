using AutoMapper;
using SemtPazari.DB.Entities.DataContext;
using SemtPazari.Model;
using SemtPazari.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemtPazari.Service.User
{
    public class UserService : IUserService
    {
        //mapper çağrımı ve contstructor üzerinden işlemi
        private readonly IMapper mapper;
        public UserService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        //Kullanıcıları Listeleme
        public General<UserViewModel> GetUsers()
        {
            var result = new General<UserViewModel>();
            using (var context = new SemtPazariContext())
            {
                //aktif kullanıcılar: idye göre listeleme
                var data = context.User
                    .Where(x => x.IsActive && !x.IsDeleted)
                    .OrderBy(x => x.Id);
               
                if (data.Any())
                {
                    result.List = mapper.Map<List<UserViewModel>>(data);
                    result.IsSuccess = true;
                }
                else
                {
                    result.Exception = "Kullanıcı bulunamadı.";
                }
            }
            return result;
        }

        //Kullanıcı Ekleme
        public General<UserViewModel> Insert(UserViewModel newUser)
        {
            var result = new General<UserViewModel>();
            var model = mapper.Map<SemtPazari.DB.Entities.User>(newUser);

            using (var context = new SemtPazariContext())
            {
                model.Idatetime = DateTime.Now;
                model.IsActive = true;
                model.IsDeleted = false;
                context.User.Add(model);
                context.SaveChanges();

                result.Entity = mapper.Map<UserViewModel>(model);
                result.IsSuccess = true;
            }
            return result;
        }

        //Kullanıcı Güncelleme
        public General<UserViewModel> Update(int id, UserViewModel user)
        {
            var result = new General<UserViewModel>();
            using (var context = new SemtPazariContext())
            {
                //önce linq ile id ye göre kullanıcıyı getireceğiz. burada kullanıcı gelirse güncelleme işlemi, gelmezse de exception mesajı olarak "kullanıcı bulunamadı" döndürüyoruz.
                var updateUser = context.User.SingleOrDefault(i => i.Id == id);

                if (updateUser is not null)
                {
                    updateUser.Name = user.Name;
                    updateUser.UserName = user.UserName;
                    updateUser.Email = user.Email;
                    updateUser.Password = user.Password;

                    context.SaveChanges();

                    result.Entity = mapper.Map<UserViewModel>(updateUser);
                    result.IsSuccess = true;
                }
                else
                {
                    result.Exception = "Kullanıcı bulunamadı.";
                }
            }
            return result;
        }

        //Kullanıcı Silme
        public General<UserViewModel> Delete(int id)
        {
            var result = new General<UserViewModel>();
            using (var context = new SemtPazariContext())
            {
                //burada da üsttekilere benzer mantık. idye göre getirip işlem yapıyoruz.
                var user = context.User.SingleOrDefault(i => i.Id == id);

                if (user is not null)
                {
                    context.User.Remove(user);
                    context.SaveChanges();

                    result.Entity = mapper.Map<UserViewModel>(user);
                    result.IsSuccess = true;
                }
                else
                {
                    result.Exception = "Kullanıcı bulunamadı.";
                }
                return result;
            }
        }

        //Kullanıcı Login
        public General<LoginViewModel> Login(LoginViewModel user)
        {
            var result = new General<LoginViewModel>();
            var model = mapper.Map<SemtPazari.DB.Entities.User>(user);
            using (var context = new SemtPazariContext())
            {
                //username, isactive, isdeleted ve password üzerinden kontrol.Bunu da issuccess diye bir kontrolden yapıyoruz.
                result.Entity = mapper.Map<LoginViewModel>(model);
                result.IsSuccess = context.User.Any(x => x.UserName == user.UserName &&
                                                   x.IsActive && !x.IsDeleted &&
                                                   x.Password == user.Password);
            }
            return result;
        }

    }
}
