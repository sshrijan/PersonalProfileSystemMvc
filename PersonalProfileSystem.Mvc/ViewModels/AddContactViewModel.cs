namespace PersonalProfileSystem.Mvc.ViewModels;
public class AddContactViewModel
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public long Phone { get; set; }
}