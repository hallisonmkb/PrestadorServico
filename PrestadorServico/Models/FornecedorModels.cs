using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestadorServico.Models
{
    [Table("Fornecedor")]
    public class FornecedorModels
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FornecedorId { get; set; }
        [MaxLength(100), MinLength(5, ErrorMessage = "O nome deve possuir 5 ou mais caracteres"), Required]
        public string Nome { get; set; }

        public virtual ICollection<ServicoModels> Servicos { get; set; }
    }
}