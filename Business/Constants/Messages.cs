using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç başarıyla eklendi";
        public static string CarAddingDenied = "Araç ismini veya Günlük Fiyatlandırmasını kontrol ediniz.";
        public static string CarRentingDenied = "Araç şu anda kullanım halindedir";
        public static string CarColorDenied = "Girmiş olduğunuz renk kullanılmamaktadır";
        public static string CarImageLimitReached = "İlgili araç için maksimum fotoğraf sayısına eriştiniz";
        public static string AuthorizationDenied = "Yetkiniz bulunmamakta";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Erişim tokeni oluşturuldu";
    }
}
