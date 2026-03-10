using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string? Title { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<UsedTechnology> UsedTechnologies { get; set; } = new List<UsedTechnology>();

    public virtual ICollection<UserProject> UserProjects { get; set; } = new List<UserProject>();
}
