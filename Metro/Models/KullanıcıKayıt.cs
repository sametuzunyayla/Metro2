using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Remoting;
using System.Web.Mvc;


namespace Metro.Models
{
    public class KullanıcıKayıt
    {
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Soyad { get; set; }
        [DataType(DataType.DateTime,ErrorMessage ="Geçerli bir tarih giriniz.")]
        public DateTime Doğum_Tarihi { get; set;}
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string İletişim_Tipi { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string İletişim_Adresi { get; set; }
        //[Required(ErrorMessage = "Bu alan boş geçilemez.")]
        //[Remote("IsPozitionValid", "Login", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public int Pozisyon_Id { get; set; }
        [Required(ErrorMessage ="Bu alan boş geçilemez.")]
        //[Display(Name = "KULLANICI ADI")]
        [Remote("IsAlreadySigned", "Login", ErrorMessage = "User name already exists. Please enter a different user name.")]
        
        public string Kullanıcı_Adı { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Şifre { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Şifre", ErrorMessage = "The password and confirmation password do not match.")]
        public string Şifre_Dogrula { get; set; }



    }
}