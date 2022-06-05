using Sozluk.Api.Application.Interfaces.Repositories;
using Sozluk.Api.Domain.Models;
using Sozluk.Api.Infrastructure.Persistence.Contexts;

namespace Sozluk.Api.Infrastructure.Persistence.Repositories.EntityFramework;

public class EfEntryCommentRepository : EfEntityRepositoryBase<EntryComment>, IEntryCommentRepository
{
    public EfEntryCommentRepository(SozlukContext dbContext) : base(dbContext)
    {
    }
}
