using AutoMapper;
using SemtPazari.Model;
using SemtPazari.Model.Product;
using SemtPazari.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemtPazari.Service.Product
{
    //interfaceten kalıtım alıp implemente ediyoruz.
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        public ProductService(IMapper _mapper)
        {
            //mapper = _mapper
        }

        //Ürünlerin silinmesi: id ile kontrol sağlıyoruz
        public General<ListViewModel> Delete(int id)
        {
            var result = new General<ListViewModel>();
            using (var context = new SemtPazariContext())
            {
                var product = context.Product.SingleOrDefault(i => i.Id == id);
                if (product != null)
                {
                    product.IsDeleted = true; //DB'de kalacak, sadece kullanıcıya göstermemiş oluyoruz
                    product.IsActive = false;

                    context.Product.Update(product);
                    context.SaveChanges();

                    result.Entity = mapper.Map<ListViewModel>(product);
                    result.IsSuccess = true;
                }
                else
                {
                    result.Exception = "Ürün bulunamadı.";
                }
            }
            return result;
        }

        //Ürünlerin Listelenmesi
        public General<ListViewModel> GetProducts()
        {
            var result = new General<ListViewModel>();
            using (var context = new SemtPazariContext())
            {
                //ürün var ve silinmediyse: idye göre getiriyoruz
                var data = context.Product.
                            Where(x => x.IsActive && !x.IsDeleted).
                            OrderBy(x => x.Id);

                //veri varsa success, yoksa mesaj dönecek:
                if (data.Any())
                {
                    result.List = mapper.Map<List<ListViewModel>>(data);
                    result.IsSuccess = true;
                }
                else
                {
                    result.Exception = "Ürün bulunamadı.";
                }
                return result;
            }

        }

        //Ürün Ekleme
        public General<ProductViewModel> Insert(ProductViewModel newProduct)
        {
            var result = new General<ProductViewModel>();
            var model = mapper.Map<SemtPazari.DB.Entities.Product>(newProduct);

            using (var context = new SemtPazariContext())
            {
                //authentication kullanıyoruz. modelden gelen Id, dbdeki userlardan birininkine eşitse, login gerçekleşmiş oluyor. 
                //eğer kullanıcı sistemden kaldırılmamışsa, ürün ekleyebilme yetkisine sahip oluyor:
                var isAuthenticated = context.User.Any(x => x.Id == model.Iuser && x.IsActive && !x.IsDeleted);

                if (isAuthenticated)
                {
                    model.Idate = DateTime.Now;
                    context.Product.Add(model);
                    context.SaveChanges();

                    result.Entity = mapper.Map<ProductViewModel>(model);
                    result.IsSuccess = true;
                }
                else
                {
                    result.Exception = "Bu işlem yetkisine sahip değilsiniz.";
                }
            }

            return result;
        }

        //Ürün Güncelleme
        public General<UpdateViewModel> Update(int id, UpdateViewModel product)
        {
            var result = new General<UpdateViewModel>();
            using (var context = new SemtPazariContext())
            {
                //güncellemedeki logic: bu işlemi yapmak için o ürünü ekleyen kişi olması gerekiyor
                var isAuthenticated = context.Product.Any(x => x.Iuser == product.Iuser);
                var updateProduct = context.Product.SingleOrDefault(i => i.Id == id);

                // Kullanıcı yetkiliyse ürün güncelleniyor değilse mesaj dönüyor
                if (isAuthenticated)
                {
                    if (updateProduct != null)
                    {
                        var updateTime = DateTime.Now;

                        updateProduct.Name = product.Name;
                        updateProduct.DisplayName = product.DisplayName;
                        updateProduct.Description = product.Description;
                        updateProduct.Price = product.Price;
                        updateProduct.Stock = product.Stock;
                        updateProduct.Udate = updateTime;

                        context.SaveChanges();

                        result.Entity = mapper.Map<UpdateViewModel>(updateProduct);
                        result.IsSuccess = true;
                    }
                    else
                    {
                        result.Exception = "Ürün bulunamadı.";
                    }
                }
                else
                {
                    result.Exception = "Güncelleme yetkiniz bulunmamaktadır.";
                }
            }

            return result;
        }
    }
}
