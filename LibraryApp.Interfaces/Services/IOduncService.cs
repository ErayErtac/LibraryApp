using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Entity.Entities;

namespace LibraryApp.Interfaces.Services
{
    // Interface - Ödünç servisi için sözleşme
    public interface IOduncService
    {
        Task<List<Odunc>> TumOduncleriGetirAsync();
        Task<Odunc?> IdIleGetirAsync(int id);
        Task EkleAsync(Odunc odunc);
        Task GuncelleAsync(Odunc odunc);
        Task SilAsync(int id);
    }
}
