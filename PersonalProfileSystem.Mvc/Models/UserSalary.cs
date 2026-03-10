using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class UserSalary
{
    public int UserId { get; set; }

    public int CompanyId { get; set; }

    public double Amount { get; set; }

    public bool IsActive { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual PersonInfo User { get; set; } = null!;
}
