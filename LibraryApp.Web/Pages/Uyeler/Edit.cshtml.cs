using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;
using System.Threading.Tasks;

namespace LibraryApp.Web.Pages.Uyeler
{
    public class EditModel : PageModel
    {
        private readonly IUyeService _uyeService;

        public EditModel(IUyeService uyeService)
        {
            _uyeService = uyeService;
        }

        [BindProperty]
        public Uye Uye { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Uye = await _uyeService.IdIleGetirAsync(id);

            if (Uye == null)
                return RedirectToPage("Index");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _uyeService.GuncelleAsync(Uye);
            return RedirectToPage("Index");
        }
    }
}
