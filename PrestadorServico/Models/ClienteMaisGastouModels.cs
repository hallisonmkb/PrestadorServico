using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestadorServico.Models
{
    [NotMapped]
    public class ClienteMaisGastouModels
    {
        [Display(Name = "Mês")]
        public int Mes { get; set; }
        [Display(Name = "Cliente")]
        public string Nome { get; set; }
        [Display(Name = "Valor"), DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public decimal Valor { get; set; }
    }
}