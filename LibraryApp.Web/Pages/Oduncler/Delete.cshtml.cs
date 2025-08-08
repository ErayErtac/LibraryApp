using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;
using System.Threading.Tasks;

namespace LibraryApp.Web.Pages.Oduncler
{
    public class DeleteModel : PageModel
    {
        private readonly IOduncService _oduncService;

        public DeleteModel(IOduncService oduncService)
        {
            _oduncService = oduncService;
        }

        [BindProperty]
        public Odunc Odunc { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                // Navigation property'ler ile birlikte getir (IdIleGetirAsync Include yapýyor)
                Odunc = await _oduncService.IdIleGetirAsync(id);

                if (Odunc == null)
                {
                    TempData["Message"] = "Ödünç iþlemi bulunamadý.";
                    TempData["MessageType"] = "warning";
                    return RedirectToPage("Index");
                }

                return Page();
            }
            catch (System.Exception ex)
            {
                TempData["Message"] = $"Ödünç iþlemi yüklenirken hata oluþtu: {ex.Message}";
                TempData["MessageType"] = "danger";
                return RedirectToPage("Index");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _oduncService.SilAsync(Odunc.Id);

                TempData["Message"] = "Ödünç iþlemi baþarýyla silindi.";
                TempData["MessageType"] = "success";
            }
            catch (System.Exception ex)
            {
                TempData["Message"] = $"Silme iþlemi sýrasýnda hata oluþtu: {ex.Message}";
                TempData["MessageType"] = "danger";
            }

            return RedirectToPage("Index");
        }
    }
}