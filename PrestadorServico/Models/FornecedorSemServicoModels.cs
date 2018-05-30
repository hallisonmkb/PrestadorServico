using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestadorServico.Models
{
    [NotMapped]
    public class FornecedorSemServicoModels
    {
        [Display(Name = "Mês")]
        public int Mes { get; set; }
        [Display(Name = "Código")]
        public int FornecedorId { get; set; }
        [Display(Name = "Fornecedor")]
        public string Nome { get; set; }
    }
}