
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsAppEntityFrameworkCodeFirst.Entities
{
    [Table("Urunler")] // Veritabanındaki tablonun ismi Urunler olsun Uruns olmasın 
    public class Urun
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public decimal Fiyati { get; set; }
        public int Stok { get; set; }
    }
}
