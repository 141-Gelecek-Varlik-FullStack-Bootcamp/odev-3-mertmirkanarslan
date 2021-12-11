using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SemtPazari.Model;
using SemtPazari.Model.Product;
using SemtPazari.Service.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemtPazari.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //Servisi çağırma 
        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        //Ürün Listeleme
        [HttpGet]
        public General<ListViewModel> GetProducts()
        {
            return productService.GetProducts();
        }

        //Ürün Ekleme
        [HttpPost]
        public General<ProductViewModel> Add([FromBody] ProductViewModel newProduct)
        {
            return productService.Insert(newProduct);
        }

        //Ürün Güncelleme
        [HttpPut("{id}")]
        public General<UpdateViewModel> Update(int id, [FromBody] UpdateViewModel product)
        {
            return productService.Update(id, product);
        }

        //Ürün Silme
        [HttpDelete("{id}")]
        public General<ListViewModel> Delete(int id)
        {
            return productService.Delete(id);
        }
    }
}
