using AutoMapper;
using SemtPazari.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemtPazari.Core.Extension
{
    public static class Extensions
    {
        //elimizdeki product classını productviewmodel yapmak için extension
        public static List<ProductViewModel> ToViewModel(this IMapper _mapper)
        {
            List<ProductViewModel> product = new List<ProductViewModel>();
            using (var result = new SemtPazari.DB.Entities.DataContext.SemtPazariContext())
            {
                var listProduct = result.Product.ToList();
                foreach (var l in listProduct)
                {
                    product.Add(_mapper.Map<ProductViewModel>(l));
                }
            }
            return product;
        }
    }
}
