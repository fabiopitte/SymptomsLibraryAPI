using SymptomsLibrary.Application.Interfaces;
using SymptomsLibrary.Application.ViewModels;
using SymptomsLibrary.Domain.Entities;
using SymptomsLibrary.Domain.Interfaces;

namespace SymptomsLibrary.Application.Services;
public class SymptomService : ISymptomService
{
    private readonly ISymptomRepository _repository;

    public SymptomService(ISymptomRepository repository) => _repository = repository;

    public async Task<IEnumerable<SymptomResponseViewModel>> GetSymptomsAsync()
    {
        var symptomsListViewModel = new List<SymptomResponseViewModel>();

        var symptoms = await _repository.GetSymptomsAsync();

        // here we can use AutoMapper
        symptoms.ToList().ForEach(s => symptomsListViewModel.Add(new SymptomResponseViewModel(s.Id, s.Name)));

        return symptomsListViewModel;
    }

    public async Task<SymptomResponseViewModel> RegisterSymptomAsync(SymptomRequestViewModel symptomViewModel)
    {
        var symptomRequest = new Symptom(symptomViewModel.Name);

        var symptomResponse = await _repository.PostSymptomAsync(symptomRequest);

        return new SymptomResponseViewModel(symptomResponse.Id, symptomResponse.Name);
    }
}
