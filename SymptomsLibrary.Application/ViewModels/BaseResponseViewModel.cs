namespace SymptomsLibrary.Application.ViewModels;
public class BaseResponseViewModel
{
    // Only the owner can modify itself, following the O principle of S.O.L.I.D
    public int Id { get; private set; }
    public string Name { get; private set; }

    public BaseResponseViewModel(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
