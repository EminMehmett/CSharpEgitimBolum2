using System;
using System.Collections.Generic;
using System.Linq;
using System.Data; // Veritabanı İşlemleri için gerekli 
using System.Data.SqlClient; // Adonet Kütüphaneleri 

namespace WindowsFormsAppAdoNet
{
    internal class ProductDAL
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=UrunYonetimiAdoNet; integrated security=true"); // SqlConnection veritabanına bağlanmak için kullandığımız ado net sınıfıdır. Parametre olarak kendisine verilen bilgilerdeki veritabanına bağlanır.
        void ConnectionKontrol() // void = tek (İşini Yap Bitir)
        {
            if (connection.State == ConnectionState.Closed) // Eğer yukarıda tanımladığımız veritabanı bağlantısı kapalıysa 
            {
                connection.Open(); // Bağlantıyı Aç 
            }
        }
        public List<Product> GetAll() // Bu metodun geri dönüş değeri List<Product> yani ürün listesi
        {
            ConnectionKontrol(); // BU metot çalıştığı anda bağlantıyı kontrol et 
            List<Product> urunListesi = new List<Product>(); // Geriye döndüreceğimiz List<Product> nesnesini oluşturduk

            SqlCommand command = new SqlCommand("select * from Products", connection); // SqlCommand sql komutlarını çalıştırabilmemizi sağlayan ado net sınıfı. Tırnaklar içerisine sql komutumuzu, sonraki parametrede de bu komutun çalıştırılacağı connection nesnesini belirtiyoruz.
            SqlDataReader reader = command.ExecuteReader(); // SqlDataReader sql veri okuyucu sınıfıdır, bu snıfa üstteki commad nesnesini ExecuteReader metoduyla çalıştırmasını söyledik.

            while (reader.Read()) //reader db de okuyacak kayıt bulduğu sürece 
            {
                Product product = new Product() // Döngü her döndüğünde içi boş yeni ürün oluşturuyoruz
                {
                    // Aşağıda veritabanından gelen verilerle ürün bilgilerini dolduruyoruz 
                    Id = Convert.ToInt32(reader["ID"]),
                    UrunAdi = reader["UrunAdi"].ToString(),
                    StokMiktari = Convert.ToInt32(reader["StokMiktari"]),
                    UrunFiyati = Convert.ToDecimal(reader["UrunFiyati"])
                };
                urunListesi.Add(product); /// İçi doldurulan product nesnesini yukarıda oluşturduğumuz products listesine ekliyoruz.
            }
            reader.Close(); // Veri okuyucuyu kapat
            command.Dispose(); // Sql komut nesnesini kapat 
            connection.Close(); // Veritabanı bağlantısını kapat
            return urunListesi;
        }
    }
}
