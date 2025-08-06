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

        public string AdSoyad { get; set; } = null!;

        public string Eposta { get; set; } = null!;

        public string Telefon { get; set; } = null!;

        public DateTime KayitTarihi { get; set; }

        public ICollection<Odunc>? Oduncler { get; set; }
    }
}

