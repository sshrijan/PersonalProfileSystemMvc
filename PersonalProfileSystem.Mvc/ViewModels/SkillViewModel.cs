namespace PersonalProfileSystem.Mvc.ViewModels;

public class AddSkillViewModel
{
    public int UserId { get; set; }

    public string SkillName { get; set; } = null!;

    public string SkillLevel { get; set; } = null!;

    public int? YearsOfExperience { get; set; }
}