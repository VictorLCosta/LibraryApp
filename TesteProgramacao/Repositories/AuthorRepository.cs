using TesteProgramacao.Data.Context;
using TesteProgramacao.Entities;
using TesteProgramacao.Repositories.Contracts;

namespace TesteProgramacao.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context)
            : base(context)
        {
            
        }
    }
}