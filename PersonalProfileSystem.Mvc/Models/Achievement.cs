using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class Achievement
{
    public int AchievementId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateOnly AchievementDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
}
