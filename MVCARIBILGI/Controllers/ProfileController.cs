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
    public class ProfileController : Controller
    {
        
        public ActionResult Index(int Id = 0)
        {

            if (Id != 0)
            {
                Ogrenci ogrenci = new Ogrenci();
                ogrenci.OgrenciId = Id;
                ProfileDTO profileDTO = new ProfileDTO();
                profileDTO._ogrenci = ogrenci.OgrenciGetirId();
                Sinif _sinif = new Sinif();
                profileDTO._sinif = _sinif.ListeGetir();
                return View(profileDTO);
            }
            else
            {
                return RedirectToAction("Index", "Student");
            }


        }
        [HttpPost]
        public ActionResult Edit(int sinifId, int Id)
        {
            Ogrenci ogrenci = new Ogrenci();
            ogrenci._Sınıf = new Sinif { Id = sinifId };
            ogrenci.OgrenciId = Id;
            ogrenci.Edit();
            return RedirectToAction("Index", "Student");

        }
        [HttpGet]
        public ActionResult SinifProfile(int id)
        {
            Sinif sinif = new Sinif();
            sinif.Id = id;
            var value =sinif.SinifGetirId();
            return View(value);        
        }
        [HttpPost]
        public ActionResult ProgramEkle(int Id ,string dersAdi,DateTime dersTarih,DateTime dersBaslangıcSaati,DateTime dersBitisSaati)
        {
            DersProgrami dersProgrami = new DersProgrami();
            dersProgrami.Adi= dersAdi;
            dersProgrami.Tarih= dersTarih;
            dersProgrami.Baslangic = dersBaslangıcSaati;
            dersProgrami.Bitis = dersBitisSaati;
            dersProgrami.SinifID = new Sinif {Id= Id };
            if (dersProgrami.DersProgramiEkle())
            {
                return RedirectToAction("Index", "Class");
            }
            else
            {
                return View(); 
            }
            
        }





    }
}