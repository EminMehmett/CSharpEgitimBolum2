using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace WindowsFormsAppAdoNet
{
    public class ProductDAL2
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; initial catalog=UrunYonetimi2; integrated security=true");

        void ConnectionKontrol()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void Add(Product product)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Insert Into Products2 values (@UrunAdi,@UrunFiyati,@StokMiktari)", connection);
            command.Parameters.AddWithValue("@UrunAdi", product.UrunAdi);
            command.Parameters.AddWithValue("@UrunFiyati", product.UrunFiyati);
            command.Parameters.AddWithValue("@StokMiktari", product.StokMiktari);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Product> GetProducts()
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Select * from Products2", connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Product> Products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UrunAdi = reader["UrunAdi"].ToString(),
                    StokMiktari = Convert.ToInt32(reader["StokMiktari"]),
                    UrunFiyati = Convert.ToDecimal(reader["UrunFiyati"])
                };
                Products.Add(product);
            }
            reader.Close();
            connection.Close();
            return Products;
        }

        public void Update(Product product)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Update Products2 set UrunAdi=@UrunAdi,UrunFiyati=@UrunFiyati,StokMiktari=@StokMiktari where Id=Id", connection);
            command.Parameters.AddWithValue("@Id", product.Id);
            command.Parameters.AddWithValue("@UrunAdi", product.UrunAdi);
            command.Parameters.AddWithValue("@UrunFiyati", product.UrunFiyati);
            command.Parameters.AddWithValue("@StokMiktari", product.StokMiktari);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }

}
