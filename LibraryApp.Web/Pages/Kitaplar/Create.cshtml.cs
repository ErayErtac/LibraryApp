using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;
using System.Threading.Tasks;

namespace LibraryApp.Web.Pages.Kitaplar
{
    public class CreateModel : PageModel
    {
        private readonly IKitapService _kitapService;

        public CreateModel(IKitapService kitapService)
        {
            _kitapService = kitapService;
        }

        [BindProperty]
        public Kitap Kitap { get; set; }

        public void OnGet()
        {
            // Sayfa ilk a��ld���nda �al���r, burada genelde bo� b�rak�l�r
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _kitapService.EkleAsync(Kitap);

            return RedirectToPage("Index");
        }
    }
}
