using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class UserAchievement
{
    public int UserId { get; set; }

    public int AchievementId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? DeletedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Achievement Achievement { get; set; } = null!;

    public virtual PersonInfo User { get; set; } = null!;
}
