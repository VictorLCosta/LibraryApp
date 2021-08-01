using TesteProgramacao.Data.Context;
using TesteProgramacao.Entities;
using TesteProgramacao.Repositories.Contracts;

namespace TesteProgramacao.Repositories
{
    public class BooksRepository : Repository<Book>, IBooksRepository
    {
        public BooksRepository(ApplicationDbContext context)
            : base(context)
        {
            
        }
    }
}