using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Web.Pages.Oduncler
{
    public class CreateModel : PageModel
    {
        private readonly IOduncService _oduncService;
        private readonly IUyeService _uyeService;
        private readonly IKitapService _kitapService;

        public CreateModel(IOduncService oduncService, IUyeService uyeService, IKitapService kitapService)
        {
            _oduncService = oduncService;
            _uyeService = uyeService;
            _kitapService = kitapService;
        }

        [BindProperty]
        public Odunc Odunc { get; set; } = new Odunc();

        public List<SelectListItem> UyeListesi { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> KitapListesi { get; set; } = new List<SelectListItem>();

        public async Task OnGetAsync()
        {
            await LoadDropdownDataAsync();

            // Varsay�lan de�erler
            Odunc.OduncTarihi = System.DateTime.Today;
            Odunc.Aktif = true;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Navigation property'leri ModelState'den kald�r
            ModelState.Remove("Odunc.Kitap");
            ModelState.Remove("Odunc.Uye");

            // Manuel validation
            if (Odunc.UyeId <= 0)
            {
                ModelState.AddModelError("Odunc.UyeId", "L�tfen bir �ye se�iniz.");
            }

            if (Odunc.KitapId <= 0)
            {
                ModelState.AddModelError("Odunc.KitapId", "L�tfen bir kitap se�iniz.");
            }

            if (Odunc.OduncTarihi == default(System.DateTime))
            {
                ModelState.AddModelError("Odunc.OduncTarihi", "L�tfen �d�n� tarihini giriniz.");
            }

            // Model validation kontrol�
            if (!ModelState.IsValid)
            {
                await LoadDropdownDataAsync();
                return Page();
            }

            try
            {
                await _oduncService.EkleAsync(Odunc);
                return RedirectToPage("Index");
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("", $"�d�n� i�lemi kaydedilirken bir hata olu�tu: {ex.Message}");
                await LoadDropdownDataAsync();
                return Page();
            }
        }

        private async Task LoadDropdownDataAsync()
        {
            try
            {
                // �yeler listesi
                var uyeler = await _uyeService.TumUyeleriGetirAsync();
                UyeListesi = uyeler?.ConvertAll(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.AdSoyad
                }) ?? new List<SelectListItem>();

                // Kitaplar listesi
                var kitaplar = await _kitapService.TumKitaplariGetirAsync();
                KitapListesi = kitaplar?.ConvertAll(k => new SelectListItem
                {
                    Value = k.Id.ToString(),
                    Text = k.Ad
                }) ?? new List<SelectListItem>();
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("", $"Dropdown verileri y�klenirken hata olu�tu: {ex.Message}");
                UyeListesi = new List<SelectListItem>();
                KitapListesi = new List<SelectListItem>();
            }
        }
    }
}