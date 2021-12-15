using Microsoft.AspNetCore.Mvc;
using SymptomsLibrary.Application.Interfaces;
using SymptomsLibrary.Application.ViewModels;

namespace SymptomsLibrary.Presentation.Controllers;

[Route("api/diseases/")]
public class DiseaseController : ControllerBase
{
    private readonly IDiseaseService _diseaseService;

    public DiseaseController(IDiseaseService diseaseService) => _diseaseService = diseaseService;

    [HttpGet]
    public async Task<ActionResult> GetDiseasesAsync() => Ok(await _diseaseService.GetDiseasesAsync());

    [HttpPost]
    public async Task<ActionResult> RegisterDiseaseAsync([FromBody] DiseaseRequestViewModel diseaseRequestViewModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (diseaseRequestViewModel.Symptoms.Count == 0)
            return BadRequest("At least one Symptom is required!");

        var diseaseResponse = await _diseaseService.RegisterDiseaseAsync(diseaseRequestViewModel);

        if (diseaseResponse == null)
            return BadRequest();

        return Ok(diseaseResponse);
    }
}
