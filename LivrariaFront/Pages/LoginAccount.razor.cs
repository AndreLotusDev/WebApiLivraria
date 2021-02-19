using LivrariaFront.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ModelsShared.Helpers;
using ModelsShared.Models;
using Radzen;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LivrariaFront.Pages
{
    public class LoginAccountBase : ComponentBase
    {
        [Inject] protected HttpClient http { get; set; }
        [Inject] NotificationService NotificationService { get; set; }
        [Inject] IJSRuntime js { get; set; }
        [Inject] NavigationManager NavManager { get; set; }

        protected LoginViewModel userTemp = new LoginViewModel();
        protected User userCripted = new User();

        protected void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
        }

        protected async Task SubmitForm()
        {
            userCripted.Name = HashTranslate.sha256(userTemp.NameUser);
            userCripted.Password = HashTranslate.sha256(userTemp.Password);

            //Resposta do servidor
            var response = await http.PostAsJsonAsync<User>(http.BaseAddress.AbsoluteUri + "Account/Login", userCripted);

            var resultModel = await response.Content.ReadFromJsonAsync<ResultModel<TokenInfo>>();

            NotificationMessage notificationMessage = new NotificationMessage();

            if (!string.IsNullOrEmpty(resultModel.ErrorMessage))
            {
                notificationMessage.Detail = resultModel.ErrorMessage;
                notificationMessage.Severity = NotificationSeverity.Error;
            }
            else
            {
                notificationMessage.Detail = resultModel.SuccessMessage;
                notificationMessage.Severity = NotificationSeverity.Success;

                //Fazer as 3 tentativa e bloq
                await js.InvokeVoidAsync("window.CreateCookie", "tokenIdentity_Lib", resultModel.Model.Token, 1);
                await js.InvokeVoidAsync("window.CreateCookie", "userName_Lib", resultModel.Model.User.Name, 1);

                //Redireciona caso ele acerte o login
                NavManager.NavigateTo("/");
            }

            ShowNotification(notificationMessage);

        }
    }
}
