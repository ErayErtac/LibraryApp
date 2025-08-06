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
        Task<List<Uye>> GetAllAsync();

        Task<Uye?> GetByIdAsync(int id);

        Task AddAsync(Uye uye);

        Task UpdateAsync(Uye uye);

        Task DeleteAsync(int id);
    }
}
