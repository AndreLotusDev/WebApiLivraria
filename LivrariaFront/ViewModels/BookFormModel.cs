using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LivrariaFront.ViewModels
{
    public class BookFormModel
    {
        [Required(ErrorMessage = "O títullo é obrigatório")]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public List<string> Categories { get; set; }
        public int Pages { get; set; }
        public Int16 Year { get; set; }
        [Required(ErrorMessage = "O campo de URL file é obrigatório")]
        public string FileUrl { get; set; }
        [Required(ErrorMessage = "O campo de URL imagem é obrigatório")]
        public string ImageUrl { get; set; }
    }
}
