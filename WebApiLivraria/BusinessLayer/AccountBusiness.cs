using ModelsShared.Helpers;
using ModelsShared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiLivraria.Repository;
using WebApiLivraria.Services;

namespace WebApiLivraria.BusinessLayer
{
    public class AccountBusiness : IAccountBusiness
    {
        private readonly IUnityOfWork _uof;

        public AccountBusiness(IUnityOfWork uof)
        {
            _uof = uof;
        }

        public async Task<(int, bool, string)> AllowRegister(User user)
        {
            try
            {
                var listOfUser = _uof.UserRepository.List();

                string returnMessage = "";

                if (listOfUser.Any(w => w.Name == user.Name))
                    returnMessage = "Nome de usuário já cadastrado";
                else if (listOfUser.Any(w => w.Email == user.Email))
                    returnMessage = "Email já cadastrado";
                else if (listOfUser.Any(w => w.NumberPhone == user.NumberPhone))
                    returnMessage = "Numero de telefone já cadastrado";

                if (string.IsNullOrEmpty(returnMessage))
                {
                    _uof.UserRepository.Add(user);
                    (int result, bool done, string message) = await _uof.UserRepository.SaveAsync();

                    return (result, done, message);
                }

                return (0, false, returnMessage);
            }
            catch (Exception ex) //Caso de erro inesperado
            {
                string message;
                return (0, false,  message = ex.Message);
            }
            finally
            {
                _uof.Dispose();
            }
        }

        public async Task<ResultModel<TokenInfo>> FindByUser(User user)
        {
            ResultModel<TokenInfo> resultModel = new ResultModel<TokenInfo>();

            try
            {
                (bool gonaLogin, User userTemp) = await _uof.UserRepository.UserIsInDb(user);

                if (gonaLogin)
                {
                    resultModel.Model = new TokenInfo();

                    // Gera o Token
                    var token = TokenService.GenerateToken(userTemp);

                    // Oculta a senha
                    userTemp.Password = "";

                    resultModel.Model.User = userTemp;
                    resultModel.Model.Token = token;

                    resultModel.SuccessMessage = "Logado com sucesso";
                    return resultModel;
                }
                else
                {
                    resultModel.ErrorMessage = "Credenciais incorretas";
                    return resultModel;
                }
            }
            catch (Exception ex)
            {
                resultModel.ErrorMessage = "Erro interno, contatar o administrador";
                return resultModel;
            }
            finally
            {
                _uof.Dispose();
            }
        }
    }
}
