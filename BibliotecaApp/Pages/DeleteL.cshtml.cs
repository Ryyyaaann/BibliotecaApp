using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BibliotecaApp.Models;
using System.Threading.Tasks;

namespace BibliotecaApp.Pages
{
    public class DeleteLModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteLModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Livro Livro { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Livro = await _context.Livros.FindAsync(id);

            if (Livro == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Livro = await _context.Livros.FindAsync(id);

            if (Livro != null)
            {
                _context.Livros.Remove(Livro);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ListaLivro");
        }
    }
}
