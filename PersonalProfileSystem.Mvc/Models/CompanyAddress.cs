using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class CompanyAddress
{
    public int CompanyAddressId { get; set; }

    public int CompanyId { get; set; }

    public string Country { get; set; } = null!;

    public string DistrictCity { get; set; } = null!;

    public string ProvinceState { get; set; } = null!;

    public bool IsHeadOffice { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Company Company { get; set; } = null!;
}
