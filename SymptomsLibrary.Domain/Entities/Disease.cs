namespace SymptomsLibrary.Domain.Entities;
public class Disease : BaseEntity
{
    public virtual ICollection<Symptom> Symptoms { get; private set; } = new List<Symptom>();

    public Disease() => Symptoms = new HashSet<Symptom>();

    public Disease(string name) => Name = name;

    public void AddSymptom(Symptom symptom) => Symptoms.Add(symptom);
}

