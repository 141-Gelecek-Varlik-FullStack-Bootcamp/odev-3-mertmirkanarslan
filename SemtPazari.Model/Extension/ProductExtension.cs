using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemtPazari.Model.Extension
{
    public static class ProductExtension
    {
        //Türkiye'de saat dilimi olarak GMT+3 kullanıyor. GMTye döndüren metodu extension olarak yazıyoruz
        public static DateTime toGMTTime(this DateTime turkishTime)
        {
            return turkishTime.AddHours(-3);
        }
    }
}
