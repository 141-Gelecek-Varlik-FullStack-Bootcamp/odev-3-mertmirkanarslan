using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemtPazari.Model
{
    public class General<T>
    {
        //genel metotları kullanmak için (kontrol, hata tespiti, işlem yapan kullanıcıları görme) kullanacağımız class
        //T tipinde yani generic olarak yazıyoruz.

        public bool IsSuccess { get; set; }
        public T Entity { get; set; }
        public List<T> List { get; set; }
        public string Exception { get; set; }
    }
}
