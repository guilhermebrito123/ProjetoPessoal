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

        [Required(ErrorMessage = "O campo Ano de fabricacao é obrigatório!")]
        [Display(Name = "Ano de fabricação")]
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "O campo Ano do modelo é obrigatório!")]
        [Display(Name = "Ano do modelo")]
        public int AnoModelo { get; set; }
    }
}
