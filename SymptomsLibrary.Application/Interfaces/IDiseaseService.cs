using SymptomsLibrary.Application.ViewModels;

namespace SymptomsLibrary.Application.Interfaces;
public interface IDiseaseService
{
    Task<IEnumerable<DiseaseListResponseViewModel>> GetDiseasesAsync();
    Task<DiseaseResponseViewModel> RegisterDiseaseAsync(DiseaseRequestViewModel diseaseViewModel);
}