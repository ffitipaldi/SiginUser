using System.ComponentModel.DataAnnotations;

namespace SiginUser.Models
{
    public class ImportAgendaTxt
    {
        [Required(ErrorMessage = "Cole neste campo as linhas das agendas copiadas do site do DETRAN")]
        public string? CampoAgendaTxt { get; set; }
    }
}
