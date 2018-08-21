using Metro.EF;
using Metro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Metro.Methods;

namespace Metro.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private JiraEntities3 db = new JiraEntities3();


        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(GirisBilgileri model)
        {

            if (Operations.LoginCheck(model)!=null) { Session["Email"] = Operations.LoginCheck(model); return RedirectToAction("Anasayfa", "Home"); }
            else { ViewBag.Hata = "Kullanıcı adı veye şifre hatalı"; return View(); }
        }
           
                
           
        public ActionResult Kayıt()
        {
            ViewBag.Ad = new SelectList(Operations.GetModelIletisim(), "Value", "Text");
            ViewBag.Pozisyon_Id = new SelectList(Operations.GetModelPozisyon(), "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult Kayıt(KullanıcıKayıt kisi)
        {
            ViewBag.Ad = new SelectList(Operations.GetModelIletisim(), "Value", "Text");
            ViewBag.Pozisyon_Id = new SelectList(Operations.GetModelPozisyon(), "Value", "Text");
            if (Operations.UserRegister(kisi) != -999) return RedirectToAction("Giris");
            else { ViewBag.Hata = "Kayıt başarısız."; return View(); }
        }
        
        public  JsonResult IsAlreadySigned(string Kullanıcı_Adı)
        {
            //Kullanıcı Adını db den kontol eden op. nesnesi içerinde tanımlı bir mmethod yap var yok yapsın varsa treu yoksa false
            var result = Operations.IsUserAvailable(Kullanıcı_Adı);
            return Json(result,JsonRequestBehavior.AllowGet); 
        }

        


        public ActionResult Cıkıs()
        {
            Session.RemoveAll();
            return RedirectToAction("Giris", "Login");
        }

    }

}