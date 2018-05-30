using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestadorServico.Models
{
    [NotMapped]
    public class EstadoModels
    {
        [Key, Required]
        public string Sigla { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}