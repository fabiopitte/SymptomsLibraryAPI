using SymptomsLibrary.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SymptomsLibrary.Presentation.Controllers;

[Route("api/search/")]
public class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService) => _searchService = searchService;

    [Route("{term}", Name = "Search")]
    [HttpGet]
    public async Task<ActionResult> SearchAsync(string term)
    {
        var result = await _searchService.SearchAsync(term);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}
