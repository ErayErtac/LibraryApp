using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Entity.Entities
{
    public class Kitap
    {

        public int Id { get; set; }

        public string Ad { get; set; } = null!;

        public string Yazar { get; set; } = null!;

        public int YayimYili { get; set; }

        [Required(ErrorMessage = "Kategori zorunludur.")]
        public string Kategori { get; set; } = null!;

        public int StokAdedi { get; set; }

        public ICollection<Odunc>? Oduncler { get; set; }
    }
}
