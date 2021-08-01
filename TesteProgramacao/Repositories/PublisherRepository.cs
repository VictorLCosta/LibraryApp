using TesteProgramacao.Data.Context;
using TesteProgramacao.Entities;
using TesteProgramacao.Repositories.Contracts;

namespace TesteProgramacao.Repositories
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ApplicationDbContext context)
            : base(context)
        {
            
        }
    }
}