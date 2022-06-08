using System.ComponentModel.DataAnnotations;
namespace SiginUser.Models
{
    public class Agenda
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(10, ErrorMessage = "Campo limitado a 10 caracteres no máximo.")]
        public string TipoPerfil { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(11, ErrorMessage = "Campo limitado a 11 caracteres no máximo.")]
        public string CpfProfissional { get; set; }

        public DateTime DataAgenda { get; set; }

        [MaxLength(5, ErrorMessage = "Campo limitado a 5 caracteres no máximo.")] 
        public string HoraAgenda { get; set; }

        public DateTime DataAgendaDetran { get; set; }

        [MaxLength(5, ErrorMessage = "Campo limitado a 5 caracteres no máximo.")]
        public string HoraAgendaDetran { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(11, ErrorMessage = "Campo limitado a 11 caracteres no máximo.")]
        public string CpfCandidato { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "Campo limitado a 50 caracteres no máximo.")]
        public string NomeCandidato { get; set; }

        [MaxLength(30, ErrorMessage = "Campo limitado a 30 caracteres no máximo.")]
        public string Telefone { get; set; }

        [MaxLength(50, ErrorMessage = "Campo limitado a 50 caracteres no máximo.")]
        public string EmailCandidato { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(10, ErrorMessage = "Campo limitado a 10 caracteres no máximo.")]
        public string TipoProcesso { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(10, ErrorMessage = "Campo limitado a 10 caracteres no máximo.")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(10, ErrorMessage = "Campo limitado a 10 caracteres no máximo.")]
        public string StatusExMedico { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(10, ErrorMessage = "Campo limitado a 10 caracteres no máximo.")]
        public string StatusExPsico { get; set; }
    }
}