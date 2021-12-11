using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemtPazari.Model.Product
{
    //Ürünler listelenirken ve silinirken bu view model kullanılacak.
    public class ListViewModel
    {
        [Required(ErrorMessage = "Ürün adını giriniz.")]
        [StringLength(50, ErrorMessage = "Ürün adı 50 karakterden fazla olamaz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ürün gösterim adı boş bırakılamaz!")]
        [StringLength(50, ErrorMessage = "Ürün gösterim adı 50 karakterden fazla olamaz.")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [StringLength(250, ErrorMessage = "Açıklama 250 karakterden fazla olmamalıdır.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Lütfen fiyat bilgisi giriniz.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stok bilgisi giriniz.")]
        public int Stock { get; set; }
    }
}
