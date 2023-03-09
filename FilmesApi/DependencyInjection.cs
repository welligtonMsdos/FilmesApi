using FilmesApi.Data;
using FilmesApi.Interfaces;
using FilmesApi.Services;

namespace FilmesApi;

public static class DependencyInjection
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<IFilmeRepository, FilmeEF>();
        services.AddScoped<IFilmeService, FilmeService>();

        return services;
    }
}
