using MVCARIBILGI.dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCARIBILGI.Models
{
    public class Egitmen
    {
        SqlDataProcess data;
        public Egitmen()
        {
            data = new SqlDataProcess();
        }
        public int EgitmenID { get; set; }
        public string EgitmenAdSoyad { get; set; }
        public string EgitmenFoto { get; set; }
        public string EgitmenSifre { get; set; }
        public string EgitmenKullaniciAdi { get; set; }
        public Sinif EgitmenBrans { get; set; } // sınıf modelinden idye göre çekilecek

        public List<Egitmen> EgitmenListesiGetir()
        {
            List<Egitmen> egitmenListesi = new List<Egitmen>();
            DataTable dataTable = data.GetExecuteDataTable("Egitmen_ListeGetir", CommandType.StoredProcedure);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                egitmenListesi.Add(new Egitmen
                {
                    EgitmenID = Convert.ToInt32(dataRow["EgitmenID"]),
                    EgitmenAdSoyad = dataRow["EgitmenAdSoyad"].ToString(),
                    EgitmenFoto = dataRow["EgitmenFoto"].ToString(),
                    EgitmenBrans = new Sinif
                    {
                        Name = dataRow["SinifAdi"].ToString(),
                        Kodu = dataRow["SinifKodu"].ToString(),
                    }

                });
            }
            return egitmenListesi;
        }
        public bool EgitmenEkle()
        {
            try
            {
                return data.SetExecuteNonQuery("Insert into Egitmen (EgitmenAdSoyad,EgitmenFoto,EgitmenBrans) values (@p1,@p2,@p3)", CommandType.Text,
                    new SqlParameter("@p1", EgitmenAdSoyad),
                    new SqlParameter("@p2", EgitmenFoto),
                    new SqlParameter("@p3", EgitmenBrans.Id)
                    );

            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool EgitmenSil()
        {
            try
            {
                return data.SetExecuteNonQuery("Delete from Egitmen where EgitmenID=@Id", CommandType.Text,
                    new SqlParameter("@Id", EgitmenID));
            }
            catch (Exception)
            {
                return false;
            }

        }
        public Egitmen EgitmenGetirId()
        {
            DataTable dt = data.GetExecuteDataTable("Egitmen_Getir", CommandType.StoredProcedure, 
                new SqlParameter("@id", EgitmenID));
            Egitmen _egitmen= new Egitmen();
            if(dt.Rows.Count > 0)
            {
                _egitmen.EgitmenID = dt.Rows[0].Field<int>("EgitmenID");
                _egitmen.EgitmenAdSoyad=dt.Rows[0].Field<string>("EgitmenAdSoyad");
                _egitmen.EgitmenFoto=dt.Rows[0].Field<string>("EgitmenFoto");
                _egitmen.EgitmenBrans = new Sinif { Name = dt.Rows[0].Field<string>("SinifAdi") };
            }
            return _egitmen;
            
        }
        public bool Edit()
        {
            return data.SetExecuteNonQuery("Update Egitmen set EgitmenBrans=@p1 where EgitmenID=@p2", CommandType.Text,
                new SqlParameter("@p1", EgitmenBrans.Id),
                new SqlParameter("@p2", EgitmenID));
        }
        public bool GirisYap()
        {
            DataTable dt = data.GetExecuteDataTable("Select * from Egitmen where KullaniciAdi = @p1 and Sifre = @p2", CommandType.Text,
                new SqlParameter("@p1", EgitmenKullaniciAdi),
                new SqlParameter("@p2", EgitmenSifre));

            if (dt.Rows.Count > 0)
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