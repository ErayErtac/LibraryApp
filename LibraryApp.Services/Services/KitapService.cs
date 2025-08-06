using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;

namespace LibraryApp.Services.Services
{
    public class KitapService : IKitapService
    {
        public Task<List<Kitap>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Kitap?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Kitap kitap)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Kitap kitap)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
