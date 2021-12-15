using SymptomsLibrary.Application.Interfaces;
using SymptomsLibrary.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace SymptomsLibrary.Presentation.Controllers;

[Route("api/symptoms/")]
public class SymptomController : ControllerBase
{
    private readonly ISymptomService _symptomService;

    public SymptomController(ISymptomService symptomService) => _symptomService = symptomService;

    [HttpGet]
    public async Task<ActionResult<List<SymptomResponseViewModel>>> GetSymptomsAsync()
    {
        var result = await _symptomService.GetSymptomsAsync();

        if (result == null)
            return BadRequest();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> RegisterSymptomAsync([FromBody] SymptomRequestViewModel symptomRequestViewModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var symptomResponse = await _symptomService.RegisterSymptomAsync(symptomRequestViewModel);

        if (symptomResponse == null)
            return BadRequest();

        return Ok(symptomResponse);
    }
}
