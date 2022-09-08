using System;
using System.Collections.Generic;
using System.Data; // Veritabanı İşlemleri için gerekli 
using System.Data.SqlClient; // Adonet Kütüphaneleri 

namespace WindowsFormsAppAdoNet
{
    public class ProductDAL
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

        public DataTable GetDataTable()
        {
            ConnectionKontrol(); // Bağlantıyı kontrol et 
            DataTable dt = new DataTable(); // Boş bir datatable listesi oluştur
            SqlCommand command = new SqlCommand("select * from Products", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader); // dt tablosuna reader ile veritabanından okunan verileri yükle
            reader.Close(); // Veri okuyucuyu kapat
            command.Dispose(); // Sql komut nesnesini kapat
            connection.Close(); // Veritabanı bağlantısını kapat
            return dt; // Metodun çağırıldığı yere dt(data tablosunu) gönder.
        }

        public int Add(Product product)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Insert into Products (UrunAdi, UrunFiyati, StokMiktari) values (@UrunAdi, @UrunFiyati, @Stok)", connection); // Sql komutu olarak bu sefer insert komutu yazdık
            command.Parameters.AddWithValue("@UrunAdi", product.UrunAdi);
            command.Parameters.AddWithValue("@UrunFiyati", product.UrunFiyati);
            command.Parameters.AddWithValue("@Stok", product.StokMiktari);
            int islemSonucu = command.ExecuteNonQuery(); // ExecuteNonQuery metodu geriye veritabanında etkilenen kayıt sayısını döner
            command.Dispose(); // Sql komut nesnesni kapat 
            connection.Close(); // Veritabanı bağlantısını kapat
            return islemSonucu; // Metodunuz geriye int döndüğü için islemSonucu değişkenini geri döndürüyoruz
        }
        public Product GetProduct(string id)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("select * from Products where Id = " + id, connection);
            SqlDataReader reader = command.ExecuteReader();
            Product product = new Product();

            while (reader.Read())
            {

                product.Id = Convert.ToInt32(reader["ID"]);
                product.UrunAdi = reader["UrunAdi"].ToString();
                product.StokMiktari = Convert.ToInt32(reader["StokMiktari"]);
                product.UrunFiyati = Convert.ToDecimal(reader["UrunFiyati"]);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return product;
        }

        public int Update(Product product)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Update Products set UrunAdi = @UrunAdi, UrunFiyati = @UrunFiyati, StokMiktari = @Stok where Id = @UrunId", connection); // Sql komutu olarak bu sefer insert komutu yazdık
            command.Parameters.AddWithValue("@UrunAdi", product.UrunAdi);
            command.Parameters.AddWithValue("@UrunFiyati", product.UrunFiyati);
            command.Parameters.AddWithValue("@Stok", product.StokMiktari);
            command.Parameters.AddWithValue("@UrunId", product.Id);

            int islemSonucu = command.ExecuteNonQuery(); // ExecuteNonQuery metodu geriye veritabanında etkilenen kayıt sayısını döner
            command.Dispose(); // Sql komut nesnesni kapat 
            connection.Close(); // Veritabanı bağlantısını kapat
            return islemSonucu; // Metodunuz geriye int döndüğü için islemSonucu değişkenini geri döndürüyoruz
        }
        public int Delete(string id)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Delete from Products where Id=@urunId", connection);
            command.Parameters.AddWithValue("@urunId", id);
            int islemSonucu = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return islemSonucu;
        }
    }
}
