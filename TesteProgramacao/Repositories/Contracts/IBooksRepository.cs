using System.Collections.Generic;
using System.Threading.Tasks;
using TesteProgramacao.Entities;

namespace TesteProgramacao.Repositories.Contracts
{
    public interface IBooksRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllWithAuthor();
    }
}