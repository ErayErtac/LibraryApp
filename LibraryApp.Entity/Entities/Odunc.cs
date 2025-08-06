using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entity.Entities
{
    public class Odunc
    {
        public int Id { get; set; }

        public int KitapId { get; set; }
        public Kitap Kitap { get; set; } = null!;

        public int UyeId { get; set; }
        public Uye Uye { get; set; } = null!;

        public DateTime OduncTarihi { get; set; }

        public DateTime? IadeTarihi { get; set; }

        public bool Aktif { get; set; }  // Ödünç durumu (aktif/teslim edildi)
    }
}

