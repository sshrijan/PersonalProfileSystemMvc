using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class VwPersonAddress
{
    public int UserId { get; set; }

    public int? AddressId { get; set; }

    public string? Country { get; set; }

    public string? ProvinceState { get; set; }

    public string? DistrictCity { get; set; }

    public int? Ward { get; set; }

    public string? Tole { get; set; }
}
