using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Context
{
    public class KutuphaneDbContext : DbContext
    {
        public KutuphaneDbContext(DbContextOptions<KutuphaneDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Odunc> Oduncler { get; set; }
    }
}

