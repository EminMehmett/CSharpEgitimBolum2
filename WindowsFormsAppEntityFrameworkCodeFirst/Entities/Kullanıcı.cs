using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppEntityFrameworkCodeFirst.Entities
{
    [Table("Kullanıcılar")]
    public class Kullanıcı
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
    }
}
