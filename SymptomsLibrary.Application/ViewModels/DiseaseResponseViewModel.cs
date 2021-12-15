namespace SymptomsLibrary.Application.ViewModels;
public class DiseaseResponseViewModel : BaseResponseViewModel
{
    public List<SymptomResponseViewModel> Symptoms { get; private set; } = new List<SymptomResponseViewModel>();

    public DiseaseResponseViewModel(int id, string theirName) : base(id, theirName) { }

    // following the principle, O of SOLID - open for read, closed for change
    public void AddSymptom(SymptomResponseViewModel symptom)
    {
        Symptoms.Add(symptom);
    }
}
