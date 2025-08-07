using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;


namespace LibraryApp.Services.Services
{
    public class OduncService : IOduncService
    {
        public Task<List<Odunc>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Odunc?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Odunc odunc)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Odunc odunc)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
