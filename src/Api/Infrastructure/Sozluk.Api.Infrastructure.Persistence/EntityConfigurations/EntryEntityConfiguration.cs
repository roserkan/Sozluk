using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sozluk.Api.Infrastructure.Persistence.Contexts;

namespace Sozluk.Api.Infrastructure.Persistence.EntityConfigurations;

public class EntryEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.Entry>
{
    public override void Configure(EntityTypeBuilder<Api.Domain.Models.Entry> builder)
    {
        base.Configure(builder);

        builder.ToTable("Entries", SozlukContext.DEFAULT_SCHEMA);


        builder.HasOne(i => i.CreatedBy)
            .WithMany(i => i.Entries)
            .HasForeignKey(i => i.CreatedById);
    }
}

