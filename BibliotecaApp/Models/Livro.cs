using System.ComponentModel.DataAnnotations;

namespace BibliotecaApp.Models
{
	public class Livro
	{
        [Key]
        public int id { get; set; }
		public string nomeLivro { get; set; }
		public string autor { get; set; }
		public int ano { get; set; }
		public string sinopse { get; set; }
	}
}
