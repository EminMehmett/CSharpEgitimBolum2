using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsAppEntityFrameworkCodeFirst.Entities
{
    [Table("Markalar")] // veritabanındaki isim markas yerine markalar olsun dedik 
    public class Marka // Projemizdeki entities klasörüne sağ tıklayıp add class ile bu  sınıfı ekledikten sonra property lerini tanımladık
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Alan { get; set; }
        // Property lerimizi tanımladıktan sonra bu sınıfın veritabanı işlemlerini yapabilmek için Databasecontext classına marka classını dbset olarak eklememiz gerekir
    }
}
