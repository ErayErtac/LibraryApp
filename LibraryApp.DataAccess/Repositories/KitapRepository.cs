using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryApp.DataAccess.Context;
using LibraryApp.Entity.Entities;

namespace LibraryApp.DataAccess.Repositories
{
    public class KitapRepository : GenericRepository<Kitap>, IKitapRepository
    {
        public KitapRepository(KutuphaneDbContext context) : base(context)
        {
        }

        // İleri düzey sorgular buraya eklenebilir
    }
}

