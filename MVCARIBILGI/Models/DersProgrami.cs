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
    public class DersProgrami:Modelbase
    {
        SqlDataProcess data;
        public DersProgrami()
        {
            data = new SqlDataProcess();
        }
        
        public string KullaniciAdi { get; set; }
        public Sinif SinifID { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public string Adi { get; set; }

        public List<DersProgrami> DersProgramiGetir()
        {
            List<DersProgrami> dersProgrami = new List<DersProgrami>();
            DataTable dataTable = data.GetExecuteDataTable("DersProgrami_Getir", CommandType.StoredProcedure,
                new SqlParameter("@KullaniciAdi",KullaniciAdi));
            foreach (DataRow dataRow in dataTable.Rows)
            {
                dersProgrami.Add(new DersProgrami
                {
                    Id= Convert.ToInt32(dataRow["ID"].ToString()),
                    Tarih = Convert.ToDateTime( dataRow["Tarih"].ToString()),
                    Baslangic = Convert.ToDateTime(dataRow["Baslangic"].ToString()),
                    Bitis = Convert.ToDateTime(dataRow["Bitis"].ToString()),
                    Adi = dataRow["DersAdi"].ToString(),
                    SinifID = new Sinif
                    {
                        Id = Convert.ToInt32(dataRow["SinifID"].ToString()),
                        Name = dataRow["SinifAdi"].ToString()
                        

                    }

                });
            }
            return dersProgrami;
        }
        public bool DersProgramiEkle()
        {
            try
            {
                return data.SetExecuteNonQuery("Insert into DersProgramı (SinifID,Baslangic,Bitis,Tarih,DersAdi) values (@p1,@p2,@p3,@p4,@p5)", CommandType.Text,
                    new SqlParameter("@p1", SinifID.Id),
                    new SqlParameter("@p2", Baslangic),
                    new SqlParameter("@p3", Bitis),
                    new SqlParameter("@p4", Tarih),
                    new SqlParameter("@p5", Adi));
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}