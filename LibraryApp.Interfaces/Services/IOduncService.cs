using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryApp.Entity.Entities;

namespace LibraryApp.Interfaces.Services
{
    public interface IOduncService
    {
        Task<List<Odunc>> TumOduncleriGetirAsync();
        Task<Odunc?> IdIleGetirAsync(int id);
        Task EkleAsync(Odunc odunc);
        Task GuncelleAsync(Odunc odunc);
        Task SilAsync(int id);
        Task<List<Odunc>> AktifOduncleriGetirAsync();
        Task<List<Odunc>> TeslimEdilmisOduncleriGetirAsync();
        Task KitapIadeEtAsync(int oduncId);
    }
}