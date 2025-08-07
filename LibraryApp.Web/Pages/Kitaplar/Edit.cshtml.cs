using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;
using System.Threading.Tasks;

namespace LibraryApp.Web.Pages.Kitaplar
{
    public class EditModel : PageModel
    {
        private readonly IKitapService _kitapService;

        public EditModel(IKitapService kitapService)
        {
            _kitapService = kitapService;
        }

        [BindProperty]
        public Kitap Kitap { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Kitap = await _kitapService.IdIleGetirAsync(id);

            if (Kitap == null)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _kitapService.GuncelleAsync(Kitap);

            return RedirectToPage("Index");
        }
    }
}
