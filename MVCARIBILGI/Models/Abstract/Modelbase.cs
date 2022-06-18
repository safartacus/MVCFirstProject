using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCARIBILGI.Models.Abstract
{
    public abstract class Modelbase
    {
        public Modelbase()
        {
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}