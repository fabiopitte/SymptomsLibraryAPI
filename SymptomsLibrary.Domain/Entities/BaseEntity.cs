namespace SymptomsLibrary.Domain.Entities;
public class BaseEntity
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }
}
