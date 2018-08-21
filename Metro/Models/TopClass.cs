using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Metro.Models
{

    public class Gorev
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public int KategoriId { get; set; }
        public int IsOnceligiId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public bool AktifMi { get; set; }

    }

    public class Giris_Bilgileri
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }


    }

    public class Iletisim_Tipi
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public bool AktifMi { get; set; }

    }

    public class IsOnceligi
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public bool AktifMi { get; set; }

    }

    public class Kategori
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public bool AktifMi { get; set; }

    }

    public class Kullanici
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public bool AktifMi { get; set; }

    }

    public class Kullanici_Gorev_Iliskisi
    {
        public int Id { get; set; }
        public int GorevId { get; set; }
        public int KullaniciId_Gorevli { get; set; }
        public int KullaniciId_Yonetici { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public bool AktifMi { get; set; }

    }

    public class Kullanici_Iletisim_Bilgileri
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int IletisimTipiId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public bool AktifMi { get; set; }

    }

    public class Kullanici_Pozisyon_Iliskisi
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int PozisyonId { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public bool AktifMi { get; set; }

    }

    public class Pozisyon
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int Seviye { get; set; }
        public int UstPozisyonId { get; set; }
        public bool YoneticiMi { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public bool AktifMi { get; set; }

    }

}