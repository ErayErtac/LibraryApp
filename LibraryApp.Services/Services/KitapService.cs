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
    public class KitapService : IKitapService
    {
        private readonly IKitapRepository _kitapRepository;

        public KitapService(IKitapRepository kitapRepository)
        {
            _kitapRepository = kitapRepository;
        }

        public async Task<List<Kitap>> TumKitaplariGetirAsync()
        {
            return await _kitapRepository.GetAllAsync();
        }

        public async Task<Kitap?> IdIleGetirAsync(int id)
        {
            return await _kitapRepository.GetByIdAsync(id);
        }

        public async Task EkleAsync(Kitap kitap)
        {
            await _kitapRepository.AddAsync(kitap);
        }

        public async Task GuncelleAsync(Kitap kitap)
        {
            await _kitapRepository.UpdateAsync(kitap);
        }

        public async Task SilAsync(int id)
        {
            await _kitapRepository.DeleteAsync(id);
        }
    }
}
