using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLivraria.Repository
{
    public interface IUnityOfWork
    {
        IBookRepository BookRepository { get; }

        void Commit();

        void Dispose();
    }
}
