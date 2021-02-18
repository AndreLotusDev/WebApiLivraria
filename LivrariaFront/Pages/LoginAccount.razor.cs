using LivrariaFront.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ModelsShared.Helpers;
using ModelsShared.Models;
using Radzen;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LivrariaFront.Pages
{
    public class LoginAccountBase : ComponentBase
    {
        [Inject] protected HttpClient http { get; set; }
        [Inject] NotificationService NotificationService { get; set; }

        [Inject] IJSRuntime js { get; set; }

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

                //Implementa o token guardado nos cookies 
            }

            //Implementar o redirect, token e expiracao dele
            await js.InvokeVoidAsync("window.CreateCookie", "tokenIdentity_Lib", resultModel.Model.Token, 1);
            await js.InvokeVoidAsync("window.CreateCookie", "userName_Lib", resultModel.Model.User.Name, 1);

            var cookieTokenIdentity = await js.InvokeAsync<string>("window.ReadCookie", "tokenIdentity_Lib");

            ShowNotification(notificationMessage);

            //Teste de cabecalho
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44363/Book");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", cookieTokenIdentity );
            var responseToken = await http.SendAsync(request);

            var responseFinally = await responseToken.Content.ReadFromJsonAsync<ResultModelList<Book>>();

            Console.WriteLine("Finally");

        }
    }
}
