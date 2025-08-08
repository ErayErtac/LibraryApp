using LibraryApp.DataAccess.Context;
using LibraryApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.DataAccess.Repositories
{
    public class OduncRepository : GenericRepository<Odunc>, IOduncRepository
    {
        public OduncRepository(KutuphaneDbContext context) : base(context)
        {
        }

        public async Task<List<Odunc>> GetAllWithDetailsAsync()
        {
            return await _context.Oduncler
                .Include(o => o.Uye)
                .Include(o => o.Kitap)
                .OrderByDescending(o => o.OduncTarihi)
                .ToListAsync();
        }

        public async Task<Odunc?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Oduncler
                .Include(o => o.Uye)
                .Include(o => o.Kitap)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Odunc>> GetAktifOdunclerAsync()
        {
            return await _context.Oduncler
                .Include(o => o.Uye)
                .Include(o => o.Kitap)
                .Where(o => o.Aktif == true)
                .OrderByDescending(o => o.OduncTarihi)
                .ToListAsync();
        }

        public async Task<List<Odunc>> GetTeslimEdilmisOdunclerAsync()
        {
            return await _context.Oduncler
                .Include(o => o.Uye)
                .Include(o => o.Kitap)
                .Where(o => o.Aktif == false && o.IadeTarihi != null)
                .OrderByDescending(o => o.IadeTarihi)
                .ToListAsync();
        }
    }
}