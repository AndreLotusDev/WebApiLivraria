using System.ComponentModel.DataAnnotations;

namespace LivrariaFront.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O nome de usuário/email é obrigatório")]
        public string NameUser { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Password { get; set; }
    }
}
