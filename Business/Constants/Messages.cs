using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba Eklendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdated = "Araba Güncellendi";

        public static string CarNameInvalid = "Araba İsim Formatına Uymuyor";
        public static object CarsListed="Arablar Listelendi";
        internal static string CustomerAdded="Müteri Eklendi";
        internal static string BrandAdded="Marka Eklendi";
        internal static string ColorAdded="Renk Eklendi";
        internal static string RentalAdded="Kiralandı";
        internal static string UserAdded="Kullanıcı Eklendi";

        public static string CarImageAdded= "Resim Eklendi.";
        public static string CarImageDeleted= "Resim Eklendi.";
        public static string CarImageUpdated= "Resim Güncellendi.";
        public static string CarImageLimitExceeded = "Araba resimler son sayısına ulaştı.";

        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserRegistered = "Kullanıcı Kayıt Oldu.";
        public static string UserNotFound = "Kullanıcı Bulunamadı.";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Kullanılıyor.";
        public static string AccessTokenCreated = "Token Oluşturuldu.";
    }
}
