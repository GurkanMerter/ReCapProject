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
        internal static string CarColorDenied = "Girmiş olduğunuz renk kullanılmamaktadır";
        internal static string CarImageLimitReached = "İlgili araç için maksimum fotoğraf sayısına eriştiniz";
    }
}
