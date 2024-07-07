using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPessoal.Models
{
    [Table("Consumos")]
    public class Consumo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a descrição!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data!")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o valor!")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a quilometragem!")]
        public int Km { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o tipo!")]
        [Display(Name = "Tipo de combustível")]
        public TipoCombustível Tipo { get; set; }

        //Cada consumo está relacionado a um veículo específico cadastrado (CRIANDO A RELAÇÃO VIRTUAL):
        [Required(ErrorMessage = "Obrigatório informar o veículo!")]
        [Display(Name = "Veículo")]
        public int VeiculoId { get; set; }
        [ForeignKey("VeiculoId")]
        public Veiculo Veiculo { get; set; }
       
    }

    //Criando tipos de gasolina:
    public enum TipoCombustível
    {
        Gasolina,
        Etanol          
    }
}
