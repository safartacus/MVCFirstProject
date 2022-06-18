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
    public class StudentController : Controller
    {
        
        // GET: Student
        public ActionResult Index()
        {
            Ogrenci ogrenci = new Ogrenci();
            Sinif sinif = new Sinif();
            OgrenciDTO ogrenciDTO = new OgrenciDTO();
            ogrenciDTO.Ogrenciler = ogrenci.OgrenciListeGetir();
            ogrenciDTO.Siniflar = sinif.ListeGetir();
            return View(ogrenciDTO);


        }
        [HttpPost]
        public ActionResult OgrenciAdd(string OgrenciAdi, string OgrenciNo, int sinifId)
        {
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.OgrenciName = OgrenciAdi;
            ogrenci.OgrenciNo = OgrenciNo;
            ogrenci._Sınıf = new Sinif { Id = sinifId };


            if (ogrenci.OgrenciEkle())
            {
                return RedirectToAction("Index", "Student");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public bool Delete(int id)
        {
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.OgrenciId = id;
            ogrenci.OgrenciSil();
            return true;
        }

    }
}