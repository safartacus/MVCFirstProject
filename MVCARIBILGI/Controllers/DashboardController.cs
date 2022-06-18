using MVCARIBILGI.Core;
using MVCARIBILGI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MVCARIBILGI.Controllers
{
    [SessionControl]
    public class DashboardController : Controller
    {
        //cqrs
        //Dokker Container Mimarisi Araştır.
        //Hocam Projemizde çok önemli bir açık var
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RollCall()
        {
            DersProgrami dersProgrami = new DersProgrami();
            Sinif sinif = new Sinif();
            dersProgrami.KullaniciAdi = Session["Kullanici"].ToString();
            DersProgramiDTO dersProgramiDTO = new DersProgramiDTO();
            dersProgramiDTO.dersProgramis = dersProgrami.DersProgramiGetir();
            dersProgramiDTO.Siniflar = sinif.ListeGetir();
            return View(dersProgramiDTO);
        }
        [HttpPost]
        public JsonResult GetListByID(int sinifId)
        {
           
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.SinifId = sinifId;
            return Json(ogrenci.OgrenciListeGetirByID());
        }
    }
}