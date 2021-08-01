using System.Threading.Tasks;
using TesteProgramacao.Data.Context;
using TesteProgramacao.Interfaces;
using TesteProgramacao.Repositories;
using TesteProgramacao.Repositories.Contracts;

namespace TesteProgramacao.Services
{
    public class UnitOfWork : IUnitOfWork
    {   
        private readonly ApplicationDbContext _context;

        public IBooksRepository BooksRepository { get; private set; }

        public IAuthorRepository AuthorRepository { get; private set; }

        public IPublisherRepository PublisherRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            BooksRepository = new BooksRepository(_context);
            AuthorRepository = new AuthorRepository(_context);
            PublisherRepository = new PublisherRepository(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}