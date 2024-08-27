using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BibliotecaApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaApp.Pages
{
    public class ListaLivroModels : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ListaLivroModels(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Livro> Livros { get; set; }

        public async Task OnGetAsync()
        {
            Livros = await _context.Livros.ToListAsync();
        }
    }
}
