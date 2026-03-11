namespace PersonalProfileSystem.Mvc.ViewModels;
public class AddEducationViewModel
{
    public int UserId { get; set; }

    public string Degree { get; set; }

    public string Field { get; set; }

    public string InstitutionName { get; set; }

    public string Location { get; set; }

    public int? PassedYear { get; set; }
}