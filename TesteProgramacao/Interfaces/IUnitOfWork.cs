using System;
using System.Threading.Tasks;
using TesteProgramacao.Repositories.Contracts;

namespace TesteProgramacao.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBooksRepository BooksRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IPublisherRepository PublisherRepository { get; }
        Task<int> Complete();
    }
}