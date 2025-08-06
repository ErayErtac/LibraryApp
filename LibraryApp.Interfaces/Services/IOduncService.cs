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
        Task<List<Odunc>> GetAllAsync();

        Task<Odunc?> GetByIdAsync(int id);

        Task AddAsync(Odunc odunc);

        Task UpdateAsync(Odunc odunc);

        Task DeleteAsync(int id);
    }
}
