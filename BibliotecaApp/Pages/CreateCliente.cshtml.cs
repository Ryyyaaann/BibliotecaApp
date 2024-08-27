using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using BibliotecaApp.Models;

namespace BibliotecaApp.Pages
{
    public class CreateClienteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateClienteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clientes.Add(Cliente);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
