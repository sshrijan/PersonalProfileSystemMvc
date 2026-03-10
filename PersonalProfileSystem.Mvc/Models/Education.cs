using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class Education
{
    public int EducationId { get; set; }

    public string InstitutionName { get; set; } = null!;

    public string Degree { get; set; } = null!;

    public string Field { get; set; } = null!;

    public string Location { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<UserEducation> UserEducations { get; set; } = new List<UserEducation>();
}
