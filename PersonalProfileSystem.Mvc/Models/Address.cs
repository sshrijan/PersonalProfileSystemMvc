using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string Country { get; set; } = null!;

    public string ProvinceState { get; set; } = null!;

    public string DistrictCity { get; set; } = null!;

    public int Ward { get; set; }

    public string Tole { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
}
