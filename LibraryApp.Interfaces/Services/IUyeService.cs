using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Entity.Entities;

namespace LibraryApp.Interfaces.Services
{
    // Interface - Üye servisi için sözleşme
    public interface IUyeService
    {
        Task<List<Uye>> TumUyeleriGetirAsync();
        Task<Uye?> IdIleGetirAsync(int id);
        Task EkleAsync(Uye uye);
        Task GuncelleAsync(Uye uye);
        Task SilAsync(int id);
    }
}
