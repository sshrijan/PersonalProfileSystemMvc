using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class EmploymentHistory
{
    public int UserId { get; set; }

    public int CompanyId { get; set; }

    public string JobTitle { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public bool IsCurrentlyWorking { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? YearsOfExperience { get; set; }

    public decimal? Salary { get; set; }

    public bool IsActive { get; set; }

    public DateTime? DeletedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual PersonInfo User { get; set; } = null!;
}
