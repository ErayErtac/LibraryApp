using System;
using System.Collections.Generic;
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
            return await _oduncRepository.GetAllWithDetailsAsync();
        }

        public async Task<Odunc?> IdIleGetirAsync(int id)
        {
            return await _oduncRepository.GetByIdWithDetailsAsync(id);
        }

        public async Task EkleAsync(Odunc odunc)
        {
            // Yeni ödünç kaydı oluştururken varsayılan değerler
            odunc.Aktif = true;
            if (odunc.OduncTarihi == default(DateTime))
            {
                odunc.OduncTarihi = DateTime.Today;
            }

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

        public async Task<List<Odunc>> AktifOduncleriGetirAsync()
        {
            return await _oduncRepository.GetAktifOdunclerAsync();
        }

        public async Task<List<Odunc>> TeslimEdilmisOduncleriGetirAsync()
        {
            return await _oduncRepository.GetTeslimEdilmisOdunclerAsync();
        }

        public async Task KitapIadeEtAsync(int oduncId)
        {
            var odunc = await _oduncRepository.GetByIdAsync(oduncId);
            if (odunc != null && odunc.Aktif)
            {
                odunc.IadeTarihi = DateTime.Today;
                odunc.Aktif = false;
                await _oduncRepository.UpdateAsync(odunc);
            }
        }
    }
}