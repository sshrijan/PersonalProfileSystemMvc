using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class Technology
{
    public int TechnologyId { get; set; }

    public string Technology1 { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<UsedTechnology> UsedTechnologies { get; set; } = new List<UsedTechnology>();
}
