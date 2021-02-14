using WebApiLivraria.Data;

namespace WebApiLivraria.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private BookRepository _bookRepo;
        private UserRepository _userRepo;

        public ApplicationContext _context;

        public UnityOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IBookRepository BookRepository
        {
            get
            {
                return _bookRepo ??= new BookRepository(_context);
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                return _userRepo ??= new UserRepository(_context);
            }
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
