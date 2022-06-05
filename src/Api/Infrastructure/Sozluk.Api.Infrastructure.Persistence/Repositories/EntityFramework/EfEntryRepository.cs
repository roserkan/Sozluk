using Sozluk.Api.Application.Interfaces.Repositories;
using Sozluk.Api.Domain.Models;
using Sozluk.Api.Infrastructure.Persistence.Contexts;

namespace Sozluk.Api.Infrastructure.Persistence.Repositories.EntityFramework;

public class EfEntryRepository : EfEntityRepositoryBase<Entry>, IEntryRepository
{
    public EfEntryRepository(SozlukContext dbContext) : base(dbContext)
    {
    }
}
