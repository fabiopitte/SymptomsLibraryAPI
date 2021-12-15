using System.ComponentModel.DataAnnotations;

namespace SymptomsLibrary.Application.ViewModels;
public class DiseaseRequestViewModel
{
    [Required(ErrorMessage = "Name is required.")]
    [MinLength(3)]
    [MaxLength(50)]
    [Display(Name = "Name")]
    public string Name { get; set; }

    public List<SymptomRequest> Symptoms { get; set; } = new List<SymptomRequest>();

    public DiseaseRequestViewModel() { }
    public DiseaseRequestViewModel(string name)
    {
        Name = name;
    }

    // using chaining method (returning this)
    public DiseaseRequestViewModel AddSymptom(SymptomRequest symptom)
    {
        Symptoms.Add(symptom);

        return this;
    }

    public class SymptomRequest
    {
        public SymptomRequest() { }

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public SymptomRequest(string name)
        {
            Name = name;
        }
    }
}

