using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sozluk.Api.Domain.Models;
using Sozluk.Api.Infrastructure.Persistence.Contexts;


namespace Sozluk.Api.Infrastructure.Persistence.EntityConfigurations;

public class EmailConfirmationEntityConfiguration : BaseEntityConfiguration<EmailConfirmation>
{
    public override void Configure(EntityTypeBuilder<EmailConfirmation> builder)
    {
        base.Configure(builder);

        builder.ToTable("EmailConfirmations", SozlukContext.DEFAULT_SCHEMA);
    }
}




