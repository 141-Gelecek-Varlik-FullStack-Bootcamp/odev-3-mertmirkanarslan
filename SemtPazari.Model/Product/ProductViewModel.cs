using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemtPazari.Model.Product
{
    public class ProductViewModel
    {
        //ürünler için kurulan view model yapısı. Burada id, categoryid, name, displayname, price ve stock bilgisi gelecek.
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
