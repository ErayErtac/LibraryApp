using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using LibraryApp.Entity.Entities;
using LibraryApp.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Web.Pages.Kitaplar
{
    public class IndexModel : PageModel
    {
        private readonly IKitapService _kitapService;

        public IndexModel(IKitapService kitapService)
        {
            _kitapService = kitapService;
        }

        public List<Kitap> Kitaplar { get; set; }

        public async Task OnGetAsync()
        {
            Kitaplar = await _kitapService.TumKitaplariGetirAsync();
        }
    }
}

