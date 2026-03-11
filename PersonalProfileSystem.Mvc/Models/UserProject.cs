using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class UserProject
{
    public int UserId { get; set; }

    public int ProjectId { get; set; }

    public string? Role { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool IsActive { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual PersonInfo User { get; set; } = null!;
}
