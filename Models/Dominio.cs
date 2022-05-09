using System.ComponentModel.DataAnnotations;
namespace SiginUser.Models
{
    public class Dominio
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        [MaxLength(30,ErrorMessage="Campo limitado a 30 caracteres no máximo.")]
        public string Campo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(10,ErrorMessage= "Campo limitado a 10 caracteres no máximo.")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(30, ErrorMessage = "Campo limitado a 50 caracteres no máximo.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage="Campo Obrigatório")]
        public int Sequencia { get; set; }
    }
}
