using SymptomsLibrary.Domain.Entities;

namespace SymptomsLibrary.Domain.Interfaces;

public interface IDiseaseRepository
{
    Task<IEnumerable<Disease>> GetDiseasesAsync();
    Task<Disease> RegisterDiseaseAsync(Disease disease);
}
