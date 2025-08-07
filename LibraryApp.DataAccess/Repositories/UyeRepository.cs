using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryApp.DataAccess.Context;
using LibraryApp.Entity.Entities;

namespace LibraryApp.DataAccess.Repositories
{
    public class UyeRepository : GenericRepository<Uye>, IUyeRepository
    {
        public UyeRepository(KutuphaneDbContext context) : base(context)
        {
        }
    }
}

