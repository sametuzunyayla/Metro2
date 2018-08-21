using Metro.EF;
using System;
using Metro.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Metro.Methods;

namespace Metro.Controllers
{
    [SessionExpire]
    public class HomeController : Controller
    {
        // GET: Home
        private JiraEntities3 database = new JiraEntities3();

        public ActionResult Anasayfa()
        {
            return View();
        }


        public ActionResult GorevEkle()
        {
             ViewBag.KategoriId = new SelectList(Operations.GetModelKategori(), "Value", "Text");
             ViewBag.IsOnceligiId = new SelectList(Operations.GetModelOncelik(), "Value", "Text");
            ViewBag.GorevliId = new SelectList(Operations.GetModelGorevli(), "Value", "Text");
            ViewBag.YoneticiId = new SelectList(Operations.GetModelYonetici(), "Value", "Text");
            return View();

        }
        [HttpPost]
        public ActionResult GorevEkle(GorevBilgileri model)
        {
            ViewBag.KategoriId = new SelectList(Operations.GetModelKategori(), "Value", "Text");
            ViewBag.IsOnceligiId = new SelectList(Operations.GetModelOncelik(), "Value", "Text");
            ViewBag.GorevliId = new SelectList(Operations.GetModelGorevli(), "Value", "Text");
            ViewBag.YoneticiId = new SelectList(Operations.GetModelYonetici(), "Value", "Text");

            if (Operations.TaskInsert(model) == -999) { ViewBag.Hata = "Görev eklenemedi."; return View(); }
            else return RedirectToAction("Anasayfa", "Home");
        }

        public JsonResult IsGorevliExist(int GorevliId)
        {

            var result = Operations.GorevliVarMı(GorevliId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult IsYoneticiExist(int YoneticiId)
        //{

        //    var result = Operations.YoneticiVarMı(YoneticiId);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}



        public ActionResult GorevListele()
        {
            return View(Operations.GetModelTaskList());
        }

        public ActionResult KullanıcıListele()
        {
            return View(Operations.GetModelUserList());
        }

        public ActionResult Delete(int ID)
        {
                if(Operations.UpdateAktifMi(ID)==-999) { ViewBag.Hata = "Görev silinemedi."; }
                return RedirectToAction("GorevListele", "Home");
        }



        public ActionResult Edit(int ID)
        {
            ViewBag.KategoriId = new SelectList(Operations.GetModelKategori(), "Value", "Text");
            ViewBag.IsOnceligiId = new SelectList(Operations.GetModelOncelik(), "Value", "Text");
            return View(Operations.GetModelForEdit(ID));         
        }
        [HttpPost]
        public ActionResult Edit(int ID,GorevBilgileri  yeniveri)
        {
            if(Operations.TaskEdit(ID,yeniveri)==-999) { ViewBag.Hata = "Görev düzenleme başarısız.";return View(); }
            else return RedirectToAction("GorevListele", "Home");
        }


    }


}