using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestadorServico.Models
{
    [Table("Usuario")]
    public class UsuarioModels
    {
        [Key, ForeignKey("Fornecedor"), Required]
        public int FornecedorId { get; set; }
        public FornecedorModels Fornecedor { get; set; }

        [MaxLength(50), MinLength(5, ErrorMessage = "O email deve possuir 5 ou mais caracteres"), Required]
        public string Email { get; set; }
        [MaxLength(50), MinLength(5, ErrorMessage = "A senha deve possuir 5 ou mais caracteres"), Required]
        public string Senha { get; set; }
    }
}