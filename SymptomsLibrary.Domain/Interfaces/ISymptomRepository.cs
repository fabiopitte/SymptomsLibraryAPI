using SymptomsLibrary.Domain.Entities;

namespace SymptomsLibrary.Domain.Interfaces;

public interface ISymptomRepository
{
    Task<IEnumerable<Symptom>> GetSymptomsAsync();
    Task<Symptom> PostSymptomAsync(Symptom symptom);
}
