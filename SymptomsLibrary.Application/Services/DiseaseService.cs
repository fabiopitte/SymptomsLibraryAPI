using SymptomsLibrary.Application.Interfaces;
using SymptomsLibrary.Application.ViewModels;
using SymptomsLibrary.Domain.Entities;
using SymptomsLibrary.Domain.Interfaces;

namespace SymptomsLibrary.Application.Services;
public class DiseaseService : IDiseaseService
{
    private readonly IDiseaseRepository _repository;

    public DiseaseService(IDiseaseRepository repository) => _repository = repository;

    public async Task<IEnumerable<DiseaseListResponseViewModel>> GetDiseasesAsync()
    {
        var diseasesListViewModel = new List<DiseaseListResponseViewModel>();

        var diseases = await _repository.GetDiseasesAsync();

        // here we can use AutoMapper
        diseases.ToList().ForEach(s => diseasesListViewModel.Add(new DiseaseListResponseViewModel(s.Id, s.Name)));

        return diseasesListViewModel;
    }

    public async Task<DiseaseResponseViewModel> RegisterDiseaseAsync(DiseaseRequestViewModel diseaseViewModel)
    {
        // map to domain model
        var diseaseRequest = new Disease(diseaseViewModel.Name);

        diseaseViewModel.Symptoms.ToList().ForEach(i => diseaseRequest.AddSymptom(new Symptom(i.Id, i.Name)));

        var diseaseResponse = await _repository.RegisterDiseaseAsync(diseaseRequest);

        // map to responseViewModel
        var response = new DiseaseResponseViewModel(diseaseResponse.Id, diseaseResponse.Name);

        diseaseResponse.Symptoms.ToList().ForEach(i => response.AddSymptom(new SymptomResponseViewModel(i.Id, i.Name)));

        return response;
    }
}
