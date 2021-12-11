using AutoMapper;
using SemtPazari.DB.Entities;
using SemtPazari.Model.Product;
using SemtPazari.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemtPazari.API.Infrastructure
{
    public class MappingProfile:Profile
    {
        //Burada kısaca api tarafında oluşturulan Mapping Profile ile, db verisi ile view modelleri mapliyoruz.
        //Bir constructor açıp içinde mapping yapıyoruz.
        public MappingProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();

            CreateMap<User, LoginViewModel>();
            CreateMap<LoginViewModel, User>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

            CreateMap<Product, ListViewModel>();
            CreateMap<ListViewModel, Product>();

            CreateMap<Product, UpdateViewModel>();
            CreateMap<UpdateViewModel, Product>();
        }

    }
}
