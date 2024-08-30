using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using BibliotecaApp.Models;

namespace BibliotecaApp.Pages
{
    public class CreateLivroModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateLivroModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Livro Livro { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Livros.Add(Livro);
            _context.SaveChanges();
            return RedirectToPage("./ListaLivro");
        }
    }
}
