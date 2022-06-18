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
    public class Sinif:Modelbase
    {
        SqlDataProcess data;
        public Sinif()
        {
            data = new SqlDataProcess();
        }
        
        public string Name { get; set; }
        public string Kodu { get; set; }

        public List<Sinif> ListeGetir()
        {
            List<Sinif> siniflar = new List<Sinif>();
            DataTable dtSiniflar = data.GetExecuteDataTable("Select * from Sinif", CommandType.Text);
            foreach (DataRow dataRow in dtSiniflar.Rows)
            {
                siniflar.Add(new Sinif
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    Name = dataRow["SinifAdi"].ToString(),
                    Kodu = dataRow["SinifKodu"].ToString(),

                });
            }
            return siniflar;
        }
        public bool SinifEkle()
        {
            try
            {
                return data.SetExecuteNonQuery("Insert into Sinif (SinifAdi,SinifKodu) values (@p1,@p2)", CommandType.Text,
                     new SqlParameter("@p1", Name),
                     new SqlParameter("@p2", Kodu));

            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool SinifSil()
        {
            try
            {
               return data.SetExecuteNonQuery("Delete from Sinif where Id=@p1",CommandType.Text,
                    new SqlParameter("@p1", Id));
                
            }
            catch (Exception)
            {

                return false;
            }

        }
        public Sinif SinifGetirId()
        {
            DataTable dataTable = data.GetExecuteDataTable("Select * from Sinif where @id=Id", CommandType.Text,
                new SqlParameter("@id", Id));
            Sinif sinif = new Sinif();
            if (dataTable.Rows.Count > 0)
            {
                sinif.Id = dataTable.Rows[0].Field<int>("Id");
                sinif.Name = dataTable.Rows[0].Field<string>("SinifAdi");
                sinif.Kodu = dataTable.Rows[0].Field<string>("SinifKodu");
                

            }
            return sinif;


        }

    }
}