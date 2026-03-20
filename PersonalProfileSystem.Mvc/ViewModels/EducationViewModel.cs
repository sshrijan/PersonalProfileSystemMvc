namespace PersonalProfileSystem.Mvc.ViewModels;
public class AddEducationViewModel
{
    public int UserId { get; set; }

    public string InstitutionName { get; set; } = null!;

    public string Degree { get; set; } = null!;

    public string Field { get; set; } = null!;

    public string Location { get; set; } = null!;

    public bool? CurrentlyStudying { get; set; }

    public string? Grade { get; set; }

    public int? PassedYear { get; set; }

}