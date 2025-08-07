using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;
using System.Threading.Tasks;

namespace LibraryApp.Web.Pages.Kitaplar
{
    public class DeleteModel : PageModel
    {
        private readonly IKitapService _kitapService;

        public DeleteModel(IKitapService kitapService)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _kitapService.SilAsync(id);

            return RedirectToPage("Index");
        }
    }
}
