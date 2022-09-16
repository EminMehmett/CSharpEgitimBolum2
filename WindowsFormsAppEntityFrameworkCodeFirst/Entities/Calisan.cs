using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppEntityFrameworkCodeFirst.Entities
{
    [Table("Çalışanlar")]
    public class Calisan
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Bolum { get; set; }
        public string Durum { get; set; }
        public string Maas { get; set; }
        public string İletisim { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
    }
}
