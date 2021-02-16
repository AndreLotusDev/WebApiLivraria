using LivrariaFront.ViewModels;
using Microsoft.AspNetCore.Components;
using ModelsShared.Helpers;
using ModelsShared.Models;
using Radzen;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LivrariaFront.Pages
{
    public class CreateAccountBase : ComponentBase
    {
        [Inject] HttpClient http { get; set; }
        [Inject] NotificationService NotificationService { get; set; }

        protected UserViewModel userTemp = new UserViewModel();
        protected User userCripted = new User();

        protected ResultModel<User> resultModel = new ResultModel<User>();

        protected void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
        }

        protected async Task SubmitForm()
        {
            userTemp.Role = "User";
            //Hashing process
            userCripted.Name = HashTranslate.sha256(userTemp.Name);
            userCripted.Email = HashTranslate.sha256(userTemp.Email);
            userCripted.NumberPhone = HashTranslate.sha256(userTemp.NumberPhone);
            userCripted.Password = HashTranslate.sha256(userTemp.Password);
            userCripted.Role = HashTranslate.sha256(userTemp.Role);

            //Resposta do servidor
            var response = await http.PostAsJsonAsync<User>(http.BaseAddress.AbsoluteUri + "Account/Create", userCripted);

            var resultModel = await response.Content.ReadFromJsonAsync<ResultModel<User>>();

            NotificationMessage message = new NotificationMessage();
            if (!String.IsNullOrEmpty(resultModel.ErrorMessage))
            {
                message.Detail = resultModel.ErrorMessage;
                message.Severity = NotificationSeverity.Error;
            }
            else
            {
                message.Detail = resultModel.SuccessMessage;
                message.Severity = NotificationSeverity.Error;
            }

            ShowNotification(message);
        }
    }
}
