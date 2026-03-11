using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class UserSkill
{
    public int UserId { get; set; }

    public int SkillId { get; set; }

    public string? SkillLevel { get; set; }

    public int? YearsOfExperience { get; set; }

    public bool IsActive { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Skill Skill { get; set; } = null!;

    public virtual PersonInfo User { get; set; } = null!;
}
