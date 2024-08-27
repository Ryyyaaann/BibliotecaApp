using System.ComponentModel.DataAnnotations;

namespace BibliotecaApp.Models
{
    public class Cliente
    {
        [Key]
        public int idcliente { get; set; }

        public string nomeCliente { get; set; }

        public int idade { get; set; }

        public string endereco { get; set; }

        public string contato { get; set; }
    }
}
