using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestadorServico.Models
{
    [Table("Cliente")]
    public class ClienteModels
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int ClienteId { get; set; }

        [ConcurrencyCheck, MaxLength(100), MinLength(5, ErrorMessage = "O nome deve possuir 5 ou mais caracteres"), Required]
        [Display(Name = "Cliente")]
        public string Nome { get; set; }

        [MaxLength(50)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [MaxLength(50)]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [MaxLength(2), MinLength(2)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}