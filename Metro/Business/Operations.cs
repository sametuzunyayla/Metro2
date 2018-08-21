using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Metro.EF;
using Metro.Models;
using System.Web.Mvc;

namespace Metro.Methods
{
    public class Operations
    {

        private static JiraEntities3 dba = new JiraEntities3();
        //SOLID 
        //Sigleton Pattern --Design Pattern
        private static JiraEntities3 db;

        public static JiraEntities3 DB
        {
            get
            {
                if (db != null)
                    return db;
                else
                    return new JiraEntities3();

            }

        }





        public static List<SelectedDataModel> GetModelKategori()
        {
            List<SelectedDataModel> data = new List<SelectedDataModel>();

            data.Add(new SelectedDataModel() { Text = "Veritabanı", Value = "2" });
            data.Add(new SelectedDataModel() { Text = "Sistem Analizi", Value = "3" });
            data.Add(new SelectedDataModel() { Text = "Sap", Value = "4" });
            data.Add(new SelectedDataModel() { Text = "Web", Value = "5" });

            return data;

        }


        public static List<SelectedDataModel> GetModelOncelik()
        {
            List<SelectedDataModel> data = new List<SelectedDataModel>();

            data.Add(new SelectedDataModel() { Text = "Yüksek", Value = "1" });
            data.Add(new SelectedDataModel() { Text = "Orta", Value = "2" });
            data.Add(new SelectedDataModel() { Text = "Düşük", Value = "3" });

            return data;

        }


        public static List<SelectedDataModel> GetModelIletisim()
        {
            List<SelectedDataModel> data = new List<SelectedDataModel>();

            data.Add(new SelectedDataModel() { Text = "Tel", Value = "Tel" });////////////////////
            data.Add(new SelectedDataModel() { Text = "Email", Value = "Email"});


            return data;

        }

        public static List<SelectedDataModel> GetModelPozisyon()
        {
            List<SelectedDataModel> data = new List<SelectedDataModel>();

            data = (from c in dba.Pozisyon
                    select new SelectedDataModel
                    {
                        Text = c.Ad,
                         Value = c.Id.ToString()
                    }).ToList();

            return data;

        }

        public static List<SelectedDataModel> GetModelGorevli()
        {
            List<SelectedDataModel> data = new List<SelectedDataModel>();

            data = (from c in dba.Kullanici
                    join d in dba.Kullanici_Pozisyon_Iliskisi
                    on c.Id equals d.KullaniciId
                    join e in dba.Pozisyon
                    on d.PozisyonId equals e.Id
                    where e.YoneticiMi==false && c.AktifMi == true

                    select new SelectedDataModel
                    {
                        Text = c.Ad + " " + c.Soyad,
                        Value = c.Id.ToString()
                    }).ToList();

            return data;

        }

        public static List<SelectedDataModel> GetModelYonetici()
        {
            List<SelectedDataModel> data = new List<SelectedDataModel>();

            data = (from c in dba.Kullanici
                    join d in dba.Kullanici_Pozisyon_Iliskisi
                    on c.Id equals d.KullaniciId
                    join e in dba.Pozisyon
                    on d.PozisyonId equals e.Id
                    where e.YoneticiMi == true && c.AktifMi==true

                    select new SelectedDataModel
                    {
                        Text = c.Ad + " " + c.Soyad,
                        Value = c.Id.ToString()
                    }).ToList();

            return data;

        }



        public static int TaskInsert(GorevBilgileri model)
        {

            using (var tran = dba.Database.BeginTransaction())
            {

                try
                {

                    EF.Gorev g = new EF.Gorev() { Ad = model.Gorev_Adı, Aciklama = model.Aciklamasi, KategoriId = model.KategoriId, IsOnceligiId = model.IsOnceligiId, OlusturmaTarihi = DateTime.Now, AktifMi = true };
                    dba.Gorev.Add(g);
                    dba.SaveChanges();

                    EF.Kullanici_Gorev_Iliskisi k = new EF.Kullanici_Gorev_Iliskisi() { GorevId = g.Id, KullaniciId_Gorevli = model.GorevliId, KullaniciId_Yonetici = model.YoneticiId };
                    dba.Kullanici_Gorev_Iliskisi.Add(k);
                    dba.SaveChanges();
                    //throw new DivideByZeroException();

                    tran.Commit();

                    return g.Id;
                }
                catch (Exception)
                {
                    tran.Rollback();

                    return -999;

                    //throw ex;
                }
                //finally
                //{
                //    smsgonder(message, tel);
                //   //HER HALİKARDA çalışcak .. sms logbla bla ....
                //}
            }


        }

        public static List<GorevBilgileri> GetModelTaskList()
        {
            List<GorevBilgileri> model = new List<GorevBilgileri>();

            model = (from g in dba.Gorev
                     join k in dba.Kullanici_Gorev_Iliskisi
                     on g.Id equals k.GorevId
                     join c in dba.Kategori
                     on g.KategoriId equals c.Id
                     join s in dba.Is_Onceligi
                     on g.IsOnceligiId equals s.Id
                     join m in dba.Kullanici
                     on k.KullaniciId_Yonetici equals m.Id
                     join n in dba.Kullanici
                     on k.KullaniciId_Gorevli equals n.Id
                     where g.AktifMi == true
                     select new GorevBilgileri
                     {
                         GorevId = g.Id,
                         Gorev_Adı = g.Ad,
                         Aciklamasi = g.Aciklama,
                         KategoriAdi = c.Ad,
                         IsOnceligi = s.Ad,
                         Yonetici = m.Ad,
                         Gorevli = n.Ad
                     }).ToList();
            return model;
        }

        public static List<KullaniciBilgileri> GetModelUserList()
        {
            List<KullaniciBilgileri> model = new List<KullaniciBilgileri>();

            model = (from g in dba.Kullanici
                     join k in dba.Kullanici_Iletisim_Bilgileri
                     on g.Id equals k.KullaniciId
                     join c in dba.Kullanici_Pozisyon_Iliskisi
                     on g.Id equals c.KullaniciId
                     
                     join t in dba.Iletisim_Tipi
                     on k.IletisimTipiId equals t.Id
    
                     join pz in dba.Pozisyon
                     on c.PozisyonId equals pz.Id
                     where g.AktifMi==true

                     select new KullaniciBilgileri
                     {
                         Kullanici_Id = g.Id,
                         Ad = g.Ad,
                         Soyad = g.Soyad,
                         Doğum_Tarihi = g.DogumTarihi,
                         İletişim_Tipi =t.Ad,
                         İletişim_Adresi = t.Aciklama,
                         Pozisyon = pz.Ad,
                     }).ToList();
            var result  = dba.KullaniciBilgileri();

            return model;
        }





        public static int UpdateAktifMi(int ID)
        {
            using (var tran = dba.Database.BeginTransaction())
            {

                try
                {
                    EF.Gorev silinecekveri = dba.Gorev.FirstOrDefault(Gorev => Gorev.Id == ID);
                    silinecekveri.AktifMi = false;
                    dba.SaveChanges();

                    tran.Commit();
                    return 1;

                }
                catch (Exception)
                {
                    tran.Rollback();

                    return -999;

                }
            }
        }


        public static GorevBilgileri GetModelForEdit(int ID)
        {
            EF.Gorev g = dba.Gorev.FirstOrDefault(model => model.Id == ID);
            EF.Kullanici_Gorev_Iliskisi kgi = dba.Kullanici_Gorev_Iliskisi.FirstOrDefault(model => model.GorevId == ID);
            EF.Kategori ktg = dba.Kategori.FirstOrDefault(model => model.Id == g.KategoriId);
            EF.Is_Onceligi iso = dba.Is_Onceligi.FirstOrDefault(model => model.Id == g.IsOnceligiId);
            

            GorevBilgileri editmodel = new GorevBilgileri();
            editmodel.Gorev_Adı = g.Ad;
            editmodel.Aciklamasi = g.Aciklama;
            editmodel.KategoriAdi = ktg.Ad;
            editmodel.IsOnceligi = iso.Ad;
            editmodel.GorevliId = kgi.KullaniciId_Gorevli;
            editmodel.YoneticiId = kgi.KullaniciId_Yonetici;
            return editmodel;
        }

        public static int TaskEdit(int ID, GorevBilgileri yeniveri)
        {
            using (var tran = dba.Database.BeginTransaction())
            {

                try
                {
                    EF.Gorev eski_gorev = dba.Gorev.FirstOrDefault(model => model.Id == ID);
                    eski_gorev.Ad = yeniveri.Gorev_Adı;
                    eski_gorev.IsOnceligiId = yeniveri.IsOnceligiId;
                    eski_gorev.KategoriId = yeniveri.KategoriId;
                    eski_gorev.Aciklama = yeniveri.Aciklamasi;
                    dba.SaveChanges();
                    EF.Kullanici_Gorev_Iliskisi eski_iliski = dba.Kullanici_Gorev_Iliskisi.FirstOrDefault(model => model.GorevId == eski_gorev.Id);
                    eski_iliski.KullaniciId_Gorevli = yeniveri.GorevliId;
                    eski_iliski.KullaniciId_Yonetici = yeniveri.YoneticiId;
                    dba.SaveChanges();



                    tran.Commit();
                    return 1;

                }
                catch (Exception)
                {
                    tran.Rollback();

                    return -999;

                }
            }


        }

        public static EF.Giris_Bilgileri LoginCheck(GirisBilgileri model)
        {
            var kullanicilar = dba.Giris_Bilgileri.FirstOrDefault(x => x.KullaniciAdi == model.UserName && x.Sifre == model.Password);
            return kullanicilar;

        }


        public static int UserRegister(KullanıcıKayıt model)
        {

            using (var tran = dba.Database.BeginTransaction())
            {

                try
                {

                    EF.Kullanici k = new EF.Kullanici() { Ad = model.Ad, Soyad = model.Soyad, DogumTarihi = model.Doğum_Tarihi,OlusturmaTarihi=DateTime.Now,AktifMi=true };
                    dba.Kullanici.Add(k);
                    dba.SaveChanges();
                    EF.Iletisim_Tipi i = new EF.Iletisim_Tipi() { Ad = model.İletişim_Tipi, Aciklama = model.İletişim_Adresi };
                    dba.Iletisim_Tipi.Add(i);
                    dba.SaveChanges();
                    EF.Kullanici_Iletisim_Bilgileri kib = new EF.Kullanici_Iletisim_Bilgileri() { IletisimTipiId = i.Id, KullaniciId = k.Id };
                    dba.Kullanici_Iletisim_Bilgileri.Add(kib);
                    EF.Giris_Bilgileri g = new EF.Giris_Bilgileri() { KullaniciAdi = model.Kullanıcı_Adı, Sifre = model.Şifre, KullaniciId = k.Id };
                    dba.Giris_Bilgileri.Add(g);
                    EF.Kullanici_Pozisyon_Iliskisi kpi = new EF.Kullanici_Pozisyon_Iliskisi { KullaniciId = k.Id, PozisyonId = model.Pozisyon_Id };
                    dba.Kullanici_Pozisyon_Iliskisi.Add(kpi);
                    dba.SaveChanges();

                    tran.Commit();

                    return 1;
                }
                catch (Exception ex)
                {
                    tran.Rollback();

                    return -999;


                }

            }

        }

        public static bool IsUserAvailable(string Kullanıcı_Adı)
        {
            var count = dba.Kullanici.Count(x => x.Ad.Equals(Kullanıcı_Adı));

            if (count == 0)
                return true;
            else
                return false;
        }

        public static bool GorevliVarMı(int GorevliId)
        {
            var count = dba.Kullanici.Count(x => x.Id.Equals(GorevliId));

            if (count == 0)
                return false;
            else
                return true;
        }

        public static bool YoneticiVarMı(int YoneticiId)
        {
            var count = dba.Kullanici.Count(x => x.Id.Equals(YoneticiId));

            if (count == 0)
                return false;
            else
                return true;
        }




































    }
}
