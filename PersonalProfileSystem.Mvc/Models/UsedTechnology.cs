using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class UsedTechnology
{
    public int ProjectId { get; set; }

    public int TechnologyId { get; set; }

    public bool IsActive { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual Technology Technology { get; set; } = null!;
}
