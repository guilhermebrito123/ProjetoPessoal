using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPessoal.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo Nome é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Placa é obrigatório!")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O campo AnoFabricacao é obrigatório!")]
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "O campo AnoModelo é obrigatório!")]
        public int AnoModelo { get; set; }
    }
}
