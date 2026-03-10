using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class VwPersonProject
{
    public int UserId { get; set; }

    public int? ProjectId { get; set; }

    public int? TechnologyId { get; set; }

    public string? Title { get; set; }

    public string? Role { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Technology { get; set; }
}
