using ModelsShared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiLivraria.Repository;

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

        public async Task<(int, bool, string)> FindByUser(User user)
        {
            try
            {
                bool gonaLogin = await _uof.UserRepository.UserIsInDb(user);

                if (gonaLogin)
                    return (0, true, "Logado com sucesso");
                else
                    return (0, false, "Tentativas incorretas");
            }
            catch (Exception ex)
            {
                return (0, false, ex.Message);
            }
            finally
            {
                _uof.Dispose();
            }
        }
    }
}
