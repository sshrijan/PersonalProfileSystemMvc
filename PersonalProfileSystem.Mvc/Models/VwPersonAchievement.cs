using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class VwPersonAchievement
{
    public int UserId { get; set; }

    public int? AchievementId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateOnly? AchievementDate { get; set; }
}
