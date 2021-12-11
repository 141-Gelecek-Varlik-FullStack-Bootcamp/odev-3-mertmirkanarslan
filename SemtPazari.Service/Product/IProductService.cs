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
        //ProductService'te kullanılacak methodları bu interfacete tanımlıyoruz
        public General<ListViewModel> GetProducts();
        public General<ProductViewModel> Insert(ProductViewModel newProduct);
        public General<UpdateViewModel> Update(int id, UpdateViewModel product);
        public General<ListViewModel> Delete(int id);
    }
}
