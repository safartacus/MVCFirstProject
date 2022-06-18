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
    public class EgitmenProfileController : Controller
    {
       
        // GET: EgitmenProfile
        public ActionResult Index(int Id = 0)
        {

            if (Id != 0)
            {
                Egitmen egitmen = new Egitmen();
                egitmen.EgitmenID = Id;
                ProfileDTO profileDTO = new ProfileDTO();
                profileDTO._egitmen = egitmen.EgitmenGetirId();
                Sinif _sinif = new Sinif();
                profileDTO._sinif = _sinif.ListeGetir();
                return View(profileDTO);
            }
            else
            {
                return RedirectToAction("Index", "Teacher");
            }
        }    
        [HttpPost]
        public ActionResult EditTeacher(int sinifId, int EgitmenID)
        {
            Egitmen egitmen = new Egitmen();
            egitmen.EgitmenBrans = new Sinif { Id = sinifId };
            egitmen.EgitmenID = EgitmenID;
            egitmen.Edit();
            return RedirectToAction("Index", "Teacher");

        }
    }
}