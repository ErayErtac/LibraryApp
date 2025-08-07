using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;

namespace LibraryApp.Services.Services
{
    public class UyeService : IUyeService
    {
        public Task<List<Uye>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Uye?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Uye uye)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Uye uye)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

