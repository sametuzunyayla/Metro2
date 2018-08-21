using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metro.Models
{
    public class ActModel
    {
        public ActModel()
        {
            Gorev=new Gorev();
            Giris_Bilgileri=new Giris_Bilgileri();
            Iletisim_Tipi=new Iletisim_Tipi();
            IsOnceligi=new IsOnceligi();
            Kategori=new Kategori();
            Kullanici=new Kullanici();
            Kullanici_Gorev_Iliskisi=new Kullanici_Gorev_Iliskisi();
            Kullanici_Iletisim_Bilgileri=new Kullanici_Iletisim_Bilgileri();
            Kullanici_Pozisyon_Iliskisi=new Kullanici_Pozisyon_Iliskisi();
            Pozisyon=new Pozisyon();

        }

        public Gorev Gorev { get; set; }
        public Giris_Bilgileri Giris_Bilgileri { get; set; }
        public Iletisim_Tipi Iletisim_Tipi { get; set; }
        public IsOnceligi IsOnceligi { get; set; }
        public Kategori Kategori { get; set; }
        public Kullanici Kullanici { get; set; }
        public Kullanici_Gorev_Iliskisi Kullanici_Gorev_Iliskisi { get; set; }
        public Kullanici_Iletisim_Bilgileri Kullanici_Iletisim_Bilgileri { get; set; }
        public Kullanici_Pozisyon_Iliskisi Kullanici_Pozisyon_Iliskisi { get; set; }
        public Pozisyon Pozisyon { get; set; }



    }
}