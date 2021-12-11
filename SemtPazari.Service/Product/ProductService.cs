using AutoMapper;
using SemtPazari.DB.Entities.DataContext;
using SemtPazari.Model;
using SemtPazari.Model.Extension;
using SemtPazari.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemtPazari.Service.Product
{
    public class ProductService : IProductService
    {
        //interfaceten kalıtım alıp implemente ediyoruz.
        private readonly IMapper mapper;
        public ProductService(IMapper _mapper)
        {
            mapper = _mapper;
        }

<<<<<<< HEAD
        
=======
        //Ürünlerin silinmesi: id ile kontrol sağlıyoruz
        public General<ListViewModel> Delete(int id)
        {
            var result = new General<ListViewModel>();
            using (var context = new SemtPazariContext())
            {
                //id üzerinden kontrol ediyor. Buradan silme ve mesaj dönme sağlanıyor.
                var product = context.Product.SingleOrDefault(x => x.Id == id);

                if (product != null)
                {
                    context.Product.Remove(product);
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
>>>>>>> 4b0ce1aa505d15dfb16d08ce6c31d8678a5e72f2

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
            }
            return result;
        }

        //Ürün Ekleme
        public General<ProductViewModel> Insert(ProductViewModel newProduct)
        {
            var result = new General<ProductViewModel>();
            var model = mapper.Map<SemtPazari.DB.Entities.Product>(newProduct);

            using (var context = new SemtPazariContext())
            {
                //authentication değişkeni kullanıyoruz. modelden gelen Id, dbdeki userlardan birininkine eşitse, login gerçekleşmiş oluyor. 
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
                var updateProduct = context.Product.SingleOrDefault(x => x.Id == id);

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
                        updateProduct.UGMTTime = ProductExtension.toGMTTime(updateTime); //gmt zaman dilimine çevirdik extension ile.

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

        //Ürünlerin silinmesi: id ile kontrol sağlıyoruz
        public General<ListViewModel> Delete(int id)
        {
            var result = new General<ListViewModel>();
            using (var context = new SemtPazariContext())
            {
                // Silme işlemi gerçekleştirilecek id'ye ait ürün var mı kontrol ediliyor
                // Varsa ürün siliniyor yoksa mesaj dönüyor
                var product = context.Product.SingleOrDefault(x => x.Id == id);

                if (product != null)
                {
                    context.Product.Remove(product);
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
    }
}
