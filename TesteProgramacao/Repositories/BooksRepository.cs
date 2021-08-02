using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Book>> GetAllWithAuthor()
        {
            return await _context.Books.Include(x => x.Author).ToListAsync();
        }
    }
}