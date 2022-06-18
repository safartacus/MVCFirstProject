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
    public class ClassController : Controller
    {


        public ActionResult Index()
        {
            Sinif sinif = new Sinif();
            return View(sinif.ListeGetir());


        }
        [HttpPost]
        public ActionResult ClassAdd(string SinifAdi, string SinifKodu)
        {
            Sinif sinif = new Sinif();
            sinif.Name = SinifAdi;
            sinif.Kodu = SinifKodu;
            


            if (sinif.SinifEkle())
            {
                return RedirectToAction("Index", "Class");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public bool Delete(int id)
        {
            Sinif sinif = new Sinif();
            sinif.Id = id;
            if (sinif.SinifSil())
            {
                return true;
            }
            else
            {
                return false;
            }


        }

    }
}