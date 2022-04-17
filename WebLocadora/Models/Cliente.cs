using System.ComponentModel.DataAnnotations;

namespace WebLocadora.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
