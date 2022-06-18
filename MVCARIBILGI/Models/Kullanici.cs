using MVCARIBILGI.dal;
using MVCARIBILGI.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCARIBILGI.Models
{
    public class Kullanici:Modelbase
    {
        SqlDataProcess data;

        public Kullanici()
        {
            data = new SqlDataProcess();
        }

        
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string AdSoyad { get; set; }
        public bool GirisYap()
        {
            DataTable dt = data.GetExecuteDataTable("Select * from Kullanici where kullanicid = @p1 and sifre = @p2", CommandType.Text, 
                new SqlParameter("@p1", KullaniciAdi), 
                new SqlParameter("@p2", Sifre));
            
            
            if (dt.Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        public List<Kullanici> TumKullanicilariGetir()
        {
            List<Kullanici> kullanicilar = new List<Kullanici>();
            DataTable dtKullaniciListesi = data.GetExecuteDataTable("Select * from Kullanici where Silindi=0", CommandType.Text);
            foreach (DataRow dataRow in dtKullaniciListesi.Rows)
            {
                kullanicilar.Add(new Kullanici
                {
                    Id = Convert.ToInt32(dataRow["id"]),
                    KullaniciAdi = dataRow["kullanicid"].ToString(),
                    Sifre = dataRow["sifre"].ToString(),
                    AdSoyad = dataRow["AdSoyad"].ToString()
                });
            }
            return kullanicilar;
        }
        public bool KullaniciEkle()
        {
            try
            {
                
                return data.SetExecuteNonQuery("insert into Kullanici(kullanicid,sifre,Adsoyad) values (@p1,@p2,@p3)",CommandType.Text,
                    new SqlParameter("@p1", KullaniciAdi),
                    new SqlParameter("@p2", Sifre),
                    new SqlParameter("@p3", AdSoyad));
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool KullaniciSil()
        {
            try
            {
               return data.SetExecuteNonQuery("Update  Kullanici set Silindi=1 where id=@Id", CommandType.Text,
                    new SqlParameter("@Id", Id));
            }
            catch (Exception)
            {

                return false;
            }

        }

        public Kullanici KullaniciDetayGetir()
        {
            Kullanici kullanici = new Kullanici();
            DataTable dtKullanici = data.GetExecuteDataTable("Select * from Kullanici where Silindi=0 and id=@Id", CommandType.Text,
                new SqlParameter("Id", Id));
            if (dtKullanici.Rows.Count > 0)
            {
                kullanici.AdSoyad = dtKullanici.Rows[0]["Adsoyad"].ToString();
                kullanici.KullaniciAdi = dtKullanici.Rows[0]["kullanicid"].ToString();
            }
            return kullanici;
        }
    }
}