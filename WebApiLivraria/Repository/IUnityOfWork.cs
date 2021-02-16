using ModelsShared.Models;

namespace WebApiLivraria.Repository
{
    public interface IUnityOfWork
    {
        IBookRepository BookRepository { get; }
        IUserRepository UserRepository { get; }

        void Commit();

        void Dispose();
    }
}
