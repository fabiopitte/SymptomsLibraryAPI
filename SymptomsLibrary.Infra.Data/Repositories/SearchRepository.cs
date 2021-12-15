using SymptomsLibrary.Domain.Entities;
using SymptomsLibrary.Domain.Interfaces;
using SymptomsLibrary.Infra.Data.Context;

namespace SymptomsLibrary.Infra.Data.Repositories;
public class SearchRepository : ISearchRepository
{
    private readonly SymptomsLibraryDbContext _context;

    public SearchRepository(SymptomsLibraryDbContext context) => _context = context;

    public async Task<IEnumerable<Search>> SearchAsync(string term)
    {
        var response = new List<Search>();

        var symptoms = _context.Symptoms;
        var diseases = _context.Diseases;

        var querySymptoms = (from d in symptoms
                             where d.Name.Contains(term)
                             select new Search(d.Name, "symptom"))
                             .ToList();

        var queryDiseases = (from d in diseases
                             where d.Name.Contains(term)
                             select new Search(d.Name, "disease"))
                             .ToList();

        response.AddRange(querySymptoms);
        response.AddRange(queryDiseases);

        await Task.CompletedTask;

        return response;
    }
}
