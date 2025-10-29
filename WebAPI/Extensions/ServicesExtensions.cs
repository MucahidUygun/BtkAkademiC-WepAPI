using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace WebAPI.Extensions;

public static class ServicesExtensions
{
    // This kullanımı ile IServiceColletion genişletiliyor
    public static void ConfigureSqlContext(this IServiceCollection services,
        IConfiguration configuration) => services.AddDbContext<RepositoryContext>
        (
        options => options.UseSqlServer(configuration.GetConnectionString("btkAkedemiC#"))
        );

    public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager,ServiceManager>();
    
}
