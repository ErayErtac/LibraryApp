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
        Task<List<Kitap>> GetAllAsync();

        Task<Kitap?> GetByIdAsync(int id);

        Task AddAsync(Kitap kitap);

        Task UpdateAsync(Kitap kitap);

        Task DeleteAsync(int id);
    }
}