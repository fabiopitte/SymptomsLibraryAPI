using Microsoft.EntityFrameworkCore;
using SymptomsLibrary.Domain.Entities;
using SymptomsLibrary.Domain.Interfaces;
using SymptomsLibrary.Infra.Data.Context;

namespace SymptomsLibrary.Infra.Data.Repositories;
public class DiseaseRepository : IDiseaseRepository
{
    private readonly SymptomsLibraryDbContext _context;

    public DiseaseRepository(SymptomsLibraryDbContext context) => _context = context;

    public IQueryable<Disease> Disease
    {
        get { return _context.Diseases; }
    }

    public async Task<IEnumerable<Disease>> GetDiseasesAsync() => await Disease.ToListAsync();

    public async Task<Disease> RegisterDiseaseAsync(Disease disease)
    {
        _context.Diseases.Attach(disease);

        await _context.SaveChangesAsync();

        return disease;
    }
}
