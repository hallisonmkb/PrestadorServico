using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestadorServico.Models
{
    [Table("Servico")]
    public class ServicoModels
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServicoId { get; set; }

        [ForeignKey("Fornecedor"), Required]
        public int FornecedorId { get; set; }
        public FornecedorModels Fornecedor { get; set; }

        [ForeignKey("Cliente"), Required]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public ClienteModels Cliente { get; set; }

        [MaxLength(300), MinLength(5, ErrorMessage = "A descrição deve possuir 5 ou mais caracteres"), Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column(TypeName="money")]
        [Display(Name = "Valor"), DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public decimal Valor { get; set; }
 
        [Required]
        [Display(Name = "Tipo de serviço")]
        public enumServico Tipo { get; set; }

        [Required]
        [Display(Name = "Data atendimento"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Atendimento { get; set; }
    }

    public enum enumServico
    {
        [Display(Name = "Conserto Eletrônico")]
        ConsertoEletronico = 0,
        [Display(Name = "Serviços Gerais")]
        ServicosGerais = 1,
        [Display(Name = "Manutenção Hidráulica")]
        ManutencaoHidraulica = 2,
        [Display(Name = "Instalação Elétrica")]
        InstalacaoEletrica = 3,
        [Display(Name = "Jardinagem")]
        Jardinagem = 4
    }
}