using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class VwPersonEmploymentHistory
{
    public int UserId { get; set; }

    public int? CompanyId { get; set; }

    public string? JobTitle { get; set; }

    public DateOnly? StartDate { get; set; }

    public bool? IsCurrentlyWorking { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? YearsOfExperience { get; set; }

    public string? DistrictCity { get; set; }

    public string? ProvinceState { get; set; }

    public bool? IsHeadOffice { get; set; }

    public double? Amount { get; set; }
}
