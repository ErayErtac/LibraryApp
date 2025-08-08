using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;
using System.Threading.Tasks;

namespace LibraryApp.Web.Pages.Uyeler
{
    public class DeleteModel : PageModel
    {
        private readonly IUyeService _uyeService;

        public DeleteModel(IUyeService uyeService)
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
            await _uyeService.SilAsync(Uye.Id);
            return RedirectToPage("Index");
        }
    }
}
