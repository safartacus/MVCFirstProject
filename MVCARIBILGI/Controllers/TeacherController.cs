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
    public class TeacherController : Controller
    {

        
        // GET: Teacher
        public ActionResult Index()
        {
            Egitmen egitmen = new Egitmen();
            Sinif sinif = new Sinif();
            EgitmenDTO egitmenDTO = new EgitmenDTO();
            egitmenDTO.Egitmenler = egitmen.EgitmenListesiGetir();
            egitmenDTO.Siniflar = sinif.ListeGetir();
            return View(egitmenDTO);
        }
        [HttpPost]
        public ActionResult EgitmenEkle(string EgitmenAdi, string EgitmenFoto, int sinifId)
        {
            Egitmen egitmen = new Egitmen();
            egitmen.EgitmenAdSoyad = EgitmenAdi;
            egitmen.EgitmenFoto= EgitmenFoto;
            egitmen.EgitmenBrans = new Sinif { Id=sinifId };

            if (egitmen.EgitmenEkle())
            {
                return RedirectToAction("Index", "Teacher");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public bool Delete(int id)
        {
            Egitmen egitmen = new Egitmen();
            egitmen.EgitmenID= id;
            egitmen.EgitmenSil();
            return true;
        }
    }
}