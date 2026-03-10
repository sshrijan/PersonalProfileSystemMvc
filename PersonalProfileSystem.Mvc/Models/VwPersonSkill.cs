using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class VwPersonSkill
{
    public int UserId { get; set; }

    public int? SkillId { get; set; }

    public string? SkillName { get; set; }

    public string? SkillLevel { get; set; }

    public int? YearsOfExperience { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
