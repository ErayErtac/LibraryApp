using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LibraryApp.Web.Pages.Oduncler
{
    public class EditModel : PageModel
    {
        private readonly IOduncService _oduncService;
        private readonly IUyeService _uyeService;
        private readonly IKitapService _kitapService;

        public EditModel(IOduncService oduncService, IUyeService uyeService, IKitapService kitapService)
        {
            _oduncService = oduncService;
            _uyeService = uyeService;
            _kitapService = kitapService;
        }

        [BindProperty]
        public Odunc Odunc { get; set; } = new();

        public List<SelectListItem> UyeListesi { get; set; } = new();
        public List<SelectListItem> KitapListesi { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Odunc = await _oduncService.IdIleGetirAsync(id);

            if (Odunc == null)
                return RedirectToPage("Index");

            await YukleListelerAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await YukleListelerAsync();
                return Page();
            }

            await _oduncService.GuncelleAsync(Odunc);
            return RedirectToPage("Index");
        }

        private async Task YukleListelerAsync()
        {
            var uyeler = await _uyeService.TumUyeleriGetirAsync();
            var kitaplar = await _kitapService.TumKitaplariGetirAsync();

            UyeListesi = new List<SelectListItem>();
            KitapListesi = new List<SelectListItem>();

            foreach (var uye in uyeler)
            {
                UyeListesi.Add(new SelectListItem { Value = uye.Id.ToString(), Text = uye.AdSoyad });
            }

            foreach (var kitap in kitaplar)
            {
                KitapListesi.Add(new SelectListItem { Value = kitap.Id.ToString(), Text = kitap.Ad });
            }
        }
    }
}
