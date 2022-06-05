using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sozluk.Api.Domain.Models;
using Sozluk.Api.Infrastructure.Persistence.Contexts;

namespace Sozluk.Api.Infrastructure.Persistence.EntityConfigurations;

public class EntryFavoriteEntityConfiguration : BaseEntityConfiguration<EntryFavorite>
{
    public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
    {
        base.Configure(builder);

        builder.ToTable("EntryFavorites", SozlukContext.DEFAULT_SCHEMA);


        builder.HasOne(i => i.Entry)
            .WithMany(i => i.EntryFavorites)
            .HasForeignKey(i => i.EntryId);

        builder.HasOne(i => i.CreatedUser)
            .WithMany(i => i.EntryFavorites)
            .HasForeignKey(i => i.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}