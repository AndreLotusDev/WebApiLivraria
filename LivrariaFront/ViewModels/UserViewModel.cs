using System.ComponentModel.DataAnnotations;

namespace LivrariaFront.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(8, ErrorMessage = "O nome tem que ter pelo menos 8 caracterrs")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        //--------------------------------------------------------------------------
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [Required(ErrorMessage = "O email é obrigatório")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        //--------------------------------------------------------------------------
        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Display(Name = "Telefone -")]
        public string NumberPhone { get; set; }
        //--------------------------------------------------------------------------

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        //--------------------------------------------------------------------------

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As duas senhas não estão iguais.")]
        public string ConfirmPassword { get; set; }
        //--------------------------------------------------------------------------

        public string Role { get; set; }
    }
}
