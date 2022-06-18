using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCARIBILGI.dal
{
    public static class ConnectionString
    {
        private static string _connection ="Data Source=DESKTOP-DVJ18QA\\SQLEXPRESS; Initial Catalog=YonetimPaneli; Integrated Security=True";

        public static string Connection { get { return _connection; } }
    }
}