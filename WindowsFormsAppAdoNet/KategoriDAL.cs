using System;
using System.Data; // Veritabanı İşlemleri için gerekli 
using System.Data.SqlClient; // Adonet Kütüphaneleri 

namespace WindowsFormsAppAdoNet
{
    public class KategoriDAL
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=UrunYonetimiAdoNet; integrated security=true");


        void ConnectionKontrol() // void = tek (İşini Yap Bitir)
        {
            if (connection.State == ConnectionState.Closed) // Eğer yukarıda tanımladığımız veritabanı bağlantısı kapalıysa 
            {
                connection.Open(); // Bağlantıyı Aç 
            }
        }


        public DataTable GetDataTable()
        {
            ConnectionKontrol(); // Bağlantıyı kontrol et 
            DataTable dt = new DataTable(); // Boş bir datatable listesi oluştur
            SqlCommand command = new SqlCommand("select * from Kategoriler", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader); // dt tablosuna reader ile veritabanından okunan verileri yükle
            reader.Close(); // Veri okuyucuyu kapat
            command.Dispose(); // Sql komut nesnesini kapat
            connection.Close(); // Veritabanı bağlantısını kapat
            return dt; // Metodun çağırıldığı yere dt(data tablosunu) gönder.
        }


        public int Add(Kategori kategori)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Insert into Kategoriler ( KategoriAdi, Durum) values (@KategoriAdi, @Durum)", connection); // Sql komutu olarak bu sefer insert komutu yazdık
            command.Parameters.AddWithValue("@KategoriAdi", kategori.KategoriAdi);
            command.Parameters.AddWithValue("@Durum", kategori.Durum);
            int islemSonucu = command.ExecuteNonQuery(); // ExecuteNonQuery metodu geriye veritabanında etkilenen kayıt sayısını döner
            command.Dispose(); // Sql komut nesnesni kapat 
            connection.Close(); // Veritabanı bağlantısını kapat
            return islemSonucu; // Metodunuz geriye int döndüğü için islemSonucu değişkenini geri döndürüyoruz
        }

        public Kategori Get(string id)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("select * from Kategoriler where Id = " + id, connection);
            SqlDataReader reader = command.ExecuteReader();
            Kategori kategori = new Kategori();

            while (reader.Read())
            {

                kategori.Id = Convert.ToInt32(reader["ID"]);
                kategori.KategoriAdi = reader["KategoriAdi"].ToString();
                kategori.Durum = Convert.ToBoolean(reader["Durum"]);
            }
            reader.Close(); // veri okuyucuyu kapat 
            command.Dispose(); // sql kommut nesnesini kapat 
            connection.Close(); // veritabanı bağlantısını kapat 
            return kategori;
        }

        public int Update(Kategori kategori)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Update Kategoriler set KategoriAdi=@KategoriAdi, Durum=@Durum where Id=@id", connection); // Sql komutu olarak bu sefer update komutu yazdık
            command.Parameters.AddWithValue("@KategoriAdi", kategori.KategoriAdi);
            command.Parameters.AddWithValue("@Durum", kategori.Durum);
            command.Parameters.AddWithValue("@id", kategori.Id);

            int islemSonucu = command.ExecuteNonQuery(); // ExecuteNonQuery metodu geriye veritabanında etkilenen kayıt sayısını döner
            command.Dispose(); // Sql komut nesnesni kapat 
            connection.Close(); // Veritabanı bağlantısını kapat
            return islemSonucu; // Metodunuz geriye int döndüğü için islemSonucu değişkenini geri döndürüyoruz
        }

        public int Delete(string id)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Delete from Kategoriler where Id=@id", connection);
            command.Parameters.AddWithValue("@id", id);
            int islemSonucu = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return islemSonucu;
        }

    }
}
