using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace SiginUser.Models
{
    public class Usuario
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(40,MinimumLength=5,ErrorMessage ="O Nome deve ter entre 5 e 40 caracteres.")]
        public string? UserName { get; set; }
        
        [Required(ErrorMessage ="Preenchimento obrigatório.")]
        [EmailAddress(ErrorMessage ="Formato inválido.")]
        public string UserEmail { get; set; }
        
        public bool IsEmailConfirmed { get; set; } = false;
        
        [Required(ErrorMessage ="Preenchimento obrigatório.")]
        [StringLength(20,MinimumLength=4,ErrorMessage ="A Senha deve ter entre 4 e 20 caracteres.")]
        public string Password { get; set; }

        //[RegularExpression(@"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage ="Número inválido.")]
        [RegularExpression("^([14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])([2-8]|9[1-9])[0-9]{3}[0-9]{4}$", ErrorMessage = "Número inválido.")]
        public string? PhoneNumber { get; set; }
        public bool IsPhoneConfirmed { get; set; } = false;
        public DateTime? BlockedDate { get; set; }
        public bool IsBlocked { get; set; } = false;
        public String? UserPhoto { get; set; }
    }
}
