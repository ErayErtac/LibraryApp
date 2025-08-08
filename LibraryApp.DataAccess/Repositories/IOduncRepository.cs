using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApp.Entity.Entities;

namespace LibraryApp.DataAccess.Repositories
{
    public interface IOduncRepository : IGenericRepository<Odunc>
    {
        Task<List<Odunc>> GetAllWithDetailsAsync();
        Task<Odunc?> GetByIdWithDetailsAsync(int id);
        Task<List<Odunc>> GetAktifOdunclerAsync();
        Task<List<Odunc>> GetTeslimEdilmisOdunclerAsync();
    }
}