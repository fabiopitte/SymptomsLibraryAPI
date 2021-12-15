namespace SymptomsLibrary.Domain.Entities;
public class Search
{
    public string Name { get; private set; }
    public string Tag { get; private set; }
    public Search(string name, string tag)
    {
        Name = name;
        Tag = tag;
    }
}

