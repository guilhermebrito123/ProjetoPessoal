using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPessoal.Models
{
    [Table("Usuários")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha!")]
        [DataType(DataType.Password)]//--------->>>No front end o campo virá mascarado
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o tipo de perfil")]
        public Perfil Perfil { get; set; }

    }
    public enum Perfil
    {
        Admin,
        User
    }
}
