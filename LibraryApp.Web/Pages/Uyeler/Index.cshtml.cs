using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Web.Pages.Uyeler
{
    public class IndexModel : PageModel
    {
        private readonly IUyeService _uyeService;

        public IndexModel(IUyeService uyeService)
        {
            _uyeService = uyeService;
        }

        public List<Uye> Uyeler { get; set; } = new();

        public async Task OnGetAsync()
        {
            Uyeler = await _uyeService.TumUyeleriGetirAsync();
        }
    }
}
