using Sozluk.Api.Application.Interfaces.Repositories;
using Sozluk.Api.Domain.Models;
using Sozluk.Api.Infrastructure.Persistence.Contexts;

namespace Sozluk.Api.Infrastructure.Persistence.Repositories.EntityFramework;

public class EfUserRepository : EfEntityRepositoryBase<User>, IUserRepository
{
    public EfUserRepository(SozlukContext dbContext) : base(dbContext)
    {
    }
}
