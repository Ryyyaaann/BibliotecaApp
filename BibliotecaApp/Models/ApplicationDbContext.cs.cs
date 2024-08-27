using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;

namespace BibliotecaApp.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		// Mapear a tabela Livros
		public DbSet<Livro> Livros { get; set; }

		// Mapear a tabela Clientes
		public DbSet<Cliente> Clientes { get; set; }
	}
}
