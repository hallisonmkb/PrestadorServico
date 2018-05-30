using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestadorServico.Models
{
    [NotMapped]
    public class FornecedorMediaValorModels
    {
        [Display(Name = "Tipo")]
        public enumServico Tipo { get; set; }
        [Display(Name = "Fornecedor")]
        public string Nome { get; set; }
        [Display(Name = "Média de valor"), DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public decimal ValorMedia { get; set; }
    }
}