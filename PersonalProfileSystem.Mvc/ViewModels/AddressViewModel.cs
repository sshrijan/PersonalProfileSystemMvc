namespace PersonalProfileSystem.Mvc.ViewModels;
public class AddAddressViewModel
{
    public int UserId { get; set; }

    public string Country { get; set; } = null!;

    public string ProvinceState { get; set; } = null!;

    public string DistrictCity { get; set; } = null!;

    public string Tole { get; set; } = null!;
    public int Ward { get; set; }

}