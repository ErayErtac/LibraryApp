using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Entity.Entities;

namespace LibraryApp.Interfaces.Services
{
    // Interface - Kitap servisi için sözleşme
    public interface IKitapService
    {
        Task<List<Kitap>> TumKitaplariGetirAsync();
        Task<Kitap?> IdIleGetirAsync(int id);
        Task EkleAsync(Kitap kitap);
        Task GuncelleAsync(Kitap kitap);
        Task SilAsync(int id);
    }

}