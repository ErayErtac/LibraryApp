using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;
using LibraryApp.DataAccess.Repositories;

namespace LibraryApp.Service.Services
{
    public class OduncService : IOduncService
    {
        private readonly IOduncRepository _oduncRepository;

        public OduncService(IOduncRepository oduncRepository)
        {
            _oduncRepository = oduncRepository;
        }

        public async Task<List<Odunc>> TumOduncleriGetirAsync()
        {
            return await _oduncRepository.GetAllAsync();
        }

        public async Task<Odunc?> IdIleGetirAsync(int id)
        {
            return await _oduncRepository.GetByIdAsync(id);
        }

        public async Task EkleAsync(Odunc odunc)
        {
            await _oduncRepository.AddAsync(odunc);
        }

        public async Task GuncelleAsync(Odunc odunc)
        {
            await _oduncRepository.UpdateAsync(odunc);
        }

        public async Task SilAsync(int id)
        {
            await _oduncRepository.DeleteAsync(id);
        }
    }
}
