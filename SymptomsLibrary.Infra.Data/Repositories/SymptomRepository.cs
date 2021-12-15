using Microsoft.EntityFrameworkCore;
using SymptomsLibrary.Domain.Entities;
using SymptomsLibrary.Domain.Interfaces;
using SymptomsLibrary.Infra.Data.Context;

namespace SymptomsLibrary.Infra.Data.Repositories;
public class SymptomRepository : ISymptomRepository
{
    private readonly SymptomsLibraryDbContext _context;

    public SymptomRepository(SymptomsLibraryDbContext context) => _context = context;

    public IQueryable<Symptom> Symptom
    {
        get { return _context.Symptoms; }
    }

    public async Task<IEnumerable<Symptom>> GetSymptomsAsync() => await Symptom.ToListAsync();

    public async Task<Symptom> PostSymptomAsync(Symptom symptom)
    {
        await _context.Symptoms.AddAsync(symptom);
        await _context.SaveChangesAsync();

        return symptom;
    }
}

