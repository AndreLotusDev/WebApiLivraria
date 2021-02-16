using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
