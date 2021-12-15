using SymptomsLibrary.Application.ViewModels;

namespace SymptomsLibrary.Application.Interfaces;
public interface ISearchService
{
    Task<List<SearchViewModel>> SearchAsync(string term);
}