using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCARIBILGI.Models
{
    public class ProfileDTO
    {
        public Ogrenci _ogrenci { get; set; }
        public List<Sinif> _sinif { get; set; }
        public Egitmen _egitmen { get; set; }
    }
}