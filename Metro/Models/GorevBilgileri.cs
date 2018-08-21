

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Metro.Models
{
    public class GorevBilgileri
    {
        public int GorevId { get; set; }
        public string Gorev_Adı { get; set; }
        public string Aciklamasi { get; set; }
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public int IsOnceligiId { get; set; }
        public string IsOnceligi { get; set; }
        //[Required(ErrorMessage = "Bu alan boş geçilemez.")]
        //[Remote("IsYoneticiExist", "Home", ErrorMessage = "There is not any user with this Id.")]
        public int YoneticiId { get; set; }
        public string Yonetici { get; set; }
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        [Remote("IsGorevliExist", "Home", ErrorMessage = "There is not any user with this Id.")]
        public int GorevliId { get; set; }
        public string Gorevli { get; set; }

    }
}