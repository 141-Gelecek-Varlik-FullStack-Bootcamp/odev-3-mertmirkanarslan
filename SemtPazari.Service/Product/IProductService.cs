using SemtPazari.Model;
using SemtPazari.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemtPazari.Service.Product
{
    public interface IProductService
    {
        //ProductService de kullanılacak methodları bu interfacete tanımlıyoruz
        public List<ProductViewModel> Get();
        public General<ProductViewModel> Insert(ProductViewModel productViewModel);
        public General<ProductViewModel> Update(int id, ProductViewModel productViewModel);
        public bool Remove(int id); //silme işlemini tamamen silme yapmayacağız, bu nedenle bool olarak işledik.
    }
}
