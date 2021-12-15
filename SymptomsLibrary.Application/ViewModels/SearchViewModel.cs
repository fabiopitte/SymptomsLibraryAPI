namespace SymptomsLibrary.Application.ViewModels;
public class SearchViewModel
{
    public string Name { get; private set; }
    public string Tag { get; private set; }

    public SearchViewModel(string name, string tag)
    {
        Name = name;
        Tag = tag;
    }
}

