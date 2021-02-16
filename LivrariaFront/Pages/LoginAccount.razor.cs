using LivrariaFront.ViewModels;
using Microsoft.AspNetCore.Components;
using ModelsShared.Helpers;
using ModelsShared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LivrariaFront.Pages
{
    public class LoginAccountBase : ComponentBase
    {
        protected LoginViewModel userTemp = new LoginViewModel();
        protected User userCripted = new User();

        [Inject] protected HttpClient http { get; set; }

        protected async Task SubmitForm()
        {
            userCripted.Name = HashTranslate.sha256(userTemp.NameUser);
            userCripted.Password = HashTranslate.sha256(userTemp.Password);

            //Resposta do servidor
            var response = await http.PostAsJsonAsync<User>(http.BaseAddress.AbsoluteUri + "Account/Login", userCripted);

            var resultModel = await response.Content.ReadFromJsonAsync<ResultModel<User>>(); 


        }
    }
}
