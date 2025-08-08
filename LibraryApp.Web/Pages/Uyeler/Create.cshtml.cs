using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;
using System.Threading.Tasks;

namespace LibraryApp.Web.Pages.Uyeler
{
    public class CreateModel : PageModel
    {
        private readonly IUyeService _uyeService;

        public CreateModel(IUyeService uyeService)
        {
            _uyeService = uyeService;
        }

        [BindProperty]
        public Uye Uye { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _uyeService.EkleAsync(Uye);
            return RedirectToPage("Index");
        }
    }
}
