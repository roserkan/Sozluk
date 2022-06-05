using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sozluk.Api.Application.Interfaces.Repositories;
using Sozluk.Api.Infrastructure.Persistence.Contexts;
using Sozluk.Api.Infrastructure.Persistence.Repositories.EntityFramework;

namespace Sozluk.Api.Infrastructure.Persistence.Extensions;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<SozlukContext>(options =>
        {
            string connectionString = configuration["SozlukDbConnectionString"];
            options.UseNpgsql(connectionString, opt => opt.EnableRetryOnFailure());
        });


        //var seedData = new SeedData();
        //seedData.SeedAsync(configuration).GetAwaiter().GetResult();

        services.AddScoped<IEmailConfirmationRepository, EfEmailConfirmationRepository>();
        services.AddScoped<IUserRepository, EfUserRepository>();
        services.AddScoped<IEntryRepository, EfEntryRepository>();
        services.AddScoped<IEntryCommentRepository, EfEntryCommentRepository>();

        return services;
    }
}
