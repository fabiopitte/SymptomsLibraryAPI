using SymptomsLibrary.Application.ViewModels;

namespace SymptomsLibrary.Application.Interfaces;
public interface ISymptomService
{
    Task<IEnumerable<SymptomResponseViewModel>> GetSymptomsAsync();
    Task<SymptomResponseViewModel> RegisterSymptomAsync(SymptomRequestViewModel symptomViewModel);
}