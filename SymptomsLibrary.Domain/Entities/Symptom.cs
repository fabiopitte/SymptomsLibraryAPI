namespace SymptomsLibrary.Domain.Entities;

public class Symptom : BaseEntity
{
    public Symptom(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public Symptom(string name) => Name = name;

    public int DiseaseId { get; private set; }
    public Disease Disease { get; private set; }

    // here we have an [anemic domain] - however in a complex domain, it's here we add some business rules [rich domain].
}

