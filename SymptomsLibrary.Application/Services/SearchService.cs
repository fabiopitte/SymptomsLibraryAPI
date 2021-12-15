using SymptomsLibrary.Application.Interfaces;
using SymptomsLibrary.Application.ViewModels;
using SymptomsLibrary.Domain.Interfaces;

namespace SymptomsLibrary.Application.Services;
public class SearchService : ISearchService
{
    private readonly ISearchRepository _repository;

    public SearchService(ISearchRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<SearchViewModel>> SearchAsync(string term)
    {
        var response = new List<SearchViewModel>();

        var items = await _repository.SearchAsync(term);

        if (items == null)
            return default(List<SearchViewModel>);

        items.ToList().ForEach(x => response.Add(new SearchViewModel(x.Name, x.Tag)));

        return response;
    }
}
