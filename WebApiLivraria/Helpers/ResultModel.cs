using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLivraria.Helpers
{
    public class ResultModel<T> 
    {
        public T Model { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ResultModel
    {
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}
