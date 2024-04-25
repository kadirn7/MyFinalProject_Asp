using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz ";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductListed = "Ürünler Listelendi";
        public static string UnitPriceInvalid = "ürün fiyatı geçersiz";
        public static string ProductCounofCategoryError = "Categoriye ait ürün sayısı istenilen sayısını aştınız";
        public static string ProductNameAlreadyExists = "Bu isimde bir ürün  zaten var ";
    }
}
