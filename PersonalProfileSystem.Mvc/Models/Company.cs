using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public int SalaryId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string District { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; } = new List<CompanyAddress>();

    public virtual ICollection<EmploymentHistory> EmploymentHistories { get; set; } = new List<EmploymentHistory>();

    public virtual ICollection<UserSalary> UserSalaries { get; set; } = new List<UserSalary>();
}
