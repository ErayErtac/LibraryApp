using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Web.Pages.Oduncler
{
    public class IndexModel : PageModel
    {
        private readonly IOduncService _oduncService;

        public IndexModel(IOduncService oduncService)
        {
            _oduncService = oduncService;
        }

        public List<Odunc> Oduncler { get; set; } = new List<Odunc>();
        public string CurrentFilter { get; set; } = "all";
        public string Message { get; set; } = string.Empty;
        public string MessageType { get; set; } = string.Empty;

        public async Task OnGetAsync(string filter = "all")
        {
            CurrentFilter = filter;

            try
            {
                var oduncler = filter switch
                {
                    "aktif" => await _oduncService.AktifOduncleriGetirAsync(),
                    "teslim" => await _oduncService.TeslimEdilmisOduncleriGetirAsync(),
                    _ => await _oduncService.TumOduncleriGetirAsync()
                };

                Oduncler = oduncler ?? new List<Odunc>();
            }
            catch (System.Exception ex)
            {
                // Hata durumunda bo� liste g�ster
                Oduncler = new List<Odunc>();
                Message = "�d�n� listesi y�klenirken hata olu�tu.";
                MessageType = "danger";
                System.Diagnostics.Debug.WriteLine($"�d�n� listesi y�klenirken hata: {ex.Message}");
            }
        }

        public async Task<IActionResult> OnPostIadeEtAsync(int id)
        {
            try
            {
                await _oduncService.KitapIadeEtAsync(id);
                TempData["Message"] = "Kitap ba�ar�yla iade edildi.";
                TempData["MessageType"] = "success";
            }
            catch (System.Exception ex)
            {
                TempData["Message"] = $"�ade i�lemi s�ras�nda hata olu�tu: {ex.Message}";
                TempData["MessageType"] = "danger";
            }

            return RedirectToPage();
        }
    }
}