using System.ComponentModel.DataAnnotations;

namespace SymptomsLibrary.Application.ViewModels;
public class SymptomRequestViewModel
{
    public SymptomRequestViewModel() { }

    [Required(ErrorMessage = "Name is required.")]
    [MinLength(3)]
    [MaxLength(50)]
    [Display(Name = "Name")]
    public string Name { get; set; }

    public SymptomRequestViewModel(string name)
    {
        Name = name;
    }
}
