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
    public class UyeService : IUyeService
    {
        private readonly IUyeRepository _uyeRepository;

        public UyeService(IUyeRepository uyeRepository)
        {
            _uyeRepository = uyeRepository;
        }

        public async Task<List<Uye>> TumUyeleriGetirAsync()
        {
            return await _uyeRepository.GetAllAsync();
        }

        public async Task<Uye?> IdIleGetirAsync(int id)
        {
            return await _uyeRepository.GetByIdAsync(id);
        }

        public async Task EkleAsync(Uye uye)
        {
            await _uyeRepository.AddAsync(uye);
        }

        public async Task GuncelleAsync(Uye uye)
        {
            await _uyeRepository.UpdateAsync(uye);
        }

        public async Task SilAsync(int id)
        {
            await _uyeRepository.DeleteAsync(id);
        }
    }
}
