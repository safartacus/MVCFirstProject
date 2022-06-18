using MVCARIBILGI.dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCARIBILGI.Models
{
    public class Ogrenci 
    {
        SqlDataProcess data;

        public Ogrenci()
        {
            data = new SqlDataProcess();
        }

        public int OgrenciId { get; set; }
        public string OgrenciName { get; set; }
        public string OgrenciNo { get; set; }
        public int SinifId { get; set; }
        public Sinif _Sınıf { get; set; }

        public List<Ogrenci> OgrenciListeGetir()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            DataTable dtOgrenci =  data.GetExecuteDataTable("Ogrenci_ListeGetir", CommandType.StoredProcedure);
            foreach (DataRow dataRow in dtOgrenci.Rows)
            {
                ogrenciler.Add(new Ogrenci
                {
                    OgrenciId = Convert.ToInt32(dataRow["Id"]),
                    OgrenciName = dataRow["Adsoyad"].ToString(),
                    OgrenciNo=dataRow["OgrenciNo"].ToString(),
                    _Sınıf = new Sinif
                    {
                        Name= dataRow["SinifAdi"].ToString(),
                        Kodu= dataRow["SinifKodu"].ToString(),
                    }
                    
                });
            }
            return ogrenciler;
        }
        public List<Ogrenci> OgrenciListeGetirByID()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();

            DataTable dtOgrenci = data.GetExecuteDataTable("Ogrenci_ListeGetirSinifId", CommandType.StoredProcedure,
                new SqlParameter("@SinifId", SinifId));
            foreach (DataRow dataRow in dtOgrenci.Rows)
            {
                ogrenciler.Add(new Ogrenci
                {
                    
                    OgrenciId = Convert.ToInt32(dataRow["Id"]),
                    OgrenciName = dataRow["Adsoyad"].ToString(),
                    OgrenciNo = dataRow["OgrenciNo"].ToString(),
                    

                });
            }
            return ogrenciler;
        }
        public bool OgrenciEkle()
        {
            try
            {
                return data.SetExecuteNonQuery("Insert into Ogrenci (AdSoyad,OgrenciNo,SinifID) values (@p1,@p2,@p3)", CommandType.Text,
                    new SqlParameter("@p1", OgrenciName),
                    new SqlParameter("@p2", OgrenciNo),
                    new SqlParameter("@p3", _Sınıf.Id));
                
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool OgrenciSil()
        {
            try
            {
                return data.SetExecuteNonQuery("Delete from Ogrenci where Id=@Id",CommandType.Text,
                    new SqlParameter("@Id", OgrenciId));
            }
            catch (Exception)
            {
                return false;
            }

        }
        public Ogrenci OgrenciGetirId()
        {
            DataTable dataTable = data.GetExecuteDataTable("Ogrenci_Getir", CommandType.StoredProcedure,
                new SqlParameter("@id" , OgrenciId));
            Ogrenci _ogrenci = new Ogrenci();
            if(dataTable.Rows.Count > 0)
            {
                _ogrenci.OgrenciId = dataTable.Rows[0].Field<int>("Id");
                _ogrenci.OgrenciName = dataTable.Rows[0].Field<string>("AdSoyad");
                _ogrenci.OgrenciNo = dataTable.Rows[0].Field<string>("OgrenciNo");
                _ogrenci._Sınıf = new Sinif { Name = dataTable.Rows[0].Field<string>("SinifAdi") };
                
            }
            return _ogrenci;


        }
        public bool Edit()
        {
            return data.SetExecuteNonQuery("Update Ogrenci set SinifID=@p1 where Id=@p2", CommandType.Text,
                new SqlParameter("@p1", _Sınıf.Id),
                new SqlParameter("@p2", OgrenciId));
        }
    }
}