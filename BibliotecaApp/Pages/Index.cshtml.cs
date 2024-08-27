using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BibliotecaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cliente> Clientes { get; set; }

        public async Task OnGetAsync()
        {
            Clientes = await _context.Clientes.ToListAsync();
        }
    }
}
