using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class VwPersonEducation
{
    public int UserId { get; set; }

    public int? EducationId { get; set; }

    public string? InstitutionName { get; set; }

    public string? Degree { get; set; }

    public string? Field { get; set; }

    public string? Location { get; set; }

    public bool? CurrentlyStudying { get; set; }

    public double? Grade { get; set; }

    public int? PassedYear { get; set; }
}
