using SymptomsLibrary.Domain.Entities;

namespace SymptomsLibrary.Domain.Interfaces;

public interface ISearchRepository
{
    Task<IEnumerable<Search>> SearchAsync(string term);
}
