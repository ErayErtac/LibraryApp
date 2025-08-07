using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entity.Entities
{
    public class Uye
    {
        public int Id { get; set; }

        public string AdSoyad { get; set; } = string.Empty;

        public string Eposta { get; set; } = string.Empty;

        public string Telefon { get; set; } = string.Empty;

        public DateTime KayitTarihi { get; set; }

        public ICollection<Odunc>? Oduncler { get; set; }
    }
}

