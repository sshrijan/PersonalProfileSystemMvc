using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class Skill
{
    public int SkillId { get; set; }

    public string? SkillName { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
}
