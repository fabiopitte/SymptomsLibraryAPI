using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SymptomsLibrary.Application.Interfaces;
using SymptomsLibrary.Application.Services;
using SymptomsLibrary.Domain.Interfaces;
using SymptomsLibrary.Infra.Data.Context;
using SymptomsLibrary.Infra.Data.Repositories;

namespace SymptomsLibrary.Infra.IoC;

// This project is to share common calls/methods with other projects
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ISymptomRepository, SymptomRepository>();
        services.AddScoped<ISymptomService, SymptomService>();

        services.AddScoped<IDiseaseRepository, DiseaseRepository>();
        services.AddScoped<IDiseaseService, DiseaseService>();

        services.AddScoped<ISearchRepository, SearchRepository>();
        services.AddScoped<ISearchService, SearchService>();

        services.AddDbContext<SymptomsLibraryDbContext>(o => o.UseInMemoryDatabase("SymptomsLibrary"));

        return services;
    }
}
