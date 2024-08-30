using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BibliotecaApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApp.Pages
{
    public class EditarLModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditarLModel(ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Livro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(Livro.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ListaLivro");
        }

        private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.id == id);
        }
    }
}
