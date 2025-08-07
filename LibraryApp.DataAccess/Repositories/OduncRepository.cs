using LibraryApp.DataAccess.Context;
using LibraryApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryApp.DataAccess.Context;
using LibraryApp.Entity.Entities;

namespace LibraryApp.DataAccess.Repositories
{
    public class OduncRepository : GenericRepository<Odunc>, IOduncRepository
    {
        public OduncRepository(KutuphaneDbContext context) : base(context)
        {
        }
    }
}


