using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCARIBILGI.Models
{
    public class DersProgramiDTO
    {
        public List<Sinif> Siniflar { get; set; }
        public List<DersProgrami> dersProgramis { get; set; }
        
    }
}