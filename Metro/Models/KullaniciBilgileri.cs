using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metro.Models
{
    public class KullaniciBilgileri
    {
        public int Kullanici_Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime? Doğum_Tarihi { get; set; }
        public string İletişim_Tipi { get; set; }
        public string İletişim_Adresi { get; set; }
        public string Pozisyon { get; set; }
    }
}